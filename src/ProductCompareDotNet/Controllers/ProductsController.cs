using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ProductCompareDotNet.Models;
using Microsoft.AspNet.Authorization;

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

            ViewBag.ProdId = id;

            return View(prodList);
        }

        public IActionResult CreateRoute()
        {
            return View();
        }
        //[Authorize]
        [HttpPost, ActionName("CreateRoute")]
        public IActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult LeaveComment(string Comment, string ProdId)
        {
            Comment comment = new Comment();
            comment.Statement = Request.Form["Comment"];
            comment.ProductId = Int32.Parse(Request.Form["ProdId"]);
            comment.Like = true;
            return RedirectToAction("Index", "Home");

        }

    }
}
