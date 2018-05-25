using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Mvc;
using Volunteering.Service.Identity;
using Volunteering.UI.Models;

namespace Volunteering.UI.Controllers
{

    //TODO SendCode Action
    //TODO Lockout View

    public class AccountController : Controller
    {
        //===========================//
        //--------- INIT ----------
        //===========================//

        private readonly UserService _userService = new UserService();


        //===========================//
        //--------- LOGIN ----------
        //===========================//

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AccountViewModels.LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _userService.SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //===========================//
        //--------- LOG OUT ---------
        //===========================//

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _userService.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Logout
        [Authorize]
        public ActionResult Logout()
        {
            _userService.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //===========================//
        //--------- REGISTER --------
        //===========================//

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountViewModels.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                IdentityResult result = new IdentityResult();

                _userService.RegisterUser(model.Email, model.Password, model.AccountType, ref result);

                AddErrors(result);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }





        //===========================//
        //--------- HELPERS ---------
        //===========================//

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }









        // FOR REFERENCE
        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        // Send an email with this link
        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

        //// Switch on Selected Account type
        //switch (model.AccountType)
        //{
        //    // Volunteer Account type selected:
        //    case EAccountType.Volunteer:
        //        {
        //            // create new volunteer and map form values to the instance
        //            Volunteer v = new Volunteer { UserName = model.Email, Email = model.Email };
        //            result = await _userService.UserManager.CreateAsync(v, model.Password);

        //            // Add volunteer role to the new User
        //            if (result.Succeeded)
        //            {
        //                _userService.UserManager.AddToRole(v.Id, EAccountType.Volunteer.ToString());
        //                await _userService.SignInManager.SignInAsync(v, isPersistent: false, rememberBrowser: false);
        //                // Email confirmation here

        //                return RedirectToAction("Index", "Home");
        //            }
        //            AddErrors(result);
        //        }
        //        break;

        //    // Ngo Account type selected:
        //    case EAccountType.Ngo:
        //        {
        //            // create new Ngo and map form values to the instance
        //            Ngo ngo = new Ngo { UserName = model.Email, Email = model.Email };
        //            result = await _userService.UserManager.CreateAsync(ngo, model.Password);

        //            // Add Ngo role to the new User
        //            if (result.Succeeded)
        //            {
        //                _userService.UserManager.AddToRole(ngo.Id, EAccountType.Ngo.ToString());
        //                await _userService.SignInManager.SignInAsync(ngo, isPersistent: false, rememberBrowser: false);

        //                return RedirectToAction("Index", "Home");
        //            }
        //            AddErrors(result);
        //        }
        //        break;
        //}
    }
}