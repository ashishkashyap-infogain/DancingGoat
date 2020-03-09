using Microsoft.AspNet.Identity;

using Business.Identity.Models;

namespace Business.Identity
{
    /// <summary>
    /// Wrapper around all ASP.NET Identity store interfaces supported in the app.
    /// </summary>
    public interface IMedioClinicUserStore :
        IUserPasswordStore<KenticoUser, int>,
        IUserLockoutStore<KenticoUser, int>,
        IUserTwoFactorStore<KenticoUser, int>,
        IUserRoleStore<KenticoUser, int>,
        IUserEmailStore<KenticoUser, int>,
        IUserLoginStore<KenticoUser, int>,
        IUserSecurityStampStore<KenticoUser, int>
    {
    }
}
