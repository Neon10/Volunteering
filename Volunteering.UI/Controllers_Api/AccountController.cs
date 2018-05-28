using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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

        [Route("GetAllUsers")]
        // GET: api/Account
        public IEnumerable<string> GetAllUsers()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }


        [Route("getUsers")]
        // GET: api/Account
        public IEnumerable<ApplicationUser> GetAllUsersTest()
        {
            var users = _userService.UserManager.Users.ToList();
            return users;

        }

        [HttpGet]
        [Route("authenticate/{email}/{password}")]
        // GET: api/Account
        public string Login(string email, string password)
        {
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

        //===========================//
        //--------- REGISTER ----------
        //===========================//

        [HttpGet]
        [HttpPost]
        [Route("register/{email}/{password}/{accountType}")]
        // POST: api/Account
        public string RegisterNewUser(string email, string password, string accountType)
        {

            IdentityResult result = new IdentityResult();

            EAccountType type;
            if (Enum.TryParse(accountType, out type))
            {
                _userService.RegisterUser(email, password, type, ref result);
                if (result.Succeeded)
                {
                    return "Registration success !";
                }

                return "Registration failed";
            }

            return "Registration failed";
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
