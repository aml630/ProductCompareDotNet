using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ProductCompareDotNet.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCompareDotNet.Controllers
{
    public class CommentsController : Controller
    {
        private ProductCompareDbContext db = new ProductCompareDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateRoute()
        {
            return View();
        }

        [HttpPost, ActionName("CreateRoute")]
        public IActionResult CreateComment(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return RedirectToAction("CreateRoute");
        }
    }
}
