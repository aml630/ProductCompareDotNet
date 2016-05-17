using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCompareDotNet.Models
{
    [Table("SubCategories")]
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public SubCategory(string catName, int id = 0)
        {
            SubCategoryName = catName;
            SubCategoryId = id;
        }
        public SubCategory()
        {

        }
    }
}
