using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuditableAndAssignToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRatings_AspNetUsers_UserId",
                table: "MenuItemRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_AspNetUsers_UserId",
                table: "Tables");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tables",
                newName: "UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_UserId",
                table: "Tables",
                newName: "IX_Tables_UpdatedById");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                newName: "IX_Orders_CreatedById");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MenuItemRatings",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemRatings_UserId",
                table: "MenuItemRatings",
                newName: "IX_MenuItemRatings_CreatedById");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invoices",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                newName: "IX_Invoices_CreatedById");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "UploadedFiles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UploadedFiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "UploadedFiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "UploadedFiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Tables",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Tables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Tables",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "OrderItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "OrderItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "MenuItems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "MenuItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "MenuItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuItemRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "MenuItemRatings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "MenuItemRatings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "MenuCategorys",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MenuCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "MenuCategorys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "MenuCategorys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_CreatedById",
                table: "UploadedFiles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UpdatedById",
                table: "UploadedFiles",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_CreatedById",
                table: "Tables",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UpdatedById",
                table: "Orders",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CreatedById",
                table: "OrderItems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UpdatedById",
                table: "OrderItems",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CreatedById",
                table: "MenuItems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_UpdatedById",
                table: "MenuItems",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemRatings_UpdatedById",
                table: "MenuItemRatings",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategorys_CreatedById",
                table: "MenuCategorys",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategorys_UpdatedById",
                table: "MenuCategorys",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UpdatedById",
                table: "Invoices",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_CreatedById",
                table: "Invoices",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UpdatedById",
                table: "Invoices",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategorys_AspNetUsers_CreatedById",
                table: "MenuCategorys",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuCategorys_AspNetUsers_UpdatedById",
                table: "MenuCategorys",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRatings_AspNetUsers_CreatedById",
                table: "MenuItemRatings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRatings_AspNetUsers_UpdatedById",
                table: "MenuItemRatings",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_AspNetUsers_CreatedById",
                table: "MenuItems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_AspNetUsers_UpdatedById",
                table: "MenuItems",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_AspNetUsers_CreatedById",
                table: "OrderItems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_AspNetUsers_UpdatedById",
                table: "OrderItems",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedById",
                table: "Orders",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UpdatedById",
                table: "Orders",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_AspNetUsers_CreatedById",
                table: "Tables",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_AspNetUsers_UpdatedById",
                table: "Tables",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_AspNetUsers_CreatedById",
                table: "UploadedFiles",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_AspNetUsers_UpdatedById",
                table: "UploadedFiles",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_CreatedById",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UpdatedById",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategorys_AspNetUsers_CreatedById",
                table: "MenuCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuCategorys_AspNetUsers_UpdatedById",
                table: "MenuCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRatings_AspNetUsers_CreatedById",
                table: "MenuItemRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemRatings_AspNetUsers_UpdatedById",
                table: "MenuItemRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_AspNetUsers_CreatedById",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_AspNetUsers_UpdatedById",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_AspNetUsers_CreatedById",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_AspNetUsers_UpdatedById",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UpdatedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_AspNetUsers_CreatedById",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_AspNetUsers_UpdatedById",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_AspNetUsers_CreatedById",
                table: "UploadedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_AspNetUsers_UpdatedById",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_CreatedById",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_UpdatedById",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_Tables_CreatedById",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UpdatedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CreatedById",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_UpdatedById",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CreatedById",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_UpdatedById",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemRatings_UpdatedById",
                table: "MenuItemRatings");

            migrationBuilder.DropIndex(
                name: "IX_MenuCategorys_CreatedById",
                table: "MenuCategorys");

            migrationBuilder.DropIndex(
                name: "IX_MenuCategorys_UpdatedById",
                table: "MenuCategorys");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UpdatedById",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MenuItemRatings");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "MenuItemRatings");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "MenuItemRatings");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MenuCategorys");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MenuCategorys");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "MenuCategorys");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "MenuCategorys");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "Tables",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tables_UpdatedById",
                table: "Tables",
                newName: "IX_Tables_UserId");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "MenuItemRatings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemRatings_CreatedById",
                table: "MenuItemRatings",
                newName: "IX_MenuItemRatings_UserId");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "Invoices",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_CreatedById",
                table: "Invoices",
                newName: "IX_Invoices_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemRatings_AspNetUsers_UserId",
                table: "MenuItemRatings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_AspNetUsers_UserId",
                table: "Tables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
