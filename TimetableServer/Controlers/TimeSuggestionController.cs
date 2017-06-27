using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI;
using TimetableServer.Models;

namespace TimetableServer.Controlers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("time-suggestion/{id}")]
    public class TimeSuggestionController : ApiController
    {
        private DataBase _db;

        private const int MaximumBlockNumber = 40;

        // GET: api/TimeSuggestion
        public IEnumerable<List<TimeSuggestion>> Get(string id)
        {
            _db = _db ?? new DataBase();
            var lesson = _db.getLesson(id);
            var teacherTimeSlots = GetTeacherTimeSlotsForLesson(id);
            var groupTimeSlots = GetGroupTimeSlotsForLesson(id);
            var combinedTimeSlots = teacherTimeSlots;
            for(var dayNumber = 0; dayNumber < groupTimeSlots.Count; ++dayNumber)
            {
                foreach (var groupTimeSlotsForDay in groupTimeSlots[dayNumber].Where(groupTimeSlotsForDay => groupTimeSlotsForDay.Availability == Availability.NonAvailable))
                {
                    combinedTimeSlots[dayNumber].First(c => c.BlockName == groupTimeSlotsForDay.BlockName).Availability = Availability.NonAvailable;
                }
            }
            var possibleTimeSlots = getPossibleTimeSlots(combinedTimeSlots, lesson);
            try
            {
                var tmp = GetTimeSlotsWithFreeClassooms(possibleTimeSlots, lesson);
                return tmp;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }
            
        }

        private IEnumerable<List<TimeSuggestion>> GetTimeSlotsWithFreeClassooms(List<List<TimeSuggestion>> possibleTimeSlots, lesson lesson)
        {
            List<classroom> classrooms = new List<classroom>();
            classrooms = _db.getAllClassRooms().Where(cr => cr.croomtype != null).Where(cr => cr.croomtype.idcroomtype == lesson.subject.type).ToList();
            var classroomsTimeSlots = classrooms.Select(cr => new Pair(cr, GetLessonTimeSlotsForClassroom(cr))).ToList();
            for (var day = 0; day < possibleTimeSlots.Count; ++day)
            {
                for (var timeSlot = 0; timeSlot < possibleTimeSlots.ElementAt(day).Count; timeSlot++)
                {
                    foreach (var classroom in classroomsTimeSlots)
                    {
                        var cr = (classroom) classroom.First;
                        var crTimeSlots = (List<List<TimeSlot>>) classroom.Second;
                        var free = true;
                        for (var start = 0; start < lesson.subject.time.GetValueOrDefault(); ++start)
                        {
                            if (crTimeSlots.ElementAt(day).ElementAt(timeSlot + start).Availability ==
                                Availability.NonAvailable)
                                free = false;
                        }
                        if(free)
                            possibleTimeSlots.ElementAt(day).ElementAt(timeSlot).possibleClassrooms.Add(Converter.ConvertDbClassroomToClassroom(cr));
                    }
                }
            }
            return possibleTimeSlots.Select(day => day.Where(ts => ts.possibleClassrooms.Any()).ToList());
        }

        private List<List<TimeSuggestion>> getPossibleTimeSlots(List<List<TimeSlot>> combinedTimeSlots, lesson lesson)
        {
            var timeSuggestions = new List<List<TimeSuggestion>>();
            var duration = lesson.subject.time.GetValueOrDefault();
            foreach (var day in combinedTimeSlots)
            {
                var timeSuggestionForADay = new List<TimeSuggestion>();
                for (var timeSlot = 0; timeSlot < (day.Count - duration); ++timeSlot)
                {
                    bool aviable = true;
                    for (int currentTime = 0; currentTime < duration; currentTime++)
                    {
                        if (day.ElementAt(timeSlot + currentTime).Availability == Availability.NonAvailable)
                        {
                            aviable = false;
                            break;
                        }
                    }
                    if(aviable)
                        timeSuggestionForADay.Add(new TimeSuggestion {startsAt = timeSlot, duration = duration, possibleClassrooms = new List<Classroom>()});
                }
                timeSuggestions.Add(timeSuggestionForADay);
            }
            return timeSuggestions;
        }

        private List<List<TimeSlot>> GetTeacherTimeSlotsForLesson(string LessonId)
        {
            var lesson = _db.getLesson(LessonId);
            var teacher = lesson.teacher;
            var teacherScheduledLessons = _db.getAllLessons().Where(p => (p.teacher == teacher) && ((p.start != null) && (p.idlessons != LessonId)));
            var availableTimeSlots = CreateClearTimeSlotWeek();
            int dayIndex = 0;
            foreach (var day in _db.getAllDays().OrderBy(d => d.iddays))
            {
                foreach (var scheduledLessonInDay in teacherScheduledLessons.Where(l => l.day == day))
                {
                    for (int startBlockAndDuration = scheduledLessonInDay.start.GetValueOrDefault();
                        startBlockAndDuration <
                        (scheduledLessonInDay.start.Value + scheduledLessonInDay.subject.time.GetValueOrDefault());
                        ++startBlockAndDuration)
                    {
                        availableTimeSlots[dayIndex].First(b => b.BlockName == startBlockAndDuration).Availability = Availability.NonAvailable;
                    }
                }
                ++dayIndex;
            }
            return availableTimeSlots;
        }

        private List<List<TimeSlot>> GetGroupTimeSlotsForLesson(string LessonId)
        {
            var lesson = _db.getLesson(LessonId);
            var group = lesson.group;
            var groupScheduledLessons = _db.getAllLessons().Where(p => (p.group == group) && ((p.start != null) && (p.idlessons != LessonId)));
            var availableTimeSlots = CreateClearTimeSlotWeek();
            int dayIndex = 0;
            foreach (var day in _db.getAllDays().OrderBy(d => d.iddays))
            {
                foreach (var scheduledLessonInDay in groupScheduledLessons.Where(l => l.day == day))
                {
                    for (int startBlockAndDuration = scheduledLessonInDay.start.GetValueOrDefault();
                        startBlockAndDuration <
                        (scheduledLessonInDay.start.Value + scheduledLessonInDay.subject.time.GetValueOrDefault());
                        ++startBlockAndDuration)
                    {
                        availableTimeSlots[dayIndex].First(b => b.BlockName == startBlockAndDuration).Availability = Availability.NonAvailable;
                    }
                }
                ++dayIndex;
            }
            return availableTimeSlots;
        }

        private List<List<TimeSlot>> GetLessonTimeSlotsForClassroom(classroom cr)
        {
            var lessonsInAWeek = cr.lessons.GroupBy(l => l.day.iddays).OrderBy(g => g.Key);
            var timeSlots = CreateClearTimeSlotWeek();
            var dayIndex = 0;
            foreach (var dayOfLessons in lessonsInAWeek)
            {
                foreach (var lesson in dayOfLessons)
                {
                    var duration = lesson.subject.time.GetValueOrDefault();
                    for (int slot = 0; slot < duration; ++slot)
                    {
                        timeSlots.ElementAt(dayIndex).ElementAt(lesson.start.Value + slot).Availability =
                            Availability.NonAvailable;
                    }
                }
                ++dayIndex;
            }
            return timeSlots;
        }

        private List<List<TimeSlot>> CreateClearTimeSlotWeek()
        {
            var clearTimeSlots = new List<List<TimeSlot>>();
            for (int dayNumber = 0; dayNumber < _db.getAllDays().Count; ++dayNumber)
            {
                var clearDay = new List<TimeSlot>();
                for (int i = 0; i <= MaximumBlockNumber; ++i)
                {
                    clearDay.Add(new TimeSlot { BlockName = i, Availability = Availability.Available });
                }
                clearTimeSlots.Add(clearDay);
            }
            return clearTimeSlots;
        }

        private enum Availability
        {
            Available,
            NonAvailable
        }

        private class TimeSlot
        {
            public int BlockName;
            public Availability Availability;
        }
    }
}
