using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2301B2TempEmbedding.Controllers
{
    public class HomeController : Controller
    {
        private readonly FoodContext _db;
        public HomeController(FoodContext db)
        {
            _db = db;
        }
       
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
        [Authorize(Roles ="Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Products()
        {
            var ItemsData = _db.Items.Include(p => p.Cat);
            return View(ItemsData);
        }
        public IActionResult Details(int id)
        {
            var ItemsData = _db.Items.FirstOrDefault(a => a.Id == id);
            if (ItemsData !=null)
            {

            return View(ItemsData);
            }
            else
            {
                return RedirectToAction("Products");
            }
        }



    }
}