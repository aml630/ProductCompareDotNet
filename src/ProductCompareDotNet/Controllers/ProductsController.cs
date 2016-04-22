using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ProductCompareDotNet.Models;


namespace ProductCompareDotNet.Controllers
{
    public class ProductsController : Controller
    {
        private ProductCompareDbContext db = new ProductCompareDbContext();

        public IActionResult Index()
        {
            return View(db.Products.Include(product => product.Comments).ToList());
        }


        public IActionResult ProductList(int id)
        {
            var prodList = db.Products.Where(x => x.ProductId == id).Include(product => product.Comments).ToList();

            return View(prodList);
        }

         public IActionResult CreateRoute()
        {
            return View();
        }
        [HttpPost, ActionName("CreateRoute")]
        public IActionResult CreateCategory(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
