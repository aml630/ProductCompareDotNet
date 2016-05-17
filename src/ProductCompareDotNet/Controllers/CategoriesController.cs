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
            ViewBag.Categories = db.Categories.ToList();

            return View(db.Products.Include(product => product.Reviews).ToList());
        }

        public IActionResult PriceSort()
        {
            return Sort("Price");
        }
        public IActionResult DateSort()
        {
            return Sort("Date");
        }
        public IActionResult ReviewSort()
        {
            return Sort("Review");
        }

        public IActionResult CategorySort(int catId)
        {
            return Sort("Category", catId);
        }

        public IActionResult Sort(string SortStuff, int catId = 0)
        {

            ViewBag.Categories = db.Categories.ToList();
            var ProductList = db.Products.Include(product => product.Reviews).ToList();
            List<Product> sortedList = new List<Product>();
            switch (SortStuff)
            {
                case "Price":
                    sortedList = ProductList.OrderByDescending(product => product.ProductPrice).ToList();
                    break;
                case "Date":
                    sortedList = ProductList.OrderBy(product => product.DateTime).ToList();
                    break;
                case "Review":
                    sortedList = ProductList.OrderByDescending(product => product.Reviews.Count()).ToList();
                    break;
                case "Category":
                    sortedList = db.Products.Where(x => x.CategoryId == catId).Include(product => product.Reviews).ToList();
                    break;

            }

            return View("Index", sortedList);

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

            dynamic stuff = JObject.Parse(response.Content);
            string baseString = stuff.items[0].categoryPath;
            int stop = baseString.IndexOf("/");
            string catName = baseString.Substring(0, stop);

            int index1 = baseString.LastIndexOf('/');
            string subCatName = baseString.Substring(index1 + 1);

            Product product = new Product();
            product.ProductName = stuff.items[0].name;
            product.ProductImg = stuff.items[0].thumbnailImage;
            product.ProductBigImg = stuff.items[0].largeImage;
            product.ProductLink = stuff.items[0].productUrl;

            product.ProductPrice = stuff.items[0].salePrice;
            product.DateTime = DateTime.Now;

            var test = db.Categories.FirstOrDefault(x => x.CategoryName == catName);
            if(test == null)
            {
                Category category = new Category();
                category.CategoryName = catName;
                db.Categories.Add(category);

                db.SaveChanges();
                product.CategoryId = category.CategoryId;

            }
            else
            {
                product.CategoryId = test.CategoryId;

            }

            var subCatTest = db.SubCategories.FirstOrDefault(x => x.SubCategoryName == subCatName);

            if (subCatTest == null)
            {
                SubCategory subCat = new SubCategory();
                subCat.SubCategoryName = subCatName;
                db.SubCategories.Add(subCat);

                db.SaveChanges();
                product.SubCategoryId = subCat.SubCategoryId;

            }
            else
            {
                product.SubCategoryId = subCatTest.SubCategoryId;

            }

            db.Products.Add(product);

            db.SaveChanges();

            return RedirectToAction("Index", "Categories");
        }
    }
}
