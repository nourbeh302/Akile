using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akile.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_RestaurantId",
                table: "Items",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Restaurant_RestaurantId",
                table: "Items",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Restaurant_RestaurantId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Items_RestaurantId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Items");
        }
    }
}
