﻿using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Mvc;

namespace _2301B2TempEmbedding.Controllers
{
    public class UserController : Controller
    {
        FoodContext db = new FoodContext();
        public IActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User u1)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(u1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

            return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var User = db.Users.Find(id);
            return View(User);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(User abc)
        {
            if (ModelState.IsValid)
            {
                db.Users.Update(abc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var User = db.Users.Find(id);
            return View(User);
        }
        [HttpPost]
        public IActionResult Delete(User del)
        {
            
                db.Users.Remove(del);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
        }

    }

