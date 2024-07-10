using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Mvc;

namespace _2301B2TempEmbedding.Controllers
{
    public class CustomController : Controller
    {
        FoodContext db = new FoodContext();
        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product abc)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(abc);
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
            var product=db.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product prd)
        {
            if (ModelState.IsValid)
            {
                db.Products.Update(prd);
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
            var product = db.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product prd)
        {
            db.Products.Remove(prd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
