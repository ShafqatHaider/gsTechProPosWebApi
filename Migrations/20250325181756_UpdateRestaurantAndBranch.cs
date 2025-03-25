using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GsTechProPos.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRestaurantAndBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contactNo",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "contactNo",
                table: "Restaurants");
        }
    }
}
