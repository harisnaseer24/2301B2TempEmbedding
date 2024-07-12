using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Mvc;
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
    }
}
