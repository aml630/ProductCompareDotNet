using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ProductCompareDotNet.Models;
using Microsoft.Data.Entity;

//What signals that you should definitely be using a viewbag
//Why do i type "Account" instead of "AccountController" in links/rotues

namespace ProductCompareDotNet.Controllers
{
    public class CategoriesController : Controller
    {
        private ProductCompareDbContext db = new ProductCompareDbContext();

        public IActionResult Index()
        {
            return View(db.Categories.Include(category => category.Products).ToList());
        }

        public IActionResult CategoryList(int id)
        {
            var catList = db.Categories.Where(x => x.CategoryId == id).Include(category => category.Products).ToList();

            return View(catList);
        }

        public IActionResult CreateRoute()
        {
            return View();
        }
        [HttpPost, ActionName("CreateRoute")]
        public IActionResult CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
