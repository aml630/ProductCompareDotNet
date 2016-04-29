using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ProductCompareDotNet.Models
{
    //[Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Statement { get; set; }
        public int ProductId { get; set; }
        public bool Like { get; set; }
        public virtual Product Product { get; set; }
        //public virtual ApplicationUser User { get; set; }

    }
}
