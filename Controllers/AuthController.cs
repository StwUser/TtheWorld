using AspNetCoreWorld.Models;
using AspNetCoreWorld.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreWorld.Controllers
{
    public class AuthController : Controller
    {
        private SignInManager<WorldUser> _singInManager;

        public AuthController(SignInManager<WorldUser> signInManager)
        {
            _singInManager = signInManager;
        }
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Trips", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var singInResult = await _singInManager.PasswordSignInAsync(vm.Username,
                                                                            vm.Password,
                                                                            true, false);

                if (singInResult.Succeeded)
                {
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Trips", "App");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password incorrect");
                }
            }

            return View();
        }

        public async Task<ActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _singInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        }
    }
}
