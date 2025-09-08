using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveColumnToOrderItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: true);

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OrderItems");

          
        }
    }
}
