using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2301B2TempEmbedding.Controllers
{
    public class ItemController : Controller
    {
        //FoodContext db = new FoodContext();
        private readonly FoodContext _db;
        public ItemController(FoodContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ItemsData = _db.Items.Include(p =>  p.Cat);
            return View(ItemsData);
        }

        public IActionResult Create()
        {
            ViewBag.CatId = new SelectList(_db.Categories, "CatId", "CatName");

           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item, IFormFile file)
        {
            var imageName = DateTime.Now.ToString("yymmddhhmmss");//24074455454454
            imageName += Path.GetFileName(file.FileName);//24074455454454apple.png

            string imagepath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Uploads");
            var imagevalue = Path.Combine(imagepath, imageName);

            using (var stream = new FileStream(imagevalue, FileMode.Create)) {

                file.CopyTo(stream);

            }

            var dbimage = Path.Combine("/Uploads",imageName);//   /uploads/240715343434apple.png
            item.Pimage = dbimage;

            _db.Items.Add(item);
            _db.SaveChanges();
            
            ViewBag.CatId = new SelectList(_db.Categories, "CatId","CatName");
            return RedirectToAction("Index");
        }

    }
}
