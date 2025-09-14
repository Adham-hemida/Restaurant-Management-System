using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "019855ea-fef8-708d-ab80-da9e81d2325c", "019855ea-fef8-708d-ab80-da9f845c911f", false, "Admin", "ADMIN" },
                    { "019855ea-fef8-708d-ab80-daa013145d98", "019855ea-fef8-708d-ab80-daa156960d15", false, "Chef", "CHEF" },
                    { "01985a37-f9c5-7676-93c6-fd7259f4b646", "01985a37-f9c5-7676-93c6-fd73c880f710", false, "Waiter", "WAITER" },
                    { "01985a37-f9c5-7676-93c6-fd740ea964e2", "01985a37-f9c5-7676-93c6-fd75e1ce1428", false, "Cashier", "CASHIER" },
                    { "019948be-4497-7530-9afd-ef7f0538bcea", "019948be-4497-7530-9afd-ef80b4f7fcd0", false, "Manager", "MANAGER" },
                    { "019948be-4497-7530-9afd-ef81fb3b2312", "019948be-4497-7530-9afd-ef82debc832c", false, "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "orders:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 2, "permissions", "orders:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 3, "permissions", "orders:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 4, "permissions", "orders:toggleDelivered", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 5, "permissions", "orders:moveToTable", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 6, "permissions", "orderItems:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 7, "permissions", "orderItems:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 8, "permissions", "orderItems:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 9, "permissions", "orderItems:delete", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 10, "permissions", "tables:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 11, "permissions", "tables:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 12, "permissions", "tables:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 13, "permissions", "menuItems:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 14, "permissions", "menuItems:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 15, "permissions", "menuItems:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 16, "permissions", "menuItemRatings:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 17, "permissions", "menuItemRatings:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 18, "permissions", "menuItemRatings:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 19, "permissions", "menuCategories:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 20, "permissions", "menuCategories:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 21, "permissions", "menuCategories:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 22, "permissions", "invoices:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 23, "permissions", "invoices:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 24, "permissions", "invoices:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 25, "permissions", "files:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 26, "permissions", "users:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 27, "permissions", "users:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 28, "permissions", "users:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 29, "permissions", "roles:read", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 30, "permissions", "roles:add", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 31, "permissions", "roles:update", "019855ea-fef8-708d-ab80-da9e81d2325c" },
                    { 32, "permissions", "results:read", "019855ea-fef8-708d-ab80-da9e81d2325c" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "019855ea-fef8-708d-ab80-da9e81d2325c", "0198cd68-569b-7bbd-8049-2b9ac1504754" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019855ea-fef8-708d-ab80-daa013145d98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01985a37-f9c5-7676-93c6-fd7259f4b646");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01985a37-f9c5-7676-93c6-fd740ea964e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019948be-4497-7530-9afd-ef7f0538bcea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019948be-4497-7530-9afd-ef81fb3b2312");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "019855ea-fef8-708d-ab80-da9e81d2325c", "0198cd68-569b-7bbd-8049-2b9ac1504754" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "019855ea-fef8-708d-ab80-da9e81d2325c");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetRoles");
        }
    }
}
