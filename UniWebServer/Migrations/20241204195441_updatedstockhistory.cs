using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniWebServer.Migrations
{
    /// <inheritdoc />
    public partial class updatedstockhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnalysisImagePath",
                table: "StockHistory",
                newName: "AnalysisImageType");

            migrationBuilder.AddColumn<byte[]>(
                name: "AnalysisImageData",
                table: "StockHistory",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalysisImageData",
                table: "StockHistory");

            migrationBuilder.RenameColumn(
                name: "AnalysisImageType",
                table: "StockHistory",
                newName: "AnalysisImagePath");
        }
    }
}
