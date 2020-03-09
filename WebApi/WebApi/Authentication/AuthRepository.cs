using Business.Identity.Models;
using Kentico.Membership;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using WebApi.Models.Account;
using WebApi.Config;
using Microsoft.Owin.Security;
using Business.Identity;

namespace WebApi.Authentication
{
    public class AuthRepository : IDisposable
    {
        private readonly KenticoUserManager<DubaiCultureUser> _userManager;
        public KenticoSignInManager <DubaiCultureUser> _signInManager { get; }
        public IAuthenticationManager AuthenticationManager { get; }

        public AuthRepository()
        {
            _userManager = new KenticoUserManager<DubaiCultureUser>(new KenticoUserStore<DubaiCultureUser>(AppConfig.SiteName));
           // _signInManager = new KenticoSignInManager<KenticoUser>(_userManager, AuthenticationManager);
        }

        public async Task<IdentityResult> RegisterUser(RegisterModel userRegister)
        {
            KenticoUserManager<DubaiCultureUser> t = new KenticoUserManager<DubaiCultureUser>(new KenticoUserStore<DubaiCultureUser>(AppConfig.SiteName));
            DubaiCultureUser user = new DubaiCultureUser
            {
                UserName = userRegister.UserName,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                Email = userRegister.UserName,
                Enabled = true
            };

            IdentityResult result = await _userManager.CreateAsync(user, userRegister.Password);
            return result;
        }

        public async Task<DubaiCultureUser> GetUserByEmail(string email)
        {
            DubaiCultureUser user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<DubaiCultureUser> FindUser(string userName, string password)
        {
            DubaiCultureUser user = await _userManager.FindAsync(userName, password);
            return user;
        }
        public void Dispose()
        {
            _userManager.Dispose();
           //_signInManager.Dispose();
        }
    }
}