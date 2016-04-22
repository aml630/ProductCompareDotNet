using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ProductCompareDotNet.Migrations
{
    public partial class FixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Items");
        }
    }
}
