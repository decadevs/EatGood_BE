using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eat_Good_Data.Migrations
{
    /// <inheritdoc />
    public partial class AppuserToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_AppUserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_AppUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_AppUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Users_AppUserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_AppUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Users_AppUserId",
                table: "ShippingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_Users_AppUserId",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUser");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AppUser",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AppUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AppUser_AppUserId",
                table: "Carts",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AppUser_AppUserId",
                table: "Customers",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AppUser_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AppUser_AppUserId",
                table: "Ratings",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AppUser_AppUserId",
                table: "Reviews",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_AppUser_AppUserId",
                table: "ShippingAddresses",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_AppUser_AppUserId",
                table: "Vendors",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AppUser_AppUserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AppUser_AppUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AppUser_AppUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AppUser_AppUserId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AppUser_AppUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_AppUser_AppUserId",
                table: "ShippingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_AppUser_AppUserId",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "Users");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModified",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_AppUserId",
                table: "Carts",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_AppUserId",
                table: "Customers",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Users_AppUserId",
                table: "Ratings",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_AppUserId",
                table: "Reviews",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Users_AppUserId",
                table: "ShippingAddresses",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_Users_AppUserId",
                table: "Vendors",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
