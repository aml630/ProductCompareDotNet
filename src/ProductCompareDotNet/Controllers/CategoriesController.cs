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
    public class CategoriesController : Controller
    {
        private ProductCompareDbContext db = new ProductCompareDbContext();

        public IActionResult Index()
        {
            return View(db.Products.Include(product => product.Reviews).ToList());
        }

        public IActionResult PriceSort()
        {
            var ProductList = db.Products.Include(product => product.Reviews).ToList();
            var newList = ProductList.OrderByDescending(product => product.ProductPrice).ToList();
            return View("Index", newList);
        }
        public IActionResult DateSort()
        {
            var ProductList = db.Products.Include(product => product.Reviews).ToList();
            var newList = ProductList.OrderBy(product => product.DateTime).ToList();            
            return View("Index", newList);
        }
        public IActionResult ReviewSort()
        {
            var ProductList = db.Products.Include(product => product.Reviews).ToList();
            var newList = ProductList.OrderByDescending(product => product.Reviews.Count()).ToList();
            return View("Index", newList);
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
        public IActionResult CreateProduct(string Name, string Upvotes, string DownVotes)
        {



            var client = new RestClient("http://api.walmartlabs.com/v1");

            var request = new RestRequest("search", Method.GET);

            request.AddParameter("query", Name);
            request.AddParameter("format", "json");
            request.AddParameter("apikey", "k2waftsef676thk9khfnevds");


            var response = client.Execute(request);


            //JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response.Content);

            dynamic stuff = JObject.Parse(response.Content);


            Console.WriteLine(stuff.items[0].name);


            //Console.WriteLine(jsonResponse["itemId"]);


            Category category = new Category();
            category.CategoryName = "firstCategory";
            db.Categories.Add(category);

            db.SaveChanges();

            Product product = new Product();
            product.ProductName = stuff.items[0].name;
            product.ProductImg = stuff.items[0].thumbnailImage;
            product.ProductPrice = stuff.items[0].salePrice;
            product.DateTime = DateTime.Now;

            product.CategoryId = category.CategoryId;
            int id = Int32.Parse(Request.Form["CatId"]);

            db.Products.Add(product);

            db.SaveChanges();


            return RedirectToAction("Index", "Categories");
        }
    }
}
