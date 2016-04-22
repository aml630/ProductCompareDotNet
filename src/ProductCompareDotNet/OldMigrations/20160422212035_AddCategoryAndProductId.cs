using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ProductCompareDotNet.Migrations
{
    public partial class AddCategoryAndProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Product_Category_CategoryCategoryId", table: "Products");
            migrationBuilder.DropColumn(name: "CategoryCategoryId", table: "Products");
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Comment",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Product_Category_CategoryId", table: "Products");
            migrationBuilder.DropColumn(name: "CategoryId", table: "Products");
            migrationBuilder.DropColumn(name: "ProductId", table: "Comment");
            migrationBuilder.AddColumn<int>(
                name: "CategoryCategoryId",
                table: "Products",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryCategoryId",
                table: "Products",
                column: "CategoryCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
