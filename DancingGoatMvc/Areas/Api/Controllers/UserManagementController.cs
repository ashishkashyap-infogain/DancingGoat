using CMS.Membership;
using DancingGoat.Areas.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DancingGoat.Areas.Api.Controllers
{
    //[RoutePrefix("api/usermanagement/")]
    public class UserManagementController : ApiController
    {
        [System.Web.Http.Route("api/usermanagement/GetAllUsers")]
        //[Route("GetCurrentUser")]
        public List<UserData> GetAllUsers()
        {
            return UserInfoProvider.GetUsers()
                .AsEnumerable()
                .Select(x =>
                {
                    return new UserData()
                    {
                        Email = x.Email,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        LastName = x.LastName,
                        CreatedDate = x.UserCreated
                    };
                })
                .ToList();
        }


        [System.Web.Http.Route("api/GetCurrentUser")]
        //[Route("GetCurrentUser")]
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
                return null;
            }
        }

        [System.Web.Http.Route("api/usermanagement/GetUserInfoByUserId")]
        public UserDto GetUserInfoByUserId(int userId)
        {
            return UserData(UserInfoProvider.GetUserInfo(userId));
        }

        [System.Web.Http.Route("api/usermanagement/GetUserInfoByUserName")]
        public UserDto GetUserInfoByUserName(string userName)
        {
            return UserData(UserInfoProvider.GetUserInfo(userName));
        }

        [System.Web.Http.Route("api/usermanagement/GetUserInfoByUserGuid")]
        public UserDto GetUserInfoByUserGuid(Guid userGuidId)
        {
            return UserData(UserInfoProvider.GetUserInfoByGUID(userGuidId));
        }
        //[HttpPost]
        //[System.Web.Http.Route("api/usermanagement/Register")]
        //public HttpStatusCode Register(UserDto userDto)
        //{
        //    //RegisterController registerController = new RegisterController();
        //    //registerController.Register(userDto);
        //    return HttpStatusCode.OK;
        //}

        //[System.Web.Http.HttpPost]
        //[System.Web.Http.Route("api/usermanagement/Login")]
        //public HttpStatusCode Login(LoginViewModel model)
        //{
        //    RegisterController accountController = new RegisterController(mMembershipActivitiesLogger);
        //    if (model == null)
        //    {
        //        model = new LoginViewModel
        //        {
        //            UserName = "ashish",
        //            Password = "k1@3",
        //            StaySignedIn = true
        //        };
        //    }
        //    System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> data = accountController.Login(model, "");
        //    return HttpStatusCode.OK;
        //}
    }
}
