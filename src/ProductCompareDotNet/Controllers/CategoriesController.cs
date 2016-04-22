using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ProductCompareDotNet.Models;
using Microsoft.Data.Entity;

// How can i have a form on teh same page as my list??
// How does the form know what function to call on teh create page?
// What if I had more than one form and more than one function?
// What should i do if i have errors with my new changed migration?

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
