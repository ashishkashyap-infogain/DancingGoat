using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi.Authentication
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("CMSConnectionString")
        {

        }
    }
}