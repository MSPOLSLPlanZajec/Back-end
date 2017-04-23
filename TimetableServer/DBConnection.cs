using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using System.Data;

//LEGACY
//DO NOT USE

namespace TimetableServer
{
    public class DBConnection
    {
        private MySql.Data.MySqlClient.MySqlConnection connection;
        private MySql.Data.MySqlClient.MySqlDataAdapter dbadapter;
        public string Table { get; set; }

        public DBConnection(string server, string user, string password, string database)
        {
            MySql.Data.MySqlClient.MySqlConnectionStringBuilder builder = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder();

            builder.Server = server;
            builder.UserID = user;
            builder.Password = password;
            builder.Database = database;

            connection = new MySql.Data.MySqlClient.MySqlConnection(builder.ConnectionString);

            //connection test
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw ex;
            }
            //
            
        }

        public void getData(ref DataSet data)
        {
            try
            {
                dbadapter = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM " + Table, connection);
                MySql.Data.MySqlClient.MySqlCommandBuilder builder = new MySql.Data.MySqlClient.MySqlCommandBuilder(dbadapter);

                dbadapter.Fill(data, Table);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                throw ex;
            }
        }

        public void getData(ref DataSet data, string table)
        {
            Table = table;
            getData(ref data);
        }

        public void sendData(ref DataSet data)
        {
            try
            {
                dbadapter = new MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM " + Table, connection);
                MySql.Data.MySqlClient.MySqlCommandBuilder builder = new MySql.Data.MySqlClient.MySqlCommandBuilder(dbadapter);

                dbadapter.Update(data, Table);

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                throw ex;
            }
        }

        public void sendData(ref DataSet data, string table)
        {
            Table = table;
            sendData(ref data);
        }

    }
}