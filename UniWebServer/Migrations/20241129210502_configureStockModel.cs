using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniWebServer.Migrations
{
    /// <inheritdoc />
    public partial class configureStockModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Stocks_StockId",
                table: "StockHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockHistories",
                table: "StockHistories");

            migrationBuilder.RenameTable(
                name: "StockHistories",
                newName: "StockHistory");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistories_StockId",
                table: "StockHistory",
                newName: "IX_StockHistory_StockId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stocks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockHistory",
                table: "StockHistory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Name",
                table: "Stocks",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistory_Stocks_StockId",
                table: "StockHistory",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistory_Stocks_StockId",
                table: "StockHistory");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_Name",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockHistory",
                table: "StockHistory");

            migrationBuilder.RenameTable(
                name: "StockHistory",
                newName: "StockHistories");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistory_StockId",
                table: "StockHistories",
                newName: "IX_StockHistories_StockId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockHistories",
                table: "StockHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Stocks_StockId",
                table: "StockHistories",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
