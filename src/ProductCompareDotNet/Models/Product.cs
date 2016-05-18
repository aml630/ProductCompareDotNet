using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

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
        public int SubCategoryId { get; set; }

        public DateTime DateTime { get; set; }
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        //public virtual ICollection<ApplicationUser> Users { get; set; }



        public string getPercent(int num1, int num2)
        {

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.PercentDecimalDigits = 0;

            decimal firstNum = (decimal)(num1 / (decimal)(num2 + num1 + .0001));
            string endNum = firstNum.ToString("P", nfi);

            return endNum;
        }
    


    }
}
