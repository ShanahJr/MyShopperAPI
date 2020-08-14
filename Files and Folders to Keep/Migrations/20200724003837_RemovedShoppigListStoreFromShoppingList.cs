using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShopperAPI.Migrations
{
    public partial class RemovedShoppigListStoreFromShoppingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingListStore_ShoppingList_ShoppingListId",
                table: "ShoppingListStore");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListStore_ShoppingListId",
                table: "ShoppingListStore");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingListName",
                table: "ShoppingList",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "ShoppingList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_StoreId",
                table: "ShoppingList",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Store_StoreId",
                table: "ShoppingList",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "StoreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Store_StoreId",
                table: "ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingList_StoreId",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "ShoppingList");

            migrationBuilder.AlterColumn<string>(
                name: "ShoppingListName",
                table: "ShoppingList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListStore_ShoppingListId",
                table: "ShoppingListStore",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListStore_ShoppingList_ShoppingListId",
                table: "ShoppingListStore",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "ShoppingListId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
