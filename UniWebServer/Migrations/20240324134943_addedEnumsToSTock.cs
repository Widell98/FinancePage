using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniWeb.Migrations
{
    /// <inheritdoc />
    public partial class addedEnumsToSTock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sector",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sector",
                table: "Stocks");
        }
    }
}
