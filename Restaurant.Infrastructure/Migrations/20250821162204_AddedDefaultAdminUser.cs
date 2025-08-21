using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDisabled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0198cd68-569b-7bbd-8049-2b9ac1504754", 0, "0198cd6a-444d-74f0-bfb6-fcb0c5a76df4", "Admin@Restaurant_System.com", true, "Restaurant System", false, "Admin", false, null, "ADMIN@RESTAURANT_SYSTEM.COM", "ADMIN@RESTAURANT_SYSTEM.COM", "AQAAAAIAAYagAAAAEBTxnwAExcnIYmr/w9LZ98E+i7Esb0ofDxNsTFEeQfS9RsgmH50jJK4xuf27ZukPpw==", null, false, "0D4D736497244D628D7C32045E26BA51", false, "Admin@Restaurant_System.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0198cd68-569b-7bbd-8049-2b9ac1504754");
        }
    }
}
