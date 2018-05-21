using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;
using Volunteering.Service.Identity;
using Volunteering.UI.Models;

namespace Volunteering.UI.Controllers
{
    public class AccountController : Controller
    {
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
        public async Task<ActionResult> Register(AccountViewModels.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userService = new UserService();
                IdentityResult result;

                // Switch on Selected Account type
                switch (model.AccountType)
                {
                    // Volunteer Account type selected:
                    case EAccountType.Volunteer:
                        {
                            // create new volunteer and map form values to the instance
                            Volunteer v = new Volunteer { UserName = model.Email, Email = model.Email };
                            result = await userService.UserManager.CreateAsync(v, model.Password);

                            // Add volunteer role to the new User
                            if (result.Succeeded)
                            {
                                userService.UserManager.AddToRole(v.Id, EAccountType.Volunteer.ToString());
                                return RedirectToAction("Index", "Home");
                            }
                            AddErrors(result);
                        }
                        break;

                    // Ngo Account type selected:
                    case EAccountType.Ngo:
                        {
                            // create new Ngo and map form values to the instance
                            Ngo ngo = new Ngo { UserName = model.Email, Email = model.Email };
                            result = await userService.UserManager.CreateAsync(ngo, model.Password);

                            // Add Ngo role to the new User
                            if (result.Succeeded)
                            {
                                userService.UserManager.AddToRole(ngo.Id, EAccountType.Ngo.ToString());
                                return RedirectToAction("Index", "Home");
                            }
                            AddErrors(result);
                        }
                        break;
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}