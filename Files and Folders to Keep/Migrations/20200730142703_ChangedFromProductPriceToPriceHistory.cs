using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShopperAPI.Migrations
{
    public partial class ChangedFromProductPriceToPriceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrice_Price_PriceId",
                table: "ProductPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrice_Product_ProductId",
                table: "ProductPrice");

            migrationBuilder.DropIndex(
                name: "IX_ProductPrice_PriceId",
                table: "ProductPrice");

            migrationBuilder.DropIndex(
                name: "IX_ProductPrice_ProductId",
                table: "ProductPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PriceCreationDate",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PriceCreationDate",
                table: "Product");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_PriceId",
                table: "ProductPrice",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductId",
                table: "ProductPrice",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrice_Price_PriceId",
                table: "ProductPrice",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "PriceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrice_Product_ProductId",
                table: "ProductPrice",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
