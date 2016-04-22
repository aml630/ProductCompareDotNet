using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ProductCompareDotNet.Models;

namespace ProductCompareDotNet.Migrations
{
    [DbContext(typeof(ProductCompareDbContext))]
    [Migration("20160422212035_AddCategoryAndProductId")]
    partial class AddCategoryAndProductId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductCompareDotNet.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.HasAnnotation("Relational:TableName", "Categories");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProductId");

                    b.Property<int?>("ProductProductId");

                    b.Property<string>("Statement");

                    b.HasKey("CommentId");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int>("ProductDownVotes");

                    b.Property<string>("ProductName");

                    b.Property<int>("ProductUpVotes");

                    b.HasKey("ProductId");

                    b.HasAnnotation("Relational:TableName", "Products");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Comment", b =>
                {
                    b.HasOne("ProductCompareDotNet.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductProductId");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Product", b =>
                {
                    b.HasOne("ProductCompareDotNet.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
