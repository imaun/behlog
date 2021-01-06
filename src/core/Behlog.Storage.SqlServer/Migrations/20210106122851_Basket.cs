using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class Basket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WebsiteId",
                table: "Shop.Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "Shop.Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductModelTitle",
                table: "Shop.Orders",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Shop.Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WebsiteId",
                table: "Shop.Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WebsiteId",
                table: "Shop.Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    SessionId = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    CreatedFormUrl = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basket_Shop.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Shop.Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basket_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductTitle = table.Column<string>(nullable: true),
                    ProductModelId = table.Column<int>(nullable: true),
                    ProductModelTitle = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    UnitName = table.Column<string>(nullable: true),
                    DiscountValue = table.Column<decimal>(nullable: false),
                    TaxAmount = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItem_Basket_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Basket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItem_Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItem_Shop.Product_Models_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "Shop.Product_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Shop.Shippings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate", "Status" },
                values: new object[] { new DateTime(2021, 1, 6, 12, 28, 48, 80, DateTimeKind.Utc).AddTicks(478), new DateTime(2021, 1, 6, 12, 28, 48, 80, DateTimeKind.Utc).AddTicks(2508), 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 10,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 11,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 12,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 14,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 15,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 16,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 17,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 18,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 19,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 20,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 21,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 22,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 23,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 24,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 25,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 26,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 27,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 28,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 29,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 30,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 32,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 33,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 34,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 35,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 36,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 37,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 38,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 39,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 40,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 41,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 42,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 43,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 44,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 45,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 46,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 47,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 48,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 49,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 50,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 51,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 52,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 53,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 54,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 55,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 56,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 57,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 58,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 59,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 60,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 61,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 62,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 63,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 64,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 65,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 66,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 67,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 68,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 69,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 70,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 71,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 72,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 73,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 74,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 75,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 76,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 77,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 78,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 79,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 80,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 81,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 82,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 83,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 84,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 85,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 86,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 87,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 88,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 89,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 90,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 91,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 92,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 93,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 95,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 96,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 97,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 98,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 99,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 100,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 101,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 102,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 103,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 104,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 105,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 106,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 107,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 108,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 109,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 110,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 111,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 112,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 113,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 114,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 115,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 116,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 117,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 118,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 119,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 120,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 121,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 122,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 123,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 124,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 125,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 126,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 127,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 128,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 129,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 130,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 131,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 132,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 133,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 134,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 135,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 136,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 137,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 138,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 139,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 140,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 141,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 142,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 143,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 144,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 145,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 146,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 147,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 148,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 149,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 150,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 151,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 152,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 153,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 154,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 155,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 156,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 157,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 158,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 159,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 160,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 161,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 162,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 163,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 164,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 165,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 166,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 168,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 169,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 170,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 171,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 172,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 173,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 174,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 175,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 176,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 177,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 178,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 179,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 180,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 181,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 182,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 183,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 184,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 185,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 186,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 187,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 188,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 189,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 190,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 191,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 192,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 193,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 194,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 195,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 196,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 197,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 198,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 199,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 200,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 201,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 202,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 203,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 204,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 205,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 206,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 207,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 208,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 209,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 210,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 211,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 212,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 213,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 214,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 215,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 216,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 217,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 218,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 219,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 221,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 222,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 223,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 224,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 225,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 226,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 227,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 228,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 229,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 230,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 231,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 232,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 233,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 234,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 235,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 236,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 237,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 238,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 239,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 240,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 241,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 242,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 243,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 244,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 245,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 246,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 247,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 248,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 249,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 250,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 251,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 252,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 253,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 254,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 255,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 256,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 257,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 258,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 259,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 260,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 261,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 262,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 263,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 264,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 265,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 266,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 267,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 268,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 269,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 270,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 271,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 272,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 273,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 274,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 275,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 276,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 277,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 278,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 279,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 280,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 281,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 282,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 283,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 284,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 285,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 286,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 287,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 288,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 289,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 290,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 291,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 292,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 293,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 294,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 295,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 296,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 297,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 299,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 300,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 301,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 302,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 303,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 304,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 305,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 306,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 307,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 308,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 309,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 310,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 311,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 312,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 313,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 314,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 315,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 316,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 317,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 318,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 319,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 320,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 321,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 322,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 323,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 324,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 325,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 326,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 327,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 328,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 329,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 330,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 331,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 332,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 333,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 334,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 335,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 336,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 337,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 338,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 339,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 340,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 342,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 343,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 344,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 345,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 346,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 347,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 348,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 349,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 350,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 351,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 352,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 353,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 354,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 355,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 356,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 357,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 358,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 359,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 360,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 361,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 362,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 363,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 364,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 365,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 366,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 367,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 368,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 369,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 370,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 371,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 372,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 373,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 374,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 375,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 376,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 377,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 378,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 379,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 380,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 381,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 382,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 383,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 384,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 385,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 386,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 387,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 388,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 389,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 390,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 391,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 392,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 393,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 394,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 395,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 396,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 397,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 398,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 399,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 400,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 401,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 402,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 403,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 404,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 405,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 406,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 407,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 408,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 409,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 410,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 411,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 412,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 414,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 415,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 416,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 417,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 418,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 419,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 420,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 421,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 422,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 423,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 424,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 425,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 426,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 427,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 428,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 429,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 430,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 431,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 432,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 433,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 434,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 435,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 436,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 437,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 438,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 439,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 440,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 441,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 442,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 443,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 444,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 445,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 446,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 447,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 448,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 449,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 450,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 451,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 452,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 453,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 454,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 455,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 456,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 457,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 458,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 459,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 460,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 461,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 462,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 463,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 464,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 465,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 466,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 467,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 468,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 469,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 470,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 471,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 472,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 473,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 474,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 475,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 476,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 477,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 478,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 479,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 480,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 481,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 482,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 483,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 484,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 485,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 486,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 487,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 488,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 489,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 490,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 491,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 492,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 493,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 494,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 495,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 496,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 497,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 498,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 499,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 500,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 501,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 502,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 503,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 504,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 505,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 506,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 507,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 508,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 509,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 510,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 511,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 512,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 513,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 514,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 515,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 516,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 517,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 518,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 519,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 520,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 521,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 522,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 523,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 524,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 525,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 526,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 527,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 528,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 529,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 530,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 531,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 532,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 533,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 534,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 535,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 536,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 537,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 538,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 539,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 540,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 541,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 542,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 543,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 544,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 545,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 546,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 547,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 548,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 549,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 550,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 551,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 552,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 553,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 554,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 555,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 556,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 557,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 558,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 559,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 560,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 561,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 562,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 563,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 564,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 565,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 566,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 567,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 568,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 569,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 570,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 571,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 572,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 573,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 574,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 575,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 576,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 577,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 578,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 579,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 580,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 581,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 582,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 583,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 584,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 585,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 586,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 587,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 588,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 589,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 590,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 591,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 592,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 593,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 594,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 595,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 596,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 597,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 598,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 599,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 600,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 601,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 602,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 603,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 604,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 605,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 606,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 607,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 608,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 609,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 610,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 611,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 612,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 613,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 614,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 615,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 616,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 617,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 618,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 619,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 620,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 621,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 622,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 623,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 624,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 625,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 626,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 627,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 628,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 629,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 630,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 631,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 632,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 633,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 634,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 635,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 636,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 637,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 638,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 639,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 640,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 641,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 642,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 643,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 644,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 645,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 646,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 647,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 648,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 649,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 650,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 651,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 652,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 653,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 654,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 655,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 656,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 657,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 658,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 659,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 660,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 661,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 662,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 663,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 664,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 665,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 666,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 667,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 668,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 669,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 670,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 671,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 672,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 673,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 674,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 675,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 676,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 677,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 678,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 679,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 680,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 681,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 682,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 683,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 684,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 685,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 686,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 687,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 688,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 689,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 690,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 691,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 692,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 693,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 694,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 695,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 696,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 697,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 698,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 699,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 700,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 701,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 702,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 703,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 704,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 705,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 706,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 707,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 708,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 709,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 710,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 711,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 712,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 713,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 714,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 715,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 716,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 717,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 718,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 719,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 720,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 721,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 722,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 723,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 724,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 725,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 726,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 727,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 728,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 729,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 730,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 731,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 732,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 733,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 734,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 735,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 736,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 737,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 738,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 739,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 740,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 741,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 742,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 743,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 744,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 745,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 746,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 747,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 748,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 749,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 750,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 751,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 752,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 753,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 754,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 755,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 756,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 757,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 758,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 759,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 760,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 761,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 762,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 763,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 764,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 765,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 766,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 767,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 768,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 769,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 770,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 771,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 772,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 773,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 774,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 775,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 776,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 777,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 778,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 779,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 780,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 781,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 782,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 783,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 784,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 785,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 786,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 787,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 788,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 789,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 790,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 791,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 792,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 793,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 794,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 795,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 796,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 797,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 798,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 799,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 800,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 801,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 802,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 803,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 804,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 805,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 806,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 807,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 808,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 809,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 810,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 811,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 812,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 813,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 814,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 815,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 816,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 817,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 818,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 819,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 820,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 821,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 822,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 823,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 824,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 825,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 826,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 827,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 828,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 829,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 830,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 831,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 832,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 833,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 834,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 835,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 836,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 837,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 838,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 839,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 840,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 841,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 842,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 843,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 844,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 845,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 846,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 847,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 848,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 849,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 850,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 851,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 852,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 853,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 854,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 855,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 856,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 857,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 858,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 859,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 860,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 861,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 862,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 863,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 864,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 865,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 866,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 867,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 868,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 869,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 870,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 871,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 872,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 873,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 874,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 875,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 876,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 877,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 878,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 879,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 880,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 881,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 882,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 883,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 884,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 885,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 886,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 887,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 888,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 889,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 890,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 891,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 892,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 893,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 894,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 895,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 896,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 897,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 898,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 899,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 900,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 901,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 902,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 903,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 904,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 905,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 906,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 907,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 908,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 909,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 910,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 911,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 912,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 913,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 914,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 915,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 916,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 917,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 918,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 919,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 920,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 921,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 922,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 923,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 924,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 925,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 926,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 927,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 928,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 929,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 930,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 931,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 932,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 933,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 934,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 935,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 936,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 937,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 938,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 939,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 940,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 941,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 942,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 943,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 944,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 945,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 946,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 947,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 948,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 949,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 950,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 951,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 952,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 953,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 954,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 955,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 956,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 957,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 958,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 959,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 960,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 961,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 962,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 963,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 964,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 965,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 966,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 967,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 968,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 969,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 970,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 971,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 972,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 973,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 974,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 975,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 976,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 977,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 978,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 979,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 980,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 981,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 982,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 983,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 984,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 985,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 986,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 987,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 988,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 989,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 990,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 991,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 992,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 993,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 994,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 995,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 996,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 997,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 998,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 999,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1000,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1005,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1006,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1007,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1008,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1011,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1012,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1013,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1014,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1015,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1016,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1017,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1018,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1019,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1020,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1021,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1022,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1023,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1024,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1025,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1026,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1027,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1028,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1029,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1030,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1031,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1032,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1033,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1034,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1035,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1036,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1037,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1038,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1039,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1040,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1041,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1042,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1043,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1044,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1045,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1046,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1047,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1048,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1049,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1050,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1051,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1052,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1053,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1054,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1055,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1056,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1057,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1058,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1059,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1060,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1061,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1062,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1063,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1064,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1065,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1066,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1067,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1068,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1069,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1070,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1071,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1072,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1073,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1074,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1075,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1076,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1077,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1078,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1079,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1080,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1081,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1082,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1083,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1084,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1085,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1086,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1087,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1088,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1089,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1090,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1091,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1092,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1093,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1094,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1095,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1096,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1097,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1098,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1099,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1100,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1101,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1102,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1103,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1104,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1105,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1106,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1107,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1108,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1109,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1110,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1111,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1112,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1113,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1114,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1115,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1116,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1117,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1118,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1119,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1120,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1121,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1122,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1123,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1124,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1125,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1126,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1127,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1128,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1129,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1130,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1131,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1132,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1133,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1134,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1135,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1136,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1137,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1138,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1139,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1140,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1141,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1142,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1143,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1144,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1145,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1146,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1147,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1148,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1149,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1150,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1151,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1152,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1153,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1154,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1155,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1156,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1157,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1158,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1159,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1160,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1161,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1162,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1163,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1164,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1165,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1166,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1167,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1168,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1169,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1170,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1171,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1172,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1173,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1174,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1175,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1176,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1177,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1178,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1179,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1180,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1181,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1182,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1183,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1184,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1185,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1186,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1187,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1188,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1189,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1190,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1191,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1192,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1193,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1194,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1195,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1196,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1197,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1198,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1199,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1200,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1201,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1202,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1203,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1204,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1205,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1206,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1207,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1208,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1209,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1210,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1211,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1212,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1213,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1214,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1215,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1216,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1217,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1218,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1219,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1220,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1221,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1222,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1223,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1224,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1225,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1226,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1227,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1228,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1229,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1230,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1231,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1232,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1233,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1234,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1235,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1236,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1237,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1238,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1239,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1240,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1241,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1242,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1243,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1244,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1245,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1246,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1247,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1248,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1249,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1250,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1251,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1252,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1253,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1254,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1255,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1256,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1257,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1258,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1259,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1260,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1261,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1262,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1263,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1264,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1265,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1266,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1267,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1268,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1269,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1270,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1271,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1272,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1273,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Products_WebsiteId",
                table: "Shop.Products",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Orders_ProductModelId",
                table: "Shop.Orders",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Invoices_WebsiteId",
                table: "Shop.Invoices",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Customers_WebsiteId",
                table: "Shop.Customers",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_CustomerId",
                table: "Basket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_WebsiteId",
                table: "Basket",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_BasketId",
                table: "BasketItem",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ProductId",
                table: "BasketItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ProductModelId",
                table: "BasketItem",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop.Customers_System.Websites_WebsiteId",
                table: "Shop.Customers",
                column: "WebsiteId",
                principalTable: "System.Websites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop.Invoices_System.Websites_WebsiteId",
                table: "Shop.Invoices",
                column: "WebsiteId",
                principalTable: "System.Websites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop.Orders_Shop.Product_Models_ProductModelId",
                table: "Shop.Orders",
                column: "ProductModelId",
                principalTable: "Shop.Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop.Products_System.Websites_WebsiteId",
                table: "Shop.Products",
                column: "WebsiteId",
                principalTable: "System.Websites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop.Customers_System.Websites_WebsiteId",
                table: "Shop.Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop.Invoices_System.Websites_WebsiteId",
                table: "Shop.Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop.Orders_Shop.Product_Models_ProductModelId",
                table: "Shop.Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop.Products_System.Websites_WebsiteId",
                table: "Shop.Products");

            migrationBuilder.DropTable(
                name: "BasketItem");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Shop.Products_WebsiteId",
                table: "Shop.Products");

            migrationBuilder.DropIndex(
                name: "IX_Shop.Orders_ProductModelId",
                table: "Shop.Orders");

            migrationBuilder.DropIndex(
                name: "IX_Shop.Invoices_WebsiteId",
                table: "Shop.Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Shop.Customers_WebsiteId",
                table: "Shop.Customers");

            migrationBuilder.DropColumn(
                name: "WebsiteId",
                table: "Shop.Products");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "Shop.Orders");

            migrationBuilder.DropColumn(
                name: "ProductModelTitle",
                table: "Shop.Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shop.Orders");

            migrationBuilder.DropColumn(
                name: "WebsiteId",
                table: "Shop.Invoices");

            migrationBuilder.DropColumn(
                name: "WebsiteId",
                table: "Shop.Customers");

            migrationBuilder.UpdateData(
                table: "Shop.Shippings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifyDate", "Status" },
                values: new object[] { new DateTime(2021, 1, 6, 8, 9, 54, 651, DateTimeKind.Utc).AddTicks(5480), new DateTime(2021, 1, 6, 8, 9, 54, 651, DateTimeKind.Utc).AddTicks(7407), 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 10,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 11,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 12,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 13,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 14,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 15,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 16,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 17,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 18,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 19,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 20,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 21,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 22,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 23,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 24,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 25,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 26,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 27,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 28,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 29,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 30,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 32,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 33,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 34,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 35,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 36,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 37,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 38,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 39,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 40,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 41,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 42,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 43,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 44,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 45,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 46,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 47,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 48,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 49,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 50,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 51,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 52,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 53,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 54,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 55,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 56,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 57,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 58,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 59,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 60,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 61,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 62,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 63,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 64,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 65,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 66,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 67,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 68,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 69,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 70,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 71,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 72,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 73,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 74,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 75,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 76,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 77,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 78,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 79,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 80,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 81,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 82,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 83,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 84,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 85,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 86,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 87,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 88,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 89,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 90,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 91,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 92,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 93,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 95,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 96,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 97,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 98,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 99,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 100,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 101,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 102,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 103,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 104,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 105,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 106,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 107,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 108,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 109,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 110,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 111,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 112,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 113,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 114,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 115,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 116,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 117,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 118,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 119,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 120,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 121,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 122,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 123,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 124,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 125,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 126,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 127,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 128,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 129,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 130,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 131,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 132,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 133,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 134,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 135,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 136,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 137,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 138,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 139,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 140,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 141,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 142,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 143,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 144,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 145,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 146,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 147,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 148,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 149,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 150,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 151,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 152,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 153,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 154,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 155,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 156,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 157,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 158,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 159,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 160,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 161,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 162,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 163,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 164,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 165,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 166,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 167,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 168,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 169,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 170,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 171,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 172,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 173,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 174,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 175,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 176,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 177,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 178,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 179,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 180,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 181,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 182,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 183,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 184,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 185,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 186,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 187,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 188,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 189,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 190,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 191,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 192,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 193,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 194,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 195,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 196,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 197,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 198,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 199,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 200,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 201,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 202,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 203,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 204,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 205,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 206,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 207,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 208,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 209,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 210,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 211,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 212,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 213,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 214,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 215,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 216,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 217,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 218,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 219,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 220,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 221,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 222,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 223,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 224,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 225,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 226,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 227,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 228,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 229,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 230,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 231,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 232,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 233,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 234,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 235,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 236,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 237,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 238,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 239,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 240,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 241,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 242,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 243,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 244,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 245,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 246,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 247,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 248,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 249,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 250,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 251,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 252,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 253,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 254,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 255,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 256,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 257,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 258,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 259,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 260,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 261,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 262,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 263,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 264,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 265,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 266,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 267,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 268,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 269,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 270,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 271,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 272,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 273,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 274,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 275,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 276,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 277,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 278,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 279,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 280,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 281,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 282,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 283,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 284,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 285,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 286,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 287,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 288,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 289,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 290,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 291,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 292,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 293,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 294,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 295,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 296,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 297,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 298,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 299,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 300,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 301,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 302,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 303,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 304,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 305,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 306,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 307,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 308,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 309,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 310,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 311,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 312,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 313,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 314,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 315,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 316,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 317,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 318,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 319,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 320,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 321,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 322,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 323,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 324,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 325,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 326,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 327,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 328,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 329,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 330,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 331,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 332,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 333,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 334,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 335,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 336,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 337,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 338,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 339,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 340,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 341,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 342,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 343,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 344,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 345,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 346,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 347,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 348,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 349,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 350,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 351,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 352,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 353,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 354,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 355,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 356,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 357,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 358,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 359,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 360,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 361,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 362,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 363,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 364,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 365,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 366,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 367,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 368,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 369,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 370,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 371,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 372,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 373,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 374,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 375,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 376,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 377,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 378,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 379,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 380,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 381,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 382,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 383,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 384,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 385,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 386,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 387,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 388,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 389,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 390,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 391,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 392,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 393,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 394,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 395,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 396,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 397,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 398,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 399,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 400,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 401,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 402,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 403,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 404,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 405,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 406,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 407,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 408,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 409,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 410,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 411,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 412,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 413,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 414,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 415,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 416,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 417,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 418,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 419,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 420,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 421,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 422,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 423,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 424,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 425,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 426,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 427,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 428,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 429,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 430,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 431,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 432,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 433,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 434,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 435,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 436,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 437,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 438,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 439,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 440,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 441,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 442,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 443,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 444,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 445,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 446,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 447,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 448,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 449,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 450,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 451,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 452,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 453,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 454,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 455,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 456,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 457,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 458,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 459,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 460,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 461,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 462,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 463,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 464,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 465,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 466,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 467,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 468,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 469,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 470,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 471,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 472,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 473,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 474,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 475,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 476,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 477,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 478,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 479,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 480,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 481,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 482,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 483,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 484,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 485,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 486,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 487,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 488,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 489,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 490,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 491,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 492,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 493,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 494,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 495,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 496,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 497,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 498,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 499,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 500,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 501,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 502,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 503,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 504,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 505,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 506,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 507,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 508,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 509,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 510,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 511,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 512,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 513,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 514,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 515,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 516,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 517,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 518,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 519,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 520,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 521,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 522,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 523,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 524,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 525,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 526,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 527,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 528,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 529,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 530,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 531,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 532,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 533,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 534,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 535,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 536,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 537,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 538,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 539,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 540,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 541,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 542,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 543,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 544,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 545,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 546,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 547,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 548,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 549,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 550,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 551,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 552,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 553,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 554,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 555,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 556,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 557,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 558,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 559,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 560,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 561,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 562,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 563,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 564,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 565,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 566,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 567,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 568,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 569,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 570,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 571,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 572,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 573,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 574,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 575,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 576,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 577,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 578,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 579,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 580,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 581,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 582,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 583,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 584,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 585,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 586,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 587,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 588,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 589,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 590,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 591,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 592,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 593,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 594,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 595,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 596,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 597,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 598,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 599,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 600,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 601,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 602,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 603,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 604,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 605,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 606,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 607,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 608,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 609,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 610,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 611,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 612,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 613,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 614,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 615,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 616,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 617,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 618,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 619,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 620,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 621,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 622,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 623,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 624,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 625,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 626,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 627,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 628,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 629,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 630,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 631,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 632,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 633,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 634,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 635,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 636,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 637,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 638,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 639,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 640,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 641,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 642,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 643,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 644,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 645,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 646,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 647,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 648,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 649,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 650,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 651,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 652,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 653,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 654,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 655,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 656,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 657,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 658,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 659,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 660,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 661,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 662,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 663,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 664,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 665,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 666,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 667,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 668,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 669,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 670,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 671,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 672,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 673,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 674,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 675,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 676,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 677,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 678,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 679,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 680,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 681,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 682,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 683,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 684,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 685,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 686,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 687,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 688,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 689,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 690,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 691,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 692,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 693,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 694,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 695,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 696,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 697,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 698,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 699,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 700,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 701,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 702,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 703,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 704,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 705,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 706,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 707,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 708,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 709,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 710,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 711,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 712,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 713,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 714,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 715,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 716,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 717,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 718,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 719,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 720,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 721,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 722,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 723,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 724,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 725,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 726,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 727,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 728,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 729,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 730,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 731,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 732,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 733,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 734,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 735,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 736,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 737,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 738,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 739,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 740,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 741,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 742,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 743,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 744,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 745,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 746,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 747,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 748,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 749,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 750,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 751,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 752,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 753,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 754,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 755,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 756,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 757,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 758,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 759,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 760,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 761,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 762,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 763,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 764,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 765,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 766,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 767,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 768,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 769,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 770,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 771,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 772,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 773,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 774,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 775,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 776,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 777,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 778,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 779,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 780,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 781,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 782,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 783,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 784,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 785,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 786,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 787,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 788,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 789,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 790,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 791,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 792,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 793,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 794,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 795,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 796,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 797,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 798,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 799,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 800,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 801,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 802,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 803,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 804,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 805,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 806,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 807,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 808,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 809,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 810,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 811,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 812,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 813,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 814,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 815,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 816,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 817,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 818,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 819,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 820,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 821,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 822,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 823,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 824,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 825,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 826,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 827,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 828,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 829,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 830,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 831,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 832,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 833,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 834,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 835,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 836,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 837,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 838,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 839,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 840,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 841,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 842,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 843,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 844,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 845,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 846,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 847,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 848,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 849,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 850,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 851,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 852,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 853,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 854,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 855,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 856,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 857,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 858,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 859,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 860,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 861,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 862,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 863,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 864,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 865,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 866,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 867,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 868,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 869,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 870,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 871,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 872,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 873,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 874,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 875,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 876,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 877,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 878,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 879,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 880,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 881,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 882,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 883,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 884,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 885,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 886,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 887,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 888,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 889,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 890,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 891,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 892,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 893,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 894,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 895,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 896,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 897,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 898,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 899,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 900,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 901,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 902,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 903,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 904,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 905,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 906,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 907,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 908,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 909,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 910,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 911,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 912,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 913,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 914,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 915,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 916,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 917,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 918,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 919,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 920,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 921,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 922,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 923,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 924,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 925,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 926,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 927,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 928,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 929,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 930,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 931,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 932,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 933,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 934,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 935,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 936,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 937,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 938,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 939,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 940,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 941,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 942,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 943,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 944,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 945,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 946,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 947,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 948,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 949,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 950,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 951,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 952,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 953,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 954,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 955,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 956,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 957,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 958,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 959,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 960,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 961,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 962,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 963,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 964,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 965,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 966,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 967,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 968,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 969,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 970,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 971,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 972,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 973,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 974,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 975,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 976,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 977,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 978,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 979,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 980,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 981,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 982,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 983,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 984,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 985,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 986,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 987,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 988,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 989,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 990,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 991,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 992,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 993,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 994,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 995,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 996,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 997,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 998,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 999,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1000,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1005,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1006,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1007,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1008,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1009,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1011,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1012,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1013,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1014,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1015,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1016,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1017,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1018,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1019,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1020,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1021,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1022,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1023,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1024,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1025,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1026,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1027,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1028,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1029,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1030,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1031,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1032,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1033,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1034,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1035,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1036,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1037,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1038,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1039,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1040,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1041,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1042,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1043,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1044,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1045,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1046,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1047,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1048,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1049,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1050,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1051,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1052,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1053,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1054,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1055,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1056,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1057,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1058,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1059,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1060,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1061,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1062,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1063,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1064,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1065,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1066,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1067,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1068,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1069,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1070,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1071,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1072,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1073,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1074,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1075,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1076,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1077,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1078,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1079,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1080,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1081,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1082,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1083,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1084,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1085,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1086,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1087,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1088,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1089,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1090,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1091,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1092,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1093,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1094,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1095,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1096,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1097,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1098,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1099,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1100,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1101,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1102,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1103,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1104,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1105,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1106,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1107,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1108,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1109,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1110,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1111,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1112,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1113,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1114,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1115,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1116,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1117,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1118,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1119,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1120,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1121,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1122,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1123,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1124,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1125,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1126,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1127,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1128,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1129,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1130,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1131,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1132,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1133,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1134,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1135,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1136,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1137,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1138,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1139,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1140,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1141,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1142,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1143,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1144,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1145,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1146,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1147,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1148,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1149,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1150,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1151,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1152,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1153,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1154,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1155,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1156,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1157,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1158,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1159,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1160,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1161,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1162,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1163,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1164,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1165,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1166,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1167,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1168,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1169,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1170,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1171,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1172,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1173,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1174,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1175,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1176,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1177,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1178,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1179,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1180,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1181,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1182,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1183,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1184,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1185,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1186,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1187,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1188,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1189,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1190,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1191,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1192,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1193,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1194,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1195,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1196,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1197,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1198,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1199,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1200,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1201,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1202,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1203,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1204,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1205,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1206,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1207,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1208,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1209,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1210,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1211,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1212,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1213,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1214,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1215,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1216,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1217,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1218,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1219,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1220,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1221,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1222,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1223,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1224,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1225,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1226,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1227,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1228,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1229,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1230,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1231,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1232,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1233,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1234,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1235,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1236,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1237,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1238,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1239,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1240,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1241,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1242,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1243,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1244,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1245,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1246,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1247,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1248,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1249,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1250,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1251,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1252,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1253,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1254,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1255,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1256,
                columns: new[] { "Kind", "Status" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1257,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1258,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1259,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1260,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1261,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1262,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1263,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1264,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1265,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1266,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1267,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1268,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1269,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1270,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1271,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1272,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Cities",
                keyColumn: "Id",
                keyValue: 1273,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Currencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.Currencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: 1);
        }
    }
}
