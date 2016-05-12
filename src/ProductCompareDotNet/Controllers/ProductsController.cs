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
            //return View(db.Products.Include(product => product.Reviews).ToList());
            return View();
        }


        public IActionResult ProductList(int id)
        {
            var prodList = db.Products.Where(x => x.ProductId == id).Include(product => product.Reviews).ThenInclude(review => review.User).Include(product => product.Questions).ThenInclude(question => question.Answers).ToList();

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
        public async Task<IActionResult> LeaveReview(string Comment, string ProdId, int Stars)
        {
            Review review = new Review();
            review.ReviewText = Request.Form["Comment"];
            review.ProductId = Int32.Parse(Request.Form["ProdId"]);
            review.Stars = Stars;
            review.DateTime = DateTime.Now;

            var user = await _userManager.FindByIdAsync(User.GetUserId());
            review.User = user;
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("ProductList", "Products", new { id = review.ProductId });

        }

        [HttpPost]
        public async Task<IActionResult> AskQuestion(string Question, string ProdId)
        {
            Question question = new Question();
            question.QuestionText = Request.Form["Question"];
            question.ProductId = Int32.Parse(Request.Form["ProdId"]);
            question.DateTime = DateTime.Now;

            var user = await _userManager.FindByIdAsync(User.GetUserId());
            question.User = user;
            db.Questions.Add(question);
            db.SaveChanges();
            return RedirectToAction("ProductList", "Products", new { id = question.ProductId });

        }


        [HttpPost]
        public async Task<IActionResult> AnswerQuestion(string Question, string QuestionId, int ProductId)
        {
            Answer answer = new Answer();
            answer.AnswerText = Request.Form["Answer"];
            answer.QuestionId = Int32.Parse(Request.Form["QuestionId"]);
            answer.DateTime = DateTime.Now;

            var user = await _userManager.FindByIdAsync(User.GetUserId());
            answer.User = user;
            db.Answers.Add(answer);
            db.SaveChanges();
            return RedirectToAction("ProductList", "Products", new { id = ProductId });



        }
    }
}
