﻿using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace _2301B2TempEmbedding.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string pass)
        {

            bool IsAuthenticated = false;
            ClaimsIdentity identity = null;

            if (email == "admin@gmail.com" && pass == "123")
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name ,"Haris"),
                    new Claim(ClaimTypes.Role ,"Admin"),
                }
               ,CookieAuthenticationDefaults.AuthenticationScheme);
                IsAuthenticated = true;
            }
            else if (email == "user@gmail.com" && pass == "123")
            {
                IsAuthenticated = true;
                identity = new ClaimsIdentity(new[]
               {
                    new Claim(ClaimTypes.Name ,"User1"),
                    new Claim(ClaimTypes.Role ,"User"),
                }
               , CookieAuthenticationDefaults.AuthenticationScheme);
            }
            else
            {
                IsAuthenticated = false;

            }
            if (IsAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();
            }
        }
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


    }
}
