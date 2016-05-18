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
using System.Globalization;

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
            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
           

            var prodList = db.Products.Where(x => x.ProductId == id).Include(product => product.Reviews).ThenInclude(review => review.User).Include(product => product.Questions).ThenInclude(question => question.User).Include(product => product.Questions).ThenInclude(question => question.Answers).ToList();

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
        public async Task<IActionResult> LeaveReview(string ReviewText, string rating, string ProdId)
        {
            Review review = new Review();
            review.ReviewText = ReviewText;
            //review.ProductId = int.Parse(Request.Form["ProdId"]);
            review.ProductId = int.Parse(ProdId);
            review.Stars = int.Parse(rating);
            review.DateTime = DateTime.Now;

            var user = await _userManager.FindByIdAsync(User.GetUserId());
            review.User = user;
            review.UserId = User.GetUserId();
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

        ///////////////////////Like Dislike Functions

        public IActionResult SetUpTrue(int id)
        {      
            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
            findProd.SetUpTrue = findProd.SetUpTrue + 1;
            db.SaveChanges();
            string NewSetUpTrue = findProd.SetUpTrue.ToString();
            return Content(NewSetUpTrue, "text/plain");
        }

        public IActionResult SetUpFalse(int id)
        {
            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
            findProd.SetUpFalse = findProd.SetUpFalse + 1;
            db.SaveChanges();
            string NewSetUpFalse = findProd.SetUpFalse.ToString();
            return Content(NewSetUpFalse, "text/plain");
        }

        public IActionResult EasyUseTrue(int id)
        {
            Console.WriteLine("Server");
            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
            findProd.EasyUseTrue = findProd.EasyUseTrue + 1;
            db.SaveChanges();
            string New = findProd.EasyUseTrue.ToString();
            return Content(New, "text/plain");
        }

        public IActionResult EasyUseFalse(int id)
        {
            Console.WriteLine("Server");

            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
            findProd.EasyUseFalse = findProd.EasyUseFalse + 1;
            db.SaveChanges();
            string NewSetUpFalse = findProd.EasyUseFalse.ToString();
            return Content(NewSetUpFalse, "text/plain");
        }

        public IActionResult GoodValueTrue(int id)
        {
            Console.WriteLine("Server");
            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
            findProd.GoodValueTrue = findProd.GoodValueTrue + 1;
            db.SaveChanges();
            string New = findProd.GoodValueTrue.ToString();
            return Content(New, "text/plain");
        }

        public IActionResult GoodValueFalse(int id)
        {
            Console.WriteLine("Server");

            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
            findProd.GoodValueFalse = findProd.GoodValueFalse + 1;
            db.SaveChanges();
            string NewSetUpFalse = findProd.GoodValueFalse.ToString();
            return Content(NewSetUpFalse, "text/plain");
        }

        public IActionResult WouldSuggestTrue(int id)
        {
            Console.WriteLine("Server");
            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
            findProd.WouldSuggestTrue = findProd.WouldSuggestTrue + 1;
            db.SaveChanges();
            string New = findProd.WouldSuggestTrue.ToString();
            return Content(New, "text/plain");
        }

        public IActionResult WouldSuggestFalse(int id)
        {
            Console.WriteLine("Server");

            Product findProd = db.Products.FirstOrDefault(x => x.ProductId == id);
            findProd.WouldSuggestFalse = findProd.WouldSuggestFalse + 1;
            db.SaveChanges();
            string NewSetUpFalse = findProd.WouldSuggestFalse.ToString();
            return Content(NewSetUpFalse, "text/plain");
        }
    }
}
