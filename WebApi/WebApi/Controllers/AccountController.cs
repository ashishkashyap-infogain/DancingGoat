using Business.Identity.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Authentication;
using WebApi.Models;
using WebApi.Models.Account;

namespace WebApi.Controllers
{
    [RoutePrefix("Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<ResponseMessage> Register(RegisterModel registerModel)
        {
            IdentityResult result = new IdentityResult();
            try
            {
                result = await _repo.RegisterUser(registerModel);
                if (result.Succeeded)
                {
                    return new ResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Success = true,
                        Message = "User Registered Successfully",
                    };
                }
                else
                {
                    {
                        return new ResponseMessage
                        {
                            StatusCode = HttpStatusCode.OK,
                            Success = false,
                            Message = string.Join(",", result.Errors.ToArray()),
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        // POST api/Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]

        public async Task<IHttpActionResult> Login(LoginModel userModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //DubaiCultureUser result = await _repo.FindUser(userModel.UserName, userModel.Password);
            //return Ok();
            //using (AuthRepository _repo = new AuthRepository())
            //{
            //    DubaiCultureUser user = await _repo.FindUser(userModel.UserName, userModel.Password);
            //    ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //    identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            //    identity.AddClaim(new Claim(ClaimTypes.Role, string.Join(",", user.Roles)));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName));
            //    context.Validated(identity);
            //}
            return Ok();
        }

        [HttpGet]
        //[Authorize]
        [Route("GetCurrentUserByEmail")]

        public UserDetails<DubaiCultureUser> GetCurrentUserByEmail(string email)
        {
            Task<DubaiCultureUser> user = _repo.GetUserByEmail(email);
            return new UserDetails<DubaiCultureUser>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "User Details",
                User = user
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
