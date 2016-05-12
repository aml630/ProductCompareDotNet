using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCompareDotNet.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

    }

  
}
