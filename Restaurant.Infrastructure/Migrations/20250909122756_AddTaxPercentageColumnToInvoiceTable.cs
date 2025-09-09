using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTaxPercentageColumnToInvoiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TaxPercentage",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Invoices");
        }
    }
}
