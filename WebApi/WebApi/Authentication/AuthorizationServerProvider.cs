using Business.Identity.Models;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Authentication
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async  Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                using (AuthRepository _repo = new AuthRepository())
                {
                    DubaiCultureUser user = await _repo.FindUser(context.UserName, context.Password);

                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                        return;
                    }
                    ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                    identity.AddClaim(new Claim(ClaimTypes.Role, string.Join(",", user.Roles)));
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName));
                    context.Validated(identity);
                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }
}