using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ProductCompareDotNet.Migrations
{
    public partial class commentBoolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Product_Category_CategoryId", table: "Products");
            migrationBuilder.AddColumn<bool>(
                name: "Like",
                table: "Comment",
                nullable: false,
                defaultValue: false);
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
            migrationBuilder.DropColumn(name: "Like", table: "Comment");
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
