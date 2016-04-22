using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ProductCompareDotNet.Migrations
{
    public partial class changeCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ProductName", table: "Categories");
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CategoryName", table: "Categories");
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Categories",
                nullable: true);
        }
    }
}
