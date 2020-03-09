using Microsoft.AspNet.Identity;

using Business.Identity.Models;

namespace Business.Identity
{
    /// <summary>
    /// Wrapper around all ASP.NET Identity store interfaces supported in the app.
    /// </summary>
    public interface IDubaiCultureUserStore :
        IUserPasswordStore<DubaiCultureUser, int>,
        IUserLockoutStore<DubaiCultureUser, int>,
        IUserTwoFactorStore<DubaiCultureUser, int>,
        IUserRoleStore<DubaiCultureUser, int>,
        IUserEmailStore<DubaiCultureUser, int>,
        IUserLoginStore<DubaiCultureUser, int>,
        IUserSecurityStampStore<DubaiCultureUser, int>
    {
    }
}
