using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCompareDotNet.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public int ProductId { get; set; }
        public int Stars { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
