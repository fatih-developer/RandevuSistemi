using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Data.Entity;
using RandevuSistemi.Models;

namespace RandevuSistemi.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                 return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError(String.Empty, "Kullanıcı Bulunamadı.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);


            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile");
            }

            ModelState.AddModelError(String.Empty, "Oturum Açılamadı.");
            return View(model);


        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AppUser user = new AppUser
            {
                UserName = model.Username,
                Name =  model.Name,
                Surname = model.LastName,
                Email = model.Email,
                Color = model.Color,
                IsDentist = model.IsDentist
            };

            IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;

            if (result.Succeeded)
            {
                bool roleCheck = model.IsDentist ? AddRole("Dentist") : AddRole("Secretary");

                if (!roleCheck)
                {
                    return View("Error");

                }

                _userManager.AddToRoleAsync(user, model.IsDentist ? "Dentist" : "Secretary").Wait();
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }

            return View();
        }

        private bool AddRole(string role)
        {
            if (!_roleManager.RoleExistsAsync(role).Result)
            {
                AppRole addrole = new AppRole {Name = role};

                IdentityResult result = _roleManager.CreateAsync(addrole).Result;

                return result.Succeeded;
            }

            return true;


        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();

            return RedirectToAction("Login", "Account");
        }


        public IActionResult Denied()
        {
            return View();
        }
    }
}
