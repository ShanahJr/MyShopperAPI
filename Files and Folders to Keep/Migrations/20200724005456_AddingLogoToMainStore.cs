using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShopperAPI.Migrations
{
    public partial class AddingLogoToMainStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageTitle",
                table: "MainStore",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MainStoreLogo",
                table: "MainStore",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageTitle",
                table: "MainStore");

            migrationBuilder.DropColumn(
                name: "MainStoreLogo",
                table: "MainStore");
        }
    }
}
