using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Books",
                table: "TbOrders");

            migrationBuilder.DropColumn(
                name: "Copies",
                table: "TbOrders");

            migrationBuilder.AlterColumn<string>(
                name: "CstomerName",
                table: "TbOrders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "TbBooks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbBooks_OrderId",
                table: "TbBooks",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbBooks_TbOrders_OrderId",
                table: "TbBooks",
                column: "OrderId",
                principalTable: "TbOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbBooks_TbOrders_OrderId",
                table: "TbBooks");

            migrationBuilder.DropIndex(
                name: "IX_TbBooks_OrderId",
                table: "TbBooks");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "TbBooks");

            migrationBuilder.AlterColumn<string>(
                name: "CstomerName",
                table: "TbOrders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Books",
                table: "TbOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Copies",
                table: "TbOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
