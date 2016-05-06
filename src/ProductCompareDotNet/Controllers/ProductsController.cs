using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ProductCompareDotNet.Models;
using Microsoft.AspNet.Authorization;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace ProductCompareDotNet.Controllers
{
    public class ProductsController : Controller
    {
        private ProductCompareDbContext db = new ProductCompareDbContext();

        private readonly ProductCompareDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProductsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ProductCompareDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

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
        public async Task <IActionResult> LeaveComment(string Comment, string ProdId, bool like)
        {
            Comment comment = new Comment();
            comment.Statement = Request.Form["Comment"];
            comment.ProductId = Int32.Parse(Request.Form["ProdId"]);
            comment.Like = like;
            var user = await _userManager.FindByIdAsync(User.GetUserId());
            comment.User = user;
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("ProductList", "Products", new { id = comment.ProductId });

        }

        [HttpPost]
        public IActionResult Downvote(int id)
        {
            Console.WriteLine("ID?: " + id);

            var foundProduct = db.Products.FirstOrDefault(x => x.ProductId == id);
            foundProduct.ProductDownVotes = foundProduct.ProductDownVotes - 1;
            db.SaveChanges();
            return Json(foundProduct);
        }
        [HttpPost]
        public IActionResult Upvote(int id)
        {
            var foundProduct = db.Products.FirstOrDefault(x => x.ProductId == id);
            foundProduct.ProductUpVotes = foundProduct.ProductUpVotes + 1;
            db.SaveChanges();
            return Json(foundProduct);
        }

    }
}
