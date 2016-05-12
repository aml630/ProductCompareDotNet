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


//how can i print out the user name of the person who posted the within the product controller?
//how do i sort children after .include?
//got rid of     //"dnxcore50": { } in frameowrks of project json.  will taht be bad?


namespace ProductCompareDotNet.Controllers
{
    public class CategoriesController : Controller
    {
        private ProductCompareDbContext db = new ProductCompareDbContext();

        public IActionResult Index()
        {
            return View(db.Products.Include(product => product.Comments).ToList());
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
            product.ProductUpVotes = 5;
            product.ProductDownVotes = 5;
            product.ProductPrice = stuff.items[0].salePrice;

            product.CategoryId = category.CategoryId;
            int id = Int32.Parse(Request.Form["CatId"]);

            db.Products.Add(product);

            db.SaveChanges();


            return RedirectToAction("Index", "Categories");
        }
    }
}
