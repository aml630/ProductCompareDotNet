using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ProductCompareDotNet.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public string ProductBigImg { get; set; }
        public string ProductLink { get; set; }
        public int ProductPrice { get; set; }

        public int SetUpTrue { get; set; }
        public int SetUpFalse { get; set; }

        public int EasyUseTrue { get; set; }
        public int EasyUseFalse { get; set; }

        public int GoodValueTrue { get; set; }
        public int GoodValueFalse { get; set; }

        public int WouldSuggestTrue { get; set; }
        public int WouldSuggestFalse { get; set; }

        public int CategoryId { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        //public Product(string productName, string productImg, string productBigImage, string productLink, int productPrice, int setUpTrue, int setUpFalse, int easyUseTrue, int easyUseFalse, int goodValueTrue, int goodValueFalse, int wouldSuggestTrue, int wouldSuggestFalse, int categoryId, DateTime datetime, int productId = 0)
        //{
        //    productName = ProductName;
        //    productImg = ProductImg;
        //    productBigImage = ProductBigImg;
        //    productLink = ProductLink;
        //    productPrice = ProductPrice;
        //    setUpTrue = SetUpTrue;
        //    setUpFalse = SetUpFalse;
        //    easyUseTrue = EasyUseTrue;
        //    easyUseFalse = EasyUseFalse;
        //    goodValueTrue = GoodValueTrue;
        //    goodValueFalse = GoodValueFalse;
        //    wouldSuggestTrue = WouldSuggestTrue;
        //    wouldSuggestFalse = WouldSuggestFalse;
        //    datetime = DateTime;
        //    categoryId = CategoryId;

        //}

        //public Product() { }



    }
}
