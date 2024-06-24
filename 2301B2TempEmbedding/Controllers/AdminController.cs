using _2301B2TempEmbedding.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2301B2TempEmbedding.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult Addprod()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addprod(Product prd)
        {
            if (ModelState.IsValid)
            {
                return Content("data is all good");
            }
            return View();
        }
    }
}
