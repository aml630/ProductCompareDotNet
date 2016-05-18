using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ProductCompareDotNet.Models;

namespace ProductCompareDotNet.Migrations
{
    [DbContext(typeof(ProductCompareDbContext))]
    [Migration("20160518213849_difName")]
    partial class difName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerText");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("QuestionId");

                    b.Property<string>("UserId");

                    b.HasKey("AnswerId");

                    b.HasAnnotation("Relational:TableName", "Answers");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int?>("ProductProductId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("UserPic");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.HasAnnotation("Relational:TableName", "Categories");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("EasyUseFalse");

                    b.Property<int>("EasyUseTrue");

                    b.Property<int>("GoodValueFalse");

                    b.Property<int>("GoodValueTrue");

                    b.Property<string>("ProductBigImg");

                    b.Property<string>("ProductImg");

                    b.Property<string>("ProductLink");

                    b.Property<string>("ProductName");

                    b.Property<int>("ProductPrice");

                    b.Property<int>("SetUpFalse");

                    b.Property<int>("SetUpTrue");

                    b.Property<int>("SubCategoryId");

                    b.Property<int>("WouldSuggestFalse");

                    b.Property<int>("WouldSuggestTrue");

                    b.HasKey("ProductId");

                    b.HasAnnotation("Relational:TableName", "Products");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("ProductId");

                    b.Property<string>("QuestionText");

                    b.Property<string>("UserId");

                    b.HasKey("QuestionId");

                    b.HasAnnotation("Relational:TableName", "Questions");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("ProductId");

                    b.Property<string>("ReviewText");

                    b.Property<int>("Stars");

                    b.Property<string>("UserId");

                    b.HasKey("ReviewId");

                    b.HasAnnotation("Relational:TableName", "Reviews");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SubCategoryName");

                    b.HasKey("SubCategoryId");

                    b.HasAnnotation("Relational:TableName", "SubCategories");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProductCompareDotNet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProductCompareDotNet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("ProductCompareDotNet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Answer", b =>
                {
                    b.HasOne("ProductCompareDotNet.Models.Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.HasOne("ProductCompareDotNet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.ApplicationUser", b =>
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

                    b.HasOne("ProductCompareDotNet.Models.SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Question", b =>
                {
                    b.HasOne("ProductCompareDotNet.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("ProductCompareDotNet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProductCompareDotNet.Models.Review", b =>
                {
                    b.HasOne("ProductCompareDotNet.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("ProductCompareDotNet.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
