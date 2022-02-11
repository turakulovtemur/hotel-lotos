﻿using hotelApplication.Models;
using hotelApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotelApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationContext context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            context = db;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber };
                // добавляем пользователя

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {                    
                    await _signInManager.SignInAsync(user, false); // установка куки
                    return RedirectToAction("Example", "Main");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {

            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            User user = await _userManager.FindByEmailAsync(model.Email); //находит пользователя по Email

            var item = await _userManager.GetRolesAsync(user);
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var userInRole = await _userManager.IsInRoleAsync(user, "admin");  //проверяет имеет ли пользователь указанную роль


                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl)) // проверяем, принадлежит ли URL приложению
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    
                    if (userInRole) //проверяет имеет ли пользователь указанную роль если да то на страницу админа
                    {
                        return RedirectToAction("AdminPage", "Main");
                    }
                    else
                    {
                        return RedirectToAction("Example", "Main");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Example", "Main");
        }

    }
}
