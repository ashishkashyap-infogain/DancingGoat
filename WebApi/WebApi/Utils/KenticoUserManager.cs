using Kentico.Membership;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models.Account;

namespace WebApi.Utils
{
    public class KenticoUserManager : KenticoUserManager<KenticoUser>, IKenticoUserManager<kenticoUser, int>
    {
        /// <summary>
        /// Creates a new instance of the class and configures its internals.
        /// </summary>
        /// <param name="medioClinicUserStore">User store passed onto the base class.</param>
        public KenticoUserManager(IKenticoUserStore kenticoUserStore) : base(kenticoUserStore)
        {
            PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequiredLength = 8,
                RequireLowercase = true,
                RequireNonLetterOrDigit = true,
                RequireUppercase = true
            };

            UserLockoutEnabledByDefault = false;
            EmailService = new EmailService();

            UserValidator = new UserValidator<KenticoUser, int>(this)
            {
                RequireUniqueEmail = true
            };

            // Registration: Confirmed registration
            UserTokenProvider = new EmailTokenProvider<KenticoUser, int>();
        }
    }
}