using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ProductCompareDotNet.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Authorization;


//how can i print out the user name of the person who posted the within the product controller?
//how do i sort children after .include?

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


            ViewBag.CatId = id;

            return View(catList);
        }

        public IActionResult CreateRoute()
        {
            return View();
        }
        //[Authorize]
        [HttpPost, ActionName("CreateRoute")]
        public IActionResult CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AjaxCreateCategory(string catName)
        {
            Category newCat = new Category(catName);
            db.Categories.Add(newCat);
            db.SaveChanges();
            return Json(catName);
        }

        //[Authorize]
        [HttpPost]
        public IActionResult CreateProduct(string Name, string Upvotes, string DownVotes, string CatId)
        {

            Product product = new Product();
            product.ProductName = Request.Form["Name"];
            product.ProductUpVotes = 5;
            product.ProductDownVotes = 5;
            product.CategoryId = Int32.Parse(Request.Form["CatId"]);
            int id = Int32.Parse(Request.Form["CatId"]);

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }
    }
}
