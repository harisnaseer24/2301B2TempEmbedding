﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2301B2TempEmbedding.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("role") == "user")
            //{
            //    ViewBag.userEmail = HttpContext.Session.GetString("userEmail");
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Admin");
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

   
      
    }
}