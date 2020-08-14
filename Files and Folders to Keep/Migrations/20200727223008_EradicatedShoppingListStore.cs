using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShopperAPI.Migrations
{
    public partial class EradicatedShoppingListStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListStore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingListStore",
                columns: table => new
                {
                    ShoppingListStoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListStore", x => x.ShoppingListStoreId);
                    table.ForeignKey(
                        name: "FK_ShoppingListStore_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListStore_StoreId",
                table: "ShoppingListStore",
                column: "StoreId");
        }
    }
}
