using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniWeb.Migrations
{
    /// <inheritdoc />
    public partial class addedstockimg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageType",
                table: "Stocks",
                newName: "LogoImageType");

            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "Stocks",
                newName: "LogoImageData");

            migrationBuilder.AddColumn<byte[]>(
                name: "AnalysisImageData",
                table: "Stocks",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnalysisImageType",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalysisImageData",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "AnalysisImageType",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "LogoImageType",
                table: "Stocks",
                newName: "ImageType");

            migrationBuilder.RenameColumn(
                name: "LogoImageData",
                table: "Stocks",
                newName: "ImageData");
        }
    }
}
