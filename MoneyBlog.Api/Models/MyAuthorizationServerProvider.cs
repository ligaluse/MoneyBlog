using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using MoneyBlog.DataLayer;
using MoneyBlog.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoneyBlog.Api.Models
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _userId;
        public MyAuthorizationServerProvider(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            _userId = userId;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (var obj = new DefaultConnection())
            {

                User entry = obj.Users.Where
                <User>(record =>
                record.Email == context.UserName &&
                record.Password == context.Password).FirstOrDefault();

                if (entry == null)
                {
                    context.SetError("invalid_grant",
                    "The user name or password is incorrect.");
                    return;
                }
            }

            // Optional : You can add a role based claim by uncommenting the line below.
            // identity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));


            ClaimsIdentity oAuthIdentity =
             new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(oAuthIdentity);
            ClaimsIdentity cookiesIdentity =
            new ClaimsIdentity(context.Options.AuthenticationType);
            cookiesIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            context.Validated(cookiesIdentity);
            AuthenticationProperties properties = CreateProperties(context.UserName);
            AuthenticationTicket ticket =
            new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }
       

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        
        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _userId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}
