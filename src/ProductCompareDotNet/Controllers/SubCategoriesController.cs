using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ProductCompareDotNet.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Authorization;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace ProductCompareDotNet.Controllers
{
    public class SubCategoriesController : Controller
    {
        private ProductCompareDbContext db = new ProductCompareDbContext();

        public IActionResult Index()
        {
            var SubList = db.SubCategories.ToList();

            return View(SubList);
        }

        public IActionResult CompareProducts(int id)
        {
            var SubProds = db.SubCategories.Where(x => x.SubCategoryId == id).Include(subcat => subcat.Products).ToList();

            return View(SubProds);
        }


    }
}