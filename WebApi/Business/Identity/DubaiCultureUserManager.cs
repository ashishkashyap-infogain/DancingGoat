using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

using CMS.Helpers;
using CMS.Membership;
using Kentico.Membership;

using Business.Identity.Models;

namespace Business.Identity
{
    /// <summary>
    /// App-level implementation of the ASP.NET Identity <see cref="UserManager{TUser, TKey}"/> base class.
    /// </summary>

    // Hotfix-independent variant (begin)
    /* 
    public class DubaiCultureUserManager : UserManager<DubaiCultureUser, int>, IDubaiCultureUserManager<DubaiCultureUser, int>
    */
    // Hotfix-independent variant (end)

    // HF 12.0.34+ variant (begin)
    public class DubaiCultureUserManager : KenticoUserManager<DubaiCultureUser>, IDubaiCultureUserManager<DubaiCultureUser, int>
    // HF 12.0.34+ variant (end)
    {
        /// <summary>
        /// Creates a new instance of the class and configures its internals.
        /// </summary>
        /// <param name="DubaiCultureUserStore">User store passed onto the base class.</param>
        public DubaiCultureUserManager(IDubaiCultureUserStore DubaiCultureUserStore) : base(DubaiCultureUserStore)
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

            UserValidator = new UserValidator<DubaiCultureUser, int>(this)
            {
                RequireUniqueEmail = true
            };

            // Registration: Confirmed registration
            UserTokenProvider = new EmailTokenProvider<DubaiCultureUser, int>();
        }

        // Hotfix-independent variant (begin)
        /* 
        /// <summary>
        /// Updates the user password.
        /// </summary>
        /// <param name="passwordStore">Unused implementation of UserPasswordStore.</param>
        /// <param name="user">User.</param>
        /// <param name="newPassword">New password in plain text format.</param>
        /// <returns><see cref="IdentityResult.Failed(string[])"/> if the new password is either <see langword="null"/>, empty, or not valid. Otherwise <see cref="IdentityResult.Success"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="user"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="newPassword"/> is either <see langword="null"/> or empty.</exception>
        protected override async Task<IdentityResult> UpdatePassword(IUserPasswordStore<DubaiCultureUser, int> passwordStore, DubaiCultureUser user, string newPassword)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                throw new ArgumentException($"The {nameof(newPassword)} argument must not be null or empty.");
            }

            var result = await PasswordValidator.ValidateAsync(newPassword);

            if (!result.Succeeded)
            {
                return result;
            }

            UserInfo userInfo = UserInfoProvider.GetUserInfo(user.Id);

            if (userInfo == null)
            {
                user.GUID = Guid.NewGuid();

                // Don't change the way the passwords are hashed once the app is released in production.
                user.PasswordHash = UserInfoProvider.GetPasswordHash(newPassword, UserInfoProvider.NewPasswordFormat, user.GUID.ToString());
            }
            else
            {
                UserInfoProvider.SetPassword(userInfo, newPassword);
                user.PasswordHash = ValidationHelper.GetString(userInfo.GetValue("UserPassword"), string.Empty);
                await UpdateSecurityStampInternalAsync(user);
            }

            return IdentityResult.Success;
        }

        /// <summary>
        /// Verifies the user password.
        /// </summary>
        /// <param name = "store" > Unused implementation of UserPasswordStore.</param>
        /// <param name = "user" > User.</ param >
        /// < param name= "password" > Password in plain text format.</param>
        /// <returns><see langword = "true" /> if <paramref name = "password" /> matches the one in the database. Otherwise<see langword="false"/>.</returns>
        protected override Task<bool> VerifyPasswordAsync(IUserPasswordStore<DubaiCultureUser, int> store, DubaiCultureUser user, string password)
        {
            if (user == null)
            {
                return Task.FromResult(false);
            }

            var userInfo = UserInfoProvider.GetUserInfo(user.UserName);
            var result = !userInfo.IsExternal && !userInfo.UserIsDomain && !UserInfoProvider.IsUserPasswordDifferent(userInfo, password);

            return Task.FromResult(result);
        }

        /// <summary>
        /// Updates the security stamp if the store supports it.
        /// </summary>
        /// <param name="user">User whose stamp should be updated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="user"/> is <see langword="null"/>.</exception>
        internal async Task UpdateSecurityStampInternalAsync(DubaiCultureUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (SupportsUserSecurityStamp)
            {
                await GetSecurityStore()?.SetSecurityStampAsync(user, NewSecurityStamp());
            }
        }

        private IUserSecurityStampStore<DubaiCultureUser, int> GetSecurityStore()
        {
            var cast = Store as IUserSecurityStampStore<DubaiCultureUser, int>;

            if (cast == null)
            {
                throw new NotSupportedException("Current Store does not implement the IUserSecurityStore interface.");
            }

            return cast;
        }

        private string NewSecurityStamp() =>
            Guid.NewGuid().ToString();
        */
        // Hotfix-independent variant (end)
    }
}
