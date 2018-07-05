using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Http;
using Volunteering.Domain.Dtos;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;
using Volunteering.Service.Identity;

namespace Volunteering.UI.Controllers_Api
{

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {

        //===========================//
        //--------- INIT ----------
        //===========================//

        private readonly UserService _userService = new UserService();

        //===========================//
        //--------- LOGIN ----------
        //===========================//


        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate/{email}/{password}")]
        // GET: api/Account
        public string Login(string email, string password)
        {
            //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(email), null);

            var result = _userService.SignInManager.PasswordSignIn(email, password, true, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return "LoginSucess";
                case SignInStatus.LockedOut:
                    return "LoginLockedOut";
                case SignInStatus.RequiresVerification:
                    return "LoginRequiresVerification";
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return "LoginInvalid";
            }
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("Login/{email}/{password}")]
        // GET: api/Account
        public IHttpActionResult LoginAndReturnUserDto(string email, string password)
        {

            var result = _userService.SignInManager.PasswordSignIn(email, password, true, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
                ApplicationUser user = _userService.UserManager.FindByEmail(email);
                UserDto loggedUser = new UserDto();

                AutoMapper.AutoMapUser(user, loggedUser);
                loggedUser.Role = _userService.GetUserRole(user);

                return Ok(loggedUser);
            }

            // return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "LoginFailed"));

            return Ok(new UserDto());
        }


        [Route("isUserAuth")]
        [HttpGet]
        public IHttpActionResult IsUserAuthenticated()
        {

            return Ok(User.Identity.IsAuthenticated);
        }

        //===========================//
        //--------- DATA ----------
        //===========================//

        [HttpGet]
        [Route("GetAllUsers")]
        // GET: api/Account
        public IEnumerable<string> GetAllUsers()
        {
            Thread.CurrentPrincipal.Identity.GetUserId();
            return new string[] { "value1", "value2" };
        }

        [Route("GetUser/{id}")]
        [AllowAnonymous]
        public IHttpActionResult GetUser(string id)
        {
            ApplicationUser user = _userService.UserManager.FindById(id);

            if (user != null)
            {
                UserDto userDto = new UserDto();

                AutoMapper.AutoMapUser(user, userDto);
                userDto.Role = _userService.GetUserRole(user);

                return Ok(userDto);
            }

            return NotFound();
        }


        [Route("getUsers")]
        // GET: api/Account
        public IEnumerable<ApplicationUser> GetAllUsersTest()
        {
            var users = _userService.UserManager.Users.ToList();
            return users;

        }



        [Route("getUserId")]
        [HttpGet]
        public string GetUserId()
        {
            /*string userId = User.Identity.GetUserId();*/

            string userId = Thread.CurrentPrincipal.Identity.GetUserId();

            if (userId != null)
            {
                return userId;
            }
            return "no";
        }


        [Route("getAppUserId")]
        [HttpGet]
        public string GetAppUserId()
        {


            return _userService.GetAppUserId();
        }


        //===========================//
        //--------- REGISTER ----------
        //===========================//

        [HttpGet]
        [HttpPost]
        [Route("register/{name}/{email}/{password}/{accountType}")]
        // POST: api/Account
        public string RegisterNewUser(string name, string email, string password, string accountType)
        {

            IdentityResult result = new IdentityResult();

            EAccountType type;
            if (Enum.TryParse(accountType, out type))
            {
                _userService.RegisterUser(name, email, password, type, ref result);
                if (result.Succeeded)
                {
                    return "RegistrationSuccess";
                }

                return "RegistrationFailed";
            }

            return "RegistrationFailed";
        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }



        //===========================//
        //--------- LOG OUT ---------
        //===========================//

        [HttpGet]
        [Route("Logout")]
        // POST: api/Account
        public void LogOut([FromBody]string value)
        {
            _userService.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

        }




    }
}
