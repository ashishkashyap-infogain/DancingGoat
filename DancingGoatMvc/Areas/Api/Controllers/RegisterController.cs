using CMS.Activities.Loggers;
using CMS.EventLog;
using CMS.Membership;
using DancingGoat.Areas.Api.Dto;
using DancingGoat.Models.Account;
using Kentico.Membership;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DancingGoat.Areas.Api.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Api/Register
        public ActionResult Index()
        {
            return View();
        }
        private readonly IMembershipActivityLogger mMembershipActivitiesLogger;


        public UserManager UserManager => HttpContext.GetOwinContext().Get<UserManager>();


        public SignInManager SignInManager => HttpContext.GetOwinContext().Get<SignInManager>();


        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;


        public RegisterController(IMembershipActivityLogger membershipActivitiesLogger)
        {
            mMembershipActivitiesLogger = membershipActivitiesLogger;
        }


        // POST: Account/Register
        [HttpPost]
        [ValidateInput(false)]
        [Route("api/Register")]
        public async Task<JsonResult> Register(UserRegister userRegister)
        {
            User user = new User
            {
                UserName = userRegister.UserName,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                Email = userRegister.UserName,
                Enabled = true
            };
            IdentityResult registerResult = new IdentityResult();
            try
            {
                registerResult = await UserManager.CreateAsync(user, userRegister.Password);
                //IdentityResult result = await UserManager.CreateAsync(user, "");
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("RegisterController", "Register", ex);
                //ModelState.AddModelError(string.Empty, ResHelper.GetString("register_failuretext"));
            }
            ApiResponse<UserDto> data = new ApiResponse<UserDto>();
            if (registerResult.Succeeded)
            {
                data = new ApiResponse<UserDto>
                {
                    statusCode = HttpStatusCode.OK,
                    success = true,
                    message = "User Registered Successfully.",
                    data = UserData(UserInfoProvider.GetUserInfo(userRegister.UserName))
                };

            }
            else
            {
                data = new ApiResponse<UserDto>
                {
                    statusCode = HttpStatusCode.Unauthorized,
                    success = false,
                    message = ((string[])registerResult.Errors)[0],
                    data = null
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        [Route("api/login")]
        public async Task<JsonResult> LoginWithApi(LoginViewModel model, string returnUrl)
        {

            if (model == null)
            {
                model = new LoginViewModel
                {
                    UserName = "ashish",
                    Password = "k1@3",
                    StaySignedIn = true
                };
            }

            SignInStatus signInResult = SignInStatus.Failure;

            try
            {
                signInResult = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.StaySignedIn, false);
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("AccountController", "Login", ex);
            }
           var user= UserManager.FindByName(model.UserName);
            ApiResponse<UserDto> data = new ApiResponse<UserDto>();
            if (signInResult == SignInStatus.Success)
            {
                data = new ApiResponse<UserDto>
                {
                    statusCode = HttpStatusCode.OK,
                    success = true,
                    message = "User Login Successful.",
                    data = UserData(user)
                };

            }
            else
            {
                data = new ApiResponse<UserDto>
                {
                    statusCode = HttpStatusCode.Unauthorized,
                    success = false,
                    message = "Please verify username or passowrd",
                    data = null
                };
            }
            //return data;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [Route("api/GetCurrentUser")]
        public UserDto GetCurrentUser()
        {
            return UserData(MembershipContext.AuthenticatedUser);
        }
        public UserDto UserData(UserInfo userInfo)
        {
            if (userInfo != null)
            {
                return new UserDto()
                {
                    userID = userInfo.UserID,
                    userGUID = userInfo.UserGUID,
                    firstName = userInfo.FirstName,
                    lastName = userInfo.LastName,
                    middleName = userInfo.MiddleName,
                    enabled = userInfo.Enabled,
                    userName = userInfo.Email
                };
            }
            else
            {
                return new UserDto();
            }
        }
        public UserDto UserData(Kentico.Membership.User userInfo)
        {
            if (userInfo != null)
            {
                return new UserDto()
                {
                    userID = userInfo.Id,
                    userGUID = userInfo.GUID,
                    firstName = userInfo.FirstName,
                    lastName = userInfo.LastName,
                    middleName = string.Empty,
                    enabled = userInfo.Enabled,
                    userName = userInfo.Email
                };
            }
            else
            {
                return new UserDto();
            }
        }
    }
}