using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ProductCompareDotNet.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductUpVotes { get; set; }
        public int ProductDownVotes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
