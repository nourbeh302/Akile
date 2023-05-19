using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akile.Migrations
{
    /// <inheritdoc />
    public partial class ModifyColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RestaurantName",
                table: "Restaurants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Restaurants",
                newName: "RestaurantName");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Orders",
                newName: "OrderDate");
        }
    }
}
