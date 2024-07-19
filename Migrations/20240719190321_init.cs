using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbBooks_OrderBooks_OrderId",
                table: "TbBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderBooks",
                table: "OrderBooks");

            migrationBuilder.RenameTable(
                name: "OrderBooks",
                newName: "TbOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbOrders",
                table: "TbOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbBooks_TbOrders_OrderId",
                table: "TbBooks",
                column: "OrderId",
                principalTable: "TbOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbBooks_TbOrders_OrderId",
                table: "TbBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbOrders",
                table: "TbOrders");

            migrationBuilder.RenameTable(
                name: "TbOrders",
                newName: "OrderBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderBooks",
                table: "OrderBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbBooks_OrderBooks_OrderId",
                table: "TbBooks",
                column: "OrderId",
                principalTable: "OrderBooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
