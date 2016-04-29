using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProductCompareDotNet.Models
{
    public class ProductCompareDbContext : IdentityDbContext<ApplicationUser>
    {


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)

        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProductCompareDotNet;integrated security = True");
        }



        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
