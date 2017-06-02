using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TimetableServer
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private DataBase _db;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            _db = _db ?? new DataBase();
            bool existsAccount = _db.existsAccount(context.UserName, computeHash(context.Password));
            if (!existsAccount)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);

        }
        private string computeHash(string password)
        {
            var alghorithm = SHA256.Create();
            var result = alghorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(result).Substring(0, 32); ;
        }
    }
}