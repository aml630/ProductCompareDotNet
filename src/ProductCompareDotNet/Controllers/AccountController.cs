using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using ProductCompareDotNet.Models;
using ProductCompareDotNet.ViewModels;
using System.Linq;
using System.Security.Principal;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNet.Http;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.Hosting;
using System;
using Microsoft.AspNet.Authorization;

namespace ProductCompareDotNet.Controllers
{
    public class AccountController : Controller
    {
        private readonly ProductCompareDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ProductCompareDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByIdAsync(User.GetUserId());
            ViewBag.Questions = _db.Questions.Where(x => x.User.Id == User.GetUserId());

            ViewBag.Reviews = _db.Reviews.Where(x => x.UserId == User.GetUserId());
            return View(user);

            //ViewBag.Products = _db.Products.Where(product => product.User.Id == User.GetUserId());
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.UserName };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
             
            }else
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        //public IActionResult FavoriteProduct(int productId)
        //{
        //    Product findProd = _db.Products.FirstOrDefault(x => x.ProductId == productId);
        //    findProd.FavUsers.Add(User.GetUserId());
        //    _db.SaveChanges();
        //    return Content("hey", "text/plain");
        //}
    }
}