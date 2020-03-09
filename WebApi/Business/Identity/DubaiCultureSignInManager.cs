using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using Kentico.Membership;

using Business.Identity.Models;

namespace Business.Identity
{
    /// <summary>
    /// App-level implementation of the ASP.NET Identity <see cref="SignInManager{TUser, TKey}"/> base class.
    /// </summary>
    
    // Hotfix-independent variant (begin)
    /*
    public class DubaiCultureSignInManager : SignInManager<KenticoUser, int>, IDubaiCultureSignInManager<KenticoUser, int>
    */
    // Hotfix-independent variant (end)

    // HF 12.0.34+ variant (begin)
    public class DubaiCultureSignInManager : KenticoSignInManager<DubaiCultureUser>, IDubaiCultureSignInManager<DubaiCultureUser, int>
    // HF 12.0.34+ variant (end)
    {
        /// <summary>
        /// Makes the <see cref="UserManager{KenticoUser, int}"/> property accessible through the <see cref="IKenticoUserManager{KenticoUser, int}"/> interface.
        /// </summary>
        IDubaiCultureUserManager<DubaiCultureUser, int> IDubaiCultureSignInManager<DubaiCultureUser, int>.UserManager
        {
            get => UserManager as IDubaiCultureUserManager<DubaiCultureUser, int>;
            set => UserManager = value as UserManager<DubaiCultureUser, int>;
        }

        /// <summary>
        /// Creates the instance of <see cref="DubaiCultureSignInManager"/>.
        /// </summary>
        /// <param name="userManager">User manager.</param>
        /// <param name="authenticationManager">Authentication manager.</param>
        public DubaiCultureSignInManager(IDubaiCultureUserManager<DubaiCultureUser, int> userManager, IAuthenticationManager authenticationManager)
        : base(userManager as KenticoUserManager<DubaiCultureUser>, authenticationManager)
        {
        }
    }
}
