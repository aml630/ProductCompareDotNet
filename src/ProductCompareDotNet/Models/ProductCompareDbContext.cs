using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
namespace ProductCompareDotNet.Models
{
    public class ProductCompareDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
