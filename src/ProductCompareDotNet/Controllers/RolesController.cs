
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Http.Internal;
using ProductCompareDotNet.Models;
using Microsoft.Data.Entity;
using System.Diagnostics;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Authorization;

namespace ProductCompareDotNet.Controllers
{
    public class RolesController : Controller
    {
        private readonly ProductCompareDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RolesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ProductCompareDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Roles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string RoleName)
        {
            try
            {
                _db.Roles.Add(new IdentityRole() { Name = RoleName });
                _db.SaveChanges();
                //ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //[Authorize]
        public ActionResult Delete(string RoleName)
        {
            var thisRole = _db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _db.Roles.Remove(thisRole);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ManageUserRoles()
        {
            var list = _db.Roles.OrderBy(x => x.Name).ToList().Select(xx => new SelectListItem { Value = xx.Name.ToString(), Text = xx.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleAddToUser(string UserName, string RoleName)
        {
            //Async method requires Task which means that await is required on result

            ApplicationUser user = _db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var result = await _userManager.AddToRoleAsync(user, RoleName);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = _db.Users
                   .Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                ViewBag.RolesForThisUser = _userManager.GetRolesAsync(user).Result;

                var list = _db.Roles
                    .OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();

                ViewBag.Roles = list;

            }
            return View("ManageUserRoles");

        }
    }
}
