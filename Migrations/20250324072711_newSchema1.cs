using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GsTechProPos.API.Migrations
{
    /// <inheritdoc />
    public partial class newSchema1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Restaurants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Restaurants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "restId",
                table: "Orders",
                newName: "TableNumber");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BranchId",
                table: "Orders",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Branch_BranchId",
                table: "Orders",
                column: "BranchId",
                principalTable: "Branch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_OwnerId",
                table: "Restaurants",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Branch_BranchId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Payments_OrderId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BranchId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Restaurants",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Restaurants",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TableNumber",
                table: "Orders",
                newName: "restId");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");
        }
    }
}
