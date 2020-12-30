using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class ShopModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultCurrencyId",
                table: "System.Websites",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Content.Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Shop.Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Slug = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    CoverPhoto = table.Column<string>(maxLength: 2000, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 300, nullable: true),
                    LastName = table.Column<string>(maxLength: 300, nullable: false),
                    NationalCode = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyNationalCode = table.Column<string>(maxLength: 50, nullable: true),
                    FinancialCode = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 1000, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    PersonalityType = table.Column<int>(nullable: false, defaultValue: 0),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Customers_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Shippings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                    MinDeliveryDays = table.Column<int>(nullable: false),
                    MaxDeliveryDays = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Shippings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Slug = table.Column<string>(maxLength: 2000, nullable: false),
                    Email = table.Column<string>(maxLength: 2000, nullable: false),
                    Website = table.Column<string>(maxLength: 2000, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Vendors_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "System.Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    ParentId = table.Column<int>(nullable: true),
                    Kind = table.Column<int>(nullable: false, defaultValue: 0),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "System.Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Sign = table.Column<string>(maxLength: 50, nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    IsBase = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System.Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 1000, nullable: false),
                    Slug = table.Column<string>(maxLength: 2000, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    Template = table.Column<string>(maxLength: 4000, nullable: true),
                    BodyType = table.Column<int>(nullable: false, defaultValue: 1),
                    CategoryId = table.Column<int>(nullable: true),
                    Orderable = table.Column<bool>(nullable: false, defaultValue: true),
                    AvailableForPreOrder = table.Column<bool>(nullable: false),
                    PreOrderStartDate = table.Column<DateTime>(nullable: true),
                    PreOrderFinishDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    Cost = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    UnitName = table.Column<string>(maxLength: 300, nullable: true),
                    TaxPercent = table.Column<decimal>(nullable: false),
                    TaxAmount = table.Column<decimal>(nullable: false),
                    CheckStockBeforeOrder = table.Column<bool>(nullable: false),
                    MinStock = table.Column<int>(nullable: false),
                    Downloadable = table.Column<bool>(nullable: false),
                    MaxDownloads = table.Column<int>(nullable: false),
                    Sku = table.Column<string>(maxLength: 100, nullable: true),
                    NewProduct = table.Column<bool>(nullable: false),
                    NewProductStartDate = table.Column<DateTime>(nullable: true),
                    NewProductFinishDate = table.Column<DateTime>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Size = table.Column<string>(maxLength: 100, nullable: true),
                    Color = table.Column<string>(maxLength: 100, nullable: true),
                    AvailabilityStartDate = table.Column<DateTime>(nullable: true),
                    AvailabilityFinishDate = table.Column<DateTime>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: false),
                    MetaDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    MetaRobots = table.Column<string>(maxLength: 100, nullable: true),
                    VendorId = table.Column<int>(nullable: true),
                    BrandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Products_Shop.Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Shop.Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Products_System.Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "System.Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Products_Shop.Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Shop.Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Shipping_Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    Street = table.Column<string>(maxLength: 300, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Shipping_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Shipping_Addresses_System.Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "System.Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Shipping_Addresses_Shop.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Shop.Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Product_Prices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    OldPrice = table.Column<decimal>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: true),
                    DiscountValue = table.Column<decimal>(nullable: false),
                    DiscountPercent = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Product_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Product_Prices_Security.Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Product_Prices_Security.Users_ModifierUserId",
                        column: x => x.ModifierUserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Product_Prices_Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Product_Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    VoteYesCount = table.Column<int>(nullable: false),
                    VoteNoCount = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 300, nullable: true),
                    Body = table.Column<string>(maxLength: 4000, nullable: false),
                    BodyType = table.Column<int>(nullable: false, defaultValue: 1),
                    ParentId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 0),
                    Ip = table.Column<string>(maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(maxLength: 500, nullable: true),
                    SessionId = table.Column<string>(maxLength: 1000, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Product_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Product_Reviews_Shop.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Shop.Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Product_Reviews_Security.Users_ModifierUserId",
                        column: x => x.ModifierUserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Product_Reviews_Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop.ProductMeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 1000, nullable: true),
                    MetaKey = table.Column<string>(maxLength: 1000, nullable: false),
                    MetaValue = table.Column<string>(maxLength: 4000, nullable: true),
                    Category = table.Column<string>(maxLength: 1000, nullable: true),
                    LangId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    IconName = table.Column<string>(maxLength: 300, nullable: true),
                    CoverPhoto = table.Column<string>(maxLength: 4000, nullable: true),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    OrderNumber = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.ProductMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.ProductMeta_System.Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "System.Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.ProductMeta_Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    InvoiceNumnber = table.Column<string>(maxLength: 100, nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false, defaultValue: 1),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    ShippingId = table.Column<int>(nullable: true),
                    ShippingAddressId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Invoices_Shop.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Shop.Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Invoices_Shop.Shipping_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Shop.Shipping_Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Invoices_Shop.Shippings_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shop.Shippings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ProductTitle = table.Column<string>(maxLength: 1000, nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    UnitName = table.Column<string>(maxLength: 300, nullable: true),
                    DiscountValue = table.Column<decimal>(nullable: false),
                    DiscountPercent = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1),
                    TaxAmount = table.Column<decimal>(nullable: false),
                    TaxPercent = table.Column<decimal>(nullable: false),
                    ShippingId = table.Column<int>(nullable: false),
                    ShippingAddressId = table.Column<int>(nullable: false),
                    ShippingAmount = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Orders_Shop.Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Shop.Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Orders_Shop.Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Shop.Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Orders_Shop.Shipping_Addresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Shop.Shipping_Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Orders_Shop.Shippings_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Shop.Shippings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shop.Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerTitle = table.Column<string>(maxLength: 600, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    TransactionId = table.Column<string>(maxLength: 500, nullable: true),
                    Method = table.Column<int>(nullable: false, defaultValue: 0),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop.Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop.Payments_Shop.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Shop.Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shop.Payments_Shop.Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Shop.Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Shop.Shippings",
                columns: new[] { "Id", "CreateDate", "Description", "IsFree", "MaxDeliveryDays", "MinDeliveryDays", "ModifyDate", "Price", "Status", "Title" },
                values: new object[] { 1, new DateTime(2020, 12, 30, 16, 8, 24, 503, DateTimeKind.Utc).AddTicks(5407), null, true, 0, 0, new DateTime(2020, 12, 30, 16, 8, 24, 503, DateTimeKind.Utc).AddTicks(6703), 0m, 1, "پست" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 854, null, null, 851, 1, "جعفریه" },
                    { 853, null, null, 851, 1, "قنوات" },
                    { 852, null, null, 851, 1, "قم" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 851, null, null, 1, null, 1, "قم" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 850, null, null, 811, 1, "گوهران" },
                    { 849, null, null, 811, 1, "سردشت" },
                    { 848, null, null, 811, 1, "کوهستک" },
                    { 847, null, null, 811, 1, "گروک" },
                    { 846, null, null, 811, 1, "سیریک" },
                    { 845, null, null, 811, 1, "بیکاه" },
                    { 844, null, null, 811, 1, "زیارتعلی" },
                    { 843, null, null, 811, 1, "دهبارز" },
                    { 842, null, null, 811, 1, "رویدر" },
                    { 841, null, null, 811, 1, "خمیر" },
                    { 840, null, null, 811, 1, "دشتی" },
                    { 855, null, null, 851, 1, "کهک" },
                    { 856, null, null, 851, 1, "دستجرد" },
                    { 857, null, null, 851, 1, "سلفچگان" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 858, null, null, 1, null, 1, "یزد" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 874, null, null, 858, 1, "میبد" },
                    { 873, null, null, 858, 1, "خضر آباد" },
                    { 872, null, null, 858, 1, "اشکذر" },
                    { 871, null, null, 858, 1, "مهریز" },
                    { 870, null, null, 858, 1, "بافق" },
                    { 869, null, null, 858, 1, "نیر" },
                    { 868, null, null, 858, 1, "تفت" },
                    { 839, null, null, 811, 1, "کوشکنار" },
                    { 867, null, null, 858, 1, "مهردشت" },
                    { 865, null, null, 858, 1, "عقدا" },
                    { 864, null, null, 858, 1, "احمد آباد" },
                    { 863, null, null, 858, 1, "اردکان" },
                    { 862, null, null, 858, 1, "زارچ" },
                    { 861, null, null, 858, 1, "حمیدیا" },
                    { 860, null, null, 858, 1, "شاهدیه" },
                    { 859, null, null, 858, 1, "یزد" },
                    { 866, null, null, 858, 1, "ابرکوه" },
                    { 838, null, null, 811, 1, "پارسیان" },
                    { 837, null, null, 811, 1, "سرگز" },
                    { 836, null, null, 811, 1, "فارغان" },
                    { 815, null, null, 811, 1, "قلعه قاضی" },
                    { 814, null, null, 811, 1, "فین" },
                    { 813, null, null, 811, 1, "تازیان پائین" },
                    { 812, null, null, 811, 1, "بندر عباس" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 811, null, null, 1, null, 1, "هرمزگان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 810, null, null, 752, 1, "سورک" },
                    { 809, null, null, 752, 1, "شیرگاه" },
                    { 816, null, null, 811, 1, "تخت" },
                    { 808, null, null, 752, 1, "کوهی خیل" },
                    { 806, null, null, 752, 1, "کیاکلا" },
                    { 805, null, null, 752, 1, "کلاردشت" },
                    { 804, null, null, 752, 1, "مرزن آباد" },
                    { 803, null, null, 752, 1, "گلوگاه" },
                    { 802, null, null, 752, 1, "آلاشت" },
                    { 801, null, null, 752, 1, "پل سفید" },
                    { 800, null, null, 752, 1, "زیرآب" },
                    { 807, null, null, 752, 1, "جویبار" },
                    { 875, null, null, 858, 1, "بفروئیه" },
                    { 817, null, null, 811, 1, "بندر لنگه" },
                    { 819, null, null, 811, 1, "کیش" },
                    { 835, null, null, 811, 1, "حاجی آباد" },
                    { 834, null, null, 811, 1, "ابوموسی" },
                    { 833, null, null, 811, 1, "سوزا" },
                    { 832, null, null, 811, 1, "هرمز" },
                    { 831, null, null, 811, 1, "درگهان" },
                    { 830, null, null, 811, 1, "قشم" },
                    { 829, null, null, 811, 1, "بندر جاسک" },
                    { 818, null, null, 811, 1, "کنگ" },
                    { 828, null, null, 811, 1, "کوخردهرنگ" },
                    { 826, null, null, 811, 1, "بستک" },
                    { 825, null, null, 811, 1, "سندرک" },
                    { 824, null, null, 811, 1, "هشتبندی" },
                    { 823, null, null, 811, 1, "تیرور" },
                    { 822, null, null, 811, 1, "میناب" },
                    { 821, null, null, 811, 1, "لمزان" },
                    { 820, null, null, 811, 1, "چارک" },
                    { 827, null, null, 811, 1, "جناح" },
                    { 876, null, null, 858, 1, "ندوشن" },
                    { 877, null, null, 858, 1, "بهاباد" },
                    { 878, null, null, 858, 1, "هرات" },
                    { 934, null, null, 880, 1, "زرین شهر" },
                    { 933, null, null, 880, 1, "گرگاب" },
                    { 932, null, null, 880, 1, "شاهین شهر" },
                    { 931, null, null, 880, 1, "گز برخوار" },
                    { 930, null, null, 880, 1, "لای بید" },
                    { 929, null, null, 880, 1, "وزوان" },
                    { 928, null, null, 880, 1, "میمه" },
                    { 935, null, null, 880, 1, "سده لنجان" },
                    { 927, null, null, 880, 1, "خالد آباد" },
                    { 925, null, null, 880, 1, "طرق رود" },
                    { 924, null, null, 880, 1, "نظنز" },
                    { 923, null, null, 880, 1, "زواره" },
                    { 922, null, null, 880, 1, "مهاباد" },
                    { 921, null, null, 880, 1, "اردستان" },
                    { 920, null, null, 880, 1, "انارک" },
                    { 919, null, null, 880, 1, "بافران" },
                    { 926, null, null, 880, 1, "بادرود" },
                    { 918, null, null, 880, 1, "نائین" },
                    { 936, null, null, 880, 1, "چمگردان" },
                    { 938, null, null, 880, 1, "فولاد شهر" },
                    { 954, null, null, 880, 1, "ایمانشهر" },
                    { 953, null, null, 880, 1, "ابریشم" },
                    { 952, null, null, 880, 1, "قهدریجان" },
                    { 951, null, null, 880, 1, "کلیشاد و سودرجان" },
                    { 950, null, null, 880, 1, "فلاورجان" },
                    { 949, null, null, 880, 1, "زیباشهر" },
                    { 948, null, null, 880, 1, "کرکوند" },
                    { 937, null, null, 880, 1, "ورنامخواست" },
                    { 947, null, null, 880, 1, "طالخونچه" },
                    { 945, null, null, 880, 1, "مبارکه" },
                    { 944, null, null, 880, 1, "دامنه" },
                    { 943, null, null, 880, 1, "داران" },
                    { 942, null, null, 880, 1, "چرمهین" },
                    { 941, null, null, 880, 1, "باغ بهادران" },
                    { 940, null, null, 880, 1, "باغشاد" },
                    { 939, null, null, 880, 1, "زاینده رود" },
                    { 946, null, null, 880, 1, "دیزیچه" },
                    { 799, null, null, 752, 1, "کلارآباد" },
                    { 917, null, null, 880, 1, "اصغرآباد" },
                    { 915, null, null, 880, 1, "درچه پیاز" },
                    { 894, null, null, 880, 1, "نیک آباد" },
                    { 893, null, null, 880, 1, "ورزنه" },
                    { 892, null, null, 880, 1, "اژیه" },
                    { 891, null, null, 880, 1, "هرند" },
                    { 890, null, null, 880, 1, "تودشک" },
                    { 889, null, null, 880, 1, "سگزی" },
                    { 888, null, null, 880, 1, "کوهپایه" },
                    { 895, null, null, 880, 1, "محمد آباد" },
                    { 887, null, null, 880, 1, "زیار" },
                    { 885, null, null, 880, 1, "بهارستان" },
                    { 884, null, null, 880, 1, "اصفهان" },
                    { 883, null, null, 880, 1, "گلشهر" },
                    { 882, null, null, 880, 1, "گوگد" },
                    { 881, null, null, 880, 1, "گلپایگان" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 880, null, null, 1, null, 1, "اصفهان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 879, null, null, 858, 1, "مروست" },
                    { 886, null, null, 880, 1, "قهجاورستان" },
                    { 916, null, null, 880, 1, "کوشک" },
                    { 896, null, null, 880, 1, "نصرآباد" },
                    { 898, null, null, 880, 1, "شهرضا" },
                    { 914, null, null, 880, 1, "خمینی شهر" },
                    { 913, null, null, 880, 1, "دهق" },
                    { 912, null, null, 880, 1, "علویچه" },
                    { 911, null, null, 880, 1, "جوزدان" },
                    { 910, null, null, 880, 1, "کهریزسنگ" },
                    { 909, null, null, 880, 1, "گلدشت" },
                    { 908, null, null, 880, 1, "نجف آباد" },
                    { 897, null, null, 880, 1, "حسن آباد" },
                    { 907, null, null, 880, 1, "برزک" },
                    { 905, null, null, 880, 1, "جوشقان قالی" },
                    { 904, null, null, 880, 1, "کامو و چوگان" },
                    { 903, null, null, 880, 1, "قمصر" },
                    { 902, null, null, 880, 1, "مشکات" },
                    { 901, null, null, 880, 1, "کاشان" },
                    { 900, null, null, 880, 1, "خوانسار" },
                    { 899, null, null, 880, 1, "منظریه" },
                    { 906, null, null, 880, 1, "نیاسر" },
                    { 798, null, null, 752, 1, "سلمان شهر" },
                    { 797, null, null, 752, 1, "عباس آباد" },
                    { 796, null, null, 752, 1, "بلده" },
                    { 695, null, null, 619, 1, "کره ای" },
                    { 694, null, null, 619, 1, "بوانات" },
                    { 693, null, null, 619, 1, "بابامنیر" },
                    { 692, null, null, 619, 1, "خومه زار" },
                    { 691, null, null, 619, 1, "نورآباد" },
                    { 690, null, null, 619, 1, "افزر" },
                    { 689, null, null, 619, 1, "مبارک آباد" },
                    { 696, null, null, 619, 1, "حسامی" },
                    { 688, null, null, 619, 1, "امام شهر" },
                    { 686, null, null, 619, 1, "قیر" },
                    { 685, null, null, 619, 1, "سلطان شهر" },
                    { 684, null, null, 619, 1, "خرامه" },
                    { 683, null, null, 619, 1, "ارسنجان" },
                    { 682, null, null, 619, 1, "کوهنجان" },
                    { 681, null, null, 619, 1, "سروستان" },
                    { 680, null, null, 619, 1, "هماشهر" },
                    { 687, null, null, 619, 1, "کارزین" },
                    { 679, null, null, 619, 1, "بیضا" },
                    { 697, null, null, 619, 1, "مزایجان" },
                    { 699, null, null, 619, 1, "مادرسلیمان" },
                    { 715, null, null, 619, 1, "مهر" },
                    { 714, null, null, 619, 1, "شهر پیر" },
                    { 713, null, null, 619, 1, "دبیران" },
                    { 712, null, null, 619, 1, "حاجی آباد" },
                    { 711, null, null, 619, 1, "علامرودشت" },
                    { 710, null, null, 619, 1, "اهل" },
                    { 709, null, null, 619, 1, "اشکنان" },
                    { 698, null, null, 619, 1, "سعادت شهر" },
                    { 708, null, null, 619, 1, "لامرد" },
                    { 706, null, null, 619, 1, "نوجین" },
                    { 705, null, null, 619, 1, "فراشبند" },
                    { 704, null, null, 619, 1, "صفا شهر" },
                    { 703, null, null, 619, 1, "قادرآباد" },
                    { 702, null, null, 619, 1, "کوار" },
                    { 701, null, null, 619, 1, "خنج" },
                    { 700, null, null, 619, 1, "گراش" },
                    { 707, null, null, 619, 1, "دهرم" },
                    { 716, null, null, 619, 1, "گله دار" },
                    { 678, null, null, 619, 1, "اردکان" },
                    { 676, null, null, 619, 1, "فیروزآباد" },
                    { 655, null, null, 619, 1, "دژکرد" },
                    { 654, null, null, 619, 1, "سده" },
                    { 653, null, null, 619, 1, "اقلید" },
                    { 652, null, null, 619, 1, "قطرویه" },
                    { 651, null, null, 619, 1, "مشکان" },
                    { 650, null, null, 619, 1, "آباده طشک" },
                    { 649, null, null, 619, 1, "نی ریز" },
                    { 656, null, null, 619, 1, "حسن آباد" },
                    { 648, null, null, 619, 1, "نودان" },
                    { 646, null, null, 619, 1, "خشت" },
                    { 645, null, null, 619, 1, "قائمیه" },
                    { 644, null, null, 619, 1, "کنار تخته" },
                    { 643, null, null, 619, 1, "کازرون" },
                    { 642, null, null, 619, 1, "دوبرجی" },
                    { 640, null, null, 619, 1, "جنت شهر" },
                    { 639, null, null, 619, 1, "داراب" },
                    { 647, null, null, 619, 1, "بالاده" },
                    { 677, null, null, 619, 1, "میمند" },
                    { 657, null, null, 619, 1, "لار" },
                    { 659, null, null, 619, 1, "لطیفی" },
                    { 675, null, null, 619, 1, "خانیمن" },
                    { 674, null, null, 619, 1, "رامجرد" },
                    { 673, null, null, 619, 1, "کامفیروز" },
                    { 672, null, null, 619, 1, "سیدان" },
                    { 671, null, null, 619, 1, "مرودشت" },
                    { 670, null, null, 619, 1, "خانه زنیان" },
                    { 669, null, null, 619, 1, "شهر جدید صدرا" },
                    { 658, null, null, 619, 1, "خور" },
                    { 668, null, null, 619, 1, "داریان" },
                    { 666, null, null, 619, 1, "لپوئی" },
                    { 665, null, null, 619, 1, "زرقان" },
                    { 664, null, null, 619, 1, "عماد ده" },
                    { 663, null, null, 619, 1, "بیرم" },
                    { 662, null, null, 619, 1, "بنارویه" },
                    { 661, null, null, 619, 1, "جویم" },
                    { 660, null, null, 619, 1, "اوز" },
                    { 667, null, null, 619, 1, "شیراز" },
                    { 955, null, null, 880, 1, "پیر بکران" },
                    { 717, null, null, 619, 1, "وراوی" },
                    { 719, null, null, 619, 1, "اسیر" },
                    { 775, null, null, 752, 1, "فریدونکنار" },
                    { 774, null, null, 752, 1, "کجور" },
                    { 773, null, null, 752, 1, "پول" },
                    { 772, null, null, 752, 1, "نوشهر" },
                    { 771, null, null, 752, 1, "ارطه" },
                    { 770, null, null, 752, 1, "قائم شهر" },
                    { 769, null, null, 752, 1, "امامزاده عبدالله" },
                    { 776, null, null, 752, 1, "نکا" },
                    { 768, null, null, 752, 1, "دابودشت" },
                    { 766, null, null, 752, 1, "رینه" },
                    { 765, null, null, 752, 1, "آمل" },
                    { 764, null, null, 752, 1, "خلیل شهر" },
                    { 763, null, null, 752, 1, "رستمکلا" },
                    { 762, null, null, 752, 1, "بهشهر" },
                    { 761, null, null, 752, 1, "پایین هولار" },
                    { 760, null, null, 752, 1, "فریم" },
                    { 767, null, null, 752, 1, "گزنک" },
                    { 759, null, null, 752, 1, "کیاسر" },
                    { 777, null, null, 752, 1, "خرم آباد" },
                    { 779, null, null, 752, 1, "شیرود" },
                    { 795, null, null, 752, 1, "چمستان" },
                    { 794, null, null, 752, 1, "ایزد شهر" },
                    { 793, null, null, 752, 1, "رویان" },
                    { 792, null, null, 752, 1, "نور" },
                    { 791, null, null, 752, 1, "گتاب" },
                    { 790, null, null, 752, 1, "زرگر محله" },
                    { 789, null, null, 752, 1, "خوش رودپی" },
                    { 778, null, null, 752, 1, "تنکابن" },
                    { 788, null, null, 752, 1, "گلوگاه" },
                    { 786, null, null, 752, 1, "بابل" },
                    { 785, null, null, 752, 1, "امیر کلا" },
                    { 784, null, null, 752, 1, "کتالم و سادات شهر" },
                    { 783, null, null, 752, 1, "رامسر" },
                    { 782, null, null, 752, 1, "هچیرود" },
                    { 781, null, null, 752, 1, "چالوس" },
                    { 780, null, null, 752, 1, "نشتارود" },
                    { 787, null, null, 752, 1, "مرزیکلا" },
                    { 718, null, null, 619, 1, "خوزی" },
                    { 758, null, null, 752, 1, "ساری" },
                    { 756, null, null, 752, 1, "بهنمیر" },
                    { 735, null, null, 722, 1, "انبار آلوم" },
                    { 734, null, null, 722, 1, "آق قلا" },
                    { 733, null, null, 722, 1, "مینودشت" },
                    { 732, null, null, 722, 1, "اینچه برون" },
                    { 731, null, null, 722, 1, "گنبدکاووس" },
                    { 730, null, null, 722, 1, "بندر ترکمن" },
                    { 729, null, null, 722, 1, "سیمین شهر" },
                    { 736, null, null, 722, 1, "رامیان" },
                    { 728, null, null, 722, 1, "گمیش تپه" },
                    { 726, null, null, 722, 1, "بندر گز" },
                    { 725, null, null, 722, 1, "سرخنکلاته" },
                    { 724, null, null, 722, 1, "جلین" },
                    { 723, null, null, 722, 1, "گرگان" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 722, null, null, 1, null, 1, "گلستان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 721, null, null, 619, 1, "کوپن" },
                    { 720, null, null, 619, 1, "مصیری" },
                    { 727, null, null, 722, 1, "نوکنده" },
                    { 757, null, null, 752, 1, "هادی شهر" },
                    { 737, null, null, 722, 1, "دلند" },
                    { 739, null, null, 722, 1, "خان ببین" },
                    { 755, null, null, 752, 1, "بابلسر" },
                    { 754, null, null, 752, 1, "سرخرود" },
                    { 753, null, null, 752, 1, "محمود آباد" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 752, null, null, 1, null, 1, "مازندران" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 751, null, null, 722, 1, "مراوه تپه" },
                    { 750, null, null, 722, 1, "گالیکش" },
                    { 749, null, null, 722, 1, "نوده خاندوز" },
                    { 738, null, null, 722, 1, "تاتار علیا" },
                    { 748, null, null, 722, 1, "نگین شهر" },
                    { 746, null, null, 722, 1, "کرد کوی" },
                    { 745, null, null, 722, 1, "فراغی" },
                    { 744, null, null, 722, 1, "کلاله" },
                    { 743, null, null, 722, 1, "فاضل آباد" },
                    { 742, null, null, 722, 1, "سنگدوین" },
                    { 741, null, null, 722, 1, "مزرعه" },
                    { 740, null, null, 722, 1, "علی آباد" },
                    { 747, null, null, 722, 1, "آزاد شهر" },
                    { 638, null, null, 619, 1, "رونیز" },
                    { 956, null, null, 880, 1, "بهاران شهر" },
                    { 958, null, null, 880, 1, "فریدونشهر" },
                    { 1173, null, null, 1145, 1, "بن" },
                    { 1172, null, null, 1145, 1, "چلیچه" },
                    { 1171, null, null, 1145, 1, "گوجان" },
                    { 1170, null, null, 1145, 1, "پردنجان" },
                    { 1169, null, null, 1145, 1, "باباحیدر" },
                    { 1168, null, null, 1145, 1, "جونقان" },
                    { 1167, null, null, 1145, 1, "فارسان" },
                    { 1166, null, null, 1145, 1, "سامان" },
                    { 1165, null, null, 1145, 1, "سردشت لردگان" },
                    { 1164, null, null, 1145, 1, "منج" },
                    { 1163, null, null, 1145, 1, "آلونی" },
                    { 1162, null, null, 1145, 1, "مال خلیفه" },
                    { 1161, null, null, 1145, 1, "لردگان" },
                    { 1160, null, null, 1145, 1, "گندمان" },
                    { 1159, null, null, 1145, 1, "بلداجی" },
                    { 1174, null, null, 1145, 1, "وردنجان" },
                    { 1175, null, null, 1145, 1, "اردل" },
                    { 1176, null, null, 1145, 1, "دشتک" },
                    { 1177, null, null, 1145, 1, "کاج" },
                    { 1193, null, null, 1186, 1, "بروجرد" },
                    { 1192, null, null, 1186, 1, "شول آباد" },
                    { 1191, null, null, 1186, 1, "الیگودرز" },
                    { 1190, null, null, 1186, 1, "بیرانشهر" },
                    { 1189, null, null, 1186, 1, "سپید دشت" },
                    { 1188, null, null, 1186, 1, "زاغه" },
                    { 1187, null, null, 1186, 1, "خرم آباد" },
                    { 1158, null, null, 1145, 1, "نقنه" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1186, null, null, 1, null, 1, "لرستان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1184, null, null, 1145, 1, "بازفت" },
                    { 1183, null, null, 1145, 1, "چلگرد" },
                    { 1182, null, null, 1145, 1, "ناغان" },
                    { 1181, null, null, 1145, 1, "دستناء" },
                    { 1180, null, null, 1145, 1, "گهرو" },
                    { 1179, null, null, 1145, 1, "شلمزار" },
                    { 1178, null, null, 1145, 1, "سرخون" },
                    { 1185, null, null, 1145, 1, "صمصامی" },
                    { 1157, null, null, 1145, 1, "سفید دشت" },
                    { 1156, null, null, 1145, 1, "فرادنبه" },
                    { 1155, null, null, 1145, 1, "بروجن" },
                    { 1134, null, null, 1112, 1, "بانوره" },
                    { 1133, null, null, 1112, 1, "باینگان" },
                    { 1132, null, null, 1112, 1, "پاوه" },
                    { 1131, null, null, 1112, 1, "نوسود" },
                    { 1130, null, null, 1112, 1, "نودشه" },
                    { 1129, null, null, 1112, 1, "بیستون" },
                    { 1128, null, null, 1112, 1, "هرسین" },
                    { 1135, null, null, 1112, 1, "سر پل ذهاب" },
                    { 1127, null, null, 1112, 1, "حمیل" },
                    { 1125, null, null, 1112, 1, "سومار" },
                    { 1124, null, null, 1112, 1, "قصر شیرین" },
                    { 1123, null, null, 1112, 1, "کوزران" },
                    { 1122, null, null, 1112, 1, "هلشی" },
                    { 1121, null, null, 1112, 1, "رباط" },
                    { 1120, null, null, 1112, 1, "کرمانشاه" },
                    { 1119, null, null, 1112, 1, "میان راهان" },
                    { 1126, null, null, 1112, 1, "اسلام آباد غرب" },
                    { 1194, null, null, 1186, 1, "اشترینان" },
                    { 1136, null, null, 1112, 1, "کنگاور" },
                    { 1138, null, null, 1112, 1, "گیلانغرب" },
                    { 1154, null, null, 1145, 1, "هارونی" },
                    { 1153, null, null, 1145, 1, "سودجان" },
                    { 1152, null, null, 1145, 1, "سورشجان" },
                    { 1151, null, null, 1145, 1, "نافچ" },
                    { 1150, null, null, 1145, 1, "طاقانک" },
                    { 1149, null, null, 1145, 1, "کیان" },
                    { 1148, null, null, 1145, 1, "هفشجان" },
                    { 1137, null, null, 1112, 1, "گودین" },
                    { 1147, null, null, 1145, 1, "فرخ شهر" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1145, null, null, 1, null, 1, "چهار محال و بختیاری" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1144, null, null, 1112, 1, "ازگله" },
                    { 1143, null, null, 1112, 1, "تازه آباد" },
                    { 1142, null, null, 1112, 1, "شاهو" },
                    { 1141, null, null, 1112, 1, "روانسر" },
                    { 1140, null, null, 1112, 1, "جوانرود" },
                    { 1139, null, null, 1112, 1, "سرمست" },
                    { 1146, null, null, 1145, 1, "شهرکرد" },
                    { 1195, null, null, 1186, 1, "دورود" },
                    { 1196, null, null, 1186, 1, "چالانچولان" },
                    { 1197, null, null, 1186, 1, "کوهدشت" },
                    { 1253, null, null, 1230, 1, "دره شهر" },
                    { 1252, null, null, 1230, 1, "مهر" },
                    { 1251, null, null, 1230, 1, "دلگشا" },
                    { 1250, null, null, 1230, 1, "ارکواز" },
                    { 1249, null, null, 1230, 1, "صالح آباد" },
                    { 1248, null, null, 1230, 1, "مهران" },
                    { 1247, null, null, 1230, 1, "شباب" },
                    { 1254, null, null, 1230, 1, "ماژین" },
                    { 1246, null, null, 1230, 1, "بلاوه" },
                    { 1244, null, null, 1230, 1, "آسمان آباد" },
                    { 1243, null, null, 1230, 1, "سرابله" },
                    { 1242, null, null, 1230, 1, "بدره" },
                    { 1241, null, null, 1230, 1, "زرنه" },
                    { 1240, null, null, 1230, 1, "ایوان" },
                    { 1239, null, null, 1230, 1, "سراب باغ" },
                    { 1238, null, null, 1230, 1, "مورموری" },
                    { 1245, null, null, 1230, 1, "توحید" },
                    { 1237, null, null, 1230, 1, "آبدانان" },
                    { 1255, null, null, 1230, 1, "لومار" },
                    { 1257, null, null, 1256, 1, "دهدشت" },
                    { 1273, null, null, 1256, 1, "لیکک" },
                    { 1272, null, null, 1256, 1, "باشت" },
                    { 1271, null, null, 1256, 1, "لنده" },
                    { 1270, null, null, 1256, 1, "پاتاوه" },
                    { 1269, null, null, 1256, 1, "سی سخت" },
                    { 1268, null, null, 1256, 1, "سرفاریاب" },
                    { 1267, null, null, 1256, 1, "چرام" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1256, null, null, 1, null, 1, "کهگیلویه و بویراحمد" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1266, null, null, 1256, 1, "چیتاب" },
                    { 1264, null, null, 1256, 1, "گراب سفلی" },
                    { 1263, null, null, 1256, 1, "مادوان" },
                    { 1262, null, null, 1256, 1, "یاسوج" },
                    { 1261, null, null, 1256, 1, "دوگنبدان" },
                    { 1260, null, null, 1256, 1, "دیشموک" },
                    { 1259, null, null, 1256, 1, "قلعه رئیسی" },
                    { 1258, null, null, 1256, 1, "سوق" },
                    { 1265, null, null, 1256, 1, "مارگون" },
                    { 1118, null, null, 1112, 1, "صحنه" },
                    { 1236, null, null, 1230, 1, "پهله" },
                    { 1234, null, null, 1230, 1, "موسیان" },
                    { 1213, null, null, 1212, 1, "کرج" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1212, null, null, 1, null, 1, "البرز" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1211, null, null, 1186, 1, "چقابل" },
                    { 1210, null, null, 1186, 1, "ویسیان" },
                    { 1209, null, null, 1186, 1, "سراب دوره" },
                    { 1208, null, null, 1186, 1, "هفت چشمه" },
                    { 1207, null, null, 1186, 1, "نورآباد" },
                    { 1214, null, null, 1212, 1, "ماهدشت" },
                    { 1206, null, null, 1186, 1, "معمولان" },
                    { 1204, null, null, 1186, 1, "مومن آباد" },
                    { 1203, null, null, 1186, 1, "ازنا" },
                    { 1202, null, null, 1186, 1, "فیروزآباد" },
                    { 1201, null, null, 1186, 1, "الشتر" },
                    { 1200, null, null, 1186, 1, "درب گنبد" },
                    { 1199, null, null, 1186, 1, "کوهنانی" },
                    { 1198, null, null, 1186, 1, "گراب" },
                    { 1205, null, null, 1186, 1, "پلدختر" },
                    { 1235, null, null, 1230, 1, "میمه" },
                    { 1215, null, null, 1212, 1, "محمد شهر" },
                    { 1217, null, null, 1212, 1, "مشکین دشت" },
                    { 1233, null, null, 1230, 1, "دهلران" },
                    { 1232, null, null, 1230, 1, "چوار" },
                    { 1231, null, null, 1230, 1, "ایلام" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1230, null, null, 1, null, 1, "ایلام" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1229, null, null, 1212, 1, "فردیس" },
                    { 1228, null, null, 1212, 1, "طالقان" },
                    { 1227, null, null, 1212, 1, "تنکمان" },
                    { 1216, null, null, 1212, 1, "کمال شهر" },
                    { 1226, null, null, 1212, 1, "نظر آباد" },
                    { 1224, null, null, 1212, 1, "کوهسار" },
                    { 1223, null, null, 1212, 1, "گلسار" },
                    { 1222, null, null, 1212, 1, "شهر جدید هشتگرد" },
                    { 1221, null, null, 1212, 1, "هشتگرد" },
                    { 1220, null, null, 1212, 1, "اشتهارد" },
                    { 1219, null, null, 1212, 1, "آسارا" },
                    { 1218, null, null, 1212, 1, "گرمدره" },
                    { 1225, null, null, 1212, 1, "چهارباغ" },
                    { 1117, null, null, 1112, 1, "سطر" },
                    { 1116, null, null, 1112, 1, "سنقر" },
                    { 1115, null, null, 1112, 1, "گهواره" },
                    { 1014, null, null, 1010, 1, "کارچان" },
                    { 1013, null, null, 1010, 1, "ساروق" },
                    { 1012, null, null, 1010, 1, "داود آباد" },
                    { 1011, null, null, 1010, 1, "اراک" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1010, null, null, 1, null, 1, "مرکزی" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1009, null, null, 987, 1, "گرمه" },
                    { 1008, null, null, 987, 1, "ایور" },
                    { 1015, null, null, 1010, 1, "محلات" },
                    { 1007, null, null, 987, 1, "درق" },
                    { 1005, null, null, 987, 1, "سنخواست" },
                    { 1004, null, null, 987, 1, "جاجرم" },
                    { 1003, null, null, 987, 1, "راز" },
                    { 1002, null, null, 987, 1, "پیش قلعه" },
                    { 1001, null, null, 987, 1, "آوا" },
                    { 1000, null, null, 987, 1, "قاضی" },
                    { 999, null, null, 987, 1, "آشخانه" },
                    { 1006, null, null, 987, 1, "شوقان" },
                    { 998, null, null, 987, 1, "تیتکانلو" },
                    { 1016, null, null, 1010, 1, "نیمور" },
                    { 1018, null, null, 1010, 1, "ساوه" },
                    { 1034, null, null, 1010, 1, "هندودر" },
                    { 1033, null, null, 1010, 1, "آستانه" },
                    { 1032, null, null, 1010, 1, "شازند" },
                    { 1031, null, null, 1010, 1, "رازقان" },
                    { 1030, null, null, 1010, 1, "خشکرود" },
                    { 1029, null, null, 1010, 1, "پرندک" },
                    { 1028, null, null, 1010, 1, "زاویه" },
                    { 1017, null, null, 1010, 1, "آشتیان" },
                    { 1027, null, null, 1010, 1, "مامونیه" },
                    { 1025, null, null, 1010, 1, "قورچی باشی" },
                    { 1024, null, null, 1010, 1, "خمین" },
                    { 1023, null, null, 1010, 1, "نراق" },
                    { 1022, null, null, 1010, 1, "دلیجان" },
                    { 1021, null, null, 1010, 1, "نوبران" },
                    { 1020, null, null, 1010, 1, "غرق آباد" },
                    { 1019, null, null, 1010, 1, "آوه" },
                    { 1026, null, null, 1010, 1, "تفرش" },
                    { 1035, null, null, 1010, 1, "توره" },
                    { 997, null, null, 987, 1, "فاروج" },
                    { 995, null, null, 987, 1, "اسفراین" },
                    { 974, null, null, 880, 1, "کمشجه" },
                    { 973, null, null, 880, 1, "حبیب آباد" },
                    { 972, null, null, 880, 1, "گلشن" },
                    { 971, null, null, 880, 1, "دهاقان" },
                    { 970, null, null, 880, 1, "رزوه" },
                    { 969, null, null, 880, 1, "چادگان" },
                    { 968, null, null, 880, 1, "فرخی" },
                    { 975, null, null, 880, 1, "شاپورآباد" },
                    { 967, null, null, 880, 1, "جندق" },
                    { 965, null, null, 880, 1, "کمه" },
                    { 964, null, null, 880, 1, "ونک" },
                    { 963, null, null, 880, 1, "حنا" },
                    { 962, null, null, 880, 1, "سمیرم" },
                    { 961, null, null, 880, 1, "افوس" },
                    { 960, null, null, 880, 1, "بوئین میاندشت" },
                    { 959, null, null, 880, 1, "برف انبار" },
                    { 966, null, null, 880, 1, "خور" },
                    { 996, null, null, 987, 1, "صفی آباد" },
                    { 976, null, null, 880, 1, "دولت آباد" },
                    { 978, null, null, 880, 1, "دستگرد" },
                    { 994, null, null, 987, 1, "حصارگرمخان" },
                    { 993, null, null, 987, 1, "چناران شهر" },
                    { 992, null, null, 987, 1, "بجنورد" },
                    { 991, null, null, 987, 1, "قوشخانه" },
                    { 990, null, null, 987, 1, "لوجلی" },
                    { 989, null, null, 987, 1, "زیارت" },
                    { 988, null, null, 987, 1, "شیروان" },
                    { 977, null, null, 880, 1, "خورزوق" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 987, null, null, 1, null, 1, "خراسان شمالی" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 985, null, null, 880, 1, "سفید شهر" },
                    { 984, null, null, 880, 1, "نوش آباد" },
                    { 983, null, null, 880, 1, "آران و بیدگل" },
                    { 982, null, null, 880, 1, "عسگران" },
                    { 981, null, null, 880, 1, "رضوانشهر" },
                    { 980, null, null, 880, 1, "تیران" },
                    { 979, null, null, 880, 1, "سین" },
                    { 986, null, null, 880, 1, "ابوزید آباد" },
                    { 957, null, null, 880, 1, "زازران" },
                    { 1036, null, null, 1010, 1, "شهر جدید مهاجران" },
                    { 1038, null, null, 1010, 1, "کمیجان" },
                    { 1094, null, null, 1082, 1, "کانی سور" },
                    { 1093, null, null, 1082, 1, "آرمرده" },
                    { 1092, null, null, 1082, 1, "بانه" },
                    { 1091, null, null, 1082, 1, "پیرتاج" },
                    { 1090, null, null, 1082, 1, "بابارشانی" },
                    { 1089, null, null, 1082, 1, "یاسوکند" },
                    { 1088, null, null, 1082, 1, "توپ آغاج" },
                    { 1095, null, null, 1082, 1, "بوئین سفلی" },
                    { 1087, null, null, 1082, 1, "بیجار" },
                    { 1085, null, null, 1082, 1, "سقز" },
                    { 1084, null, null, 1082, 1, "شویشه" },
                    { 1083, null, null, 1082, 1, "سنندج" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1082, null, null, 1, null, 1, "کردستان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1081, null, null, 1044, 1, "دوست محمد" },
                    { 1080, null, null, 1044, 1, "گلمورتی" },
                    { 1079, null, null, 1044, 1, "سرباز" },
                    { 1086, null, null, 1082, 1, "صاحب" },
                    { 1078, null, null, 1044, 1, "راسک" },
                    { 1096, null, null, 1082, 1, "قروه" },
                    { 1098, null, null, 1082, 1, "سریش آباد" },
                    { 1114, null, null, 1112, 1, "ریجاب" },
                    { 1113, null, null, 1112, 1, "کرند غرب" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1112, null, null, 1, null, 1, "کرمانشاه" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1111, null, null, 1082, 1, "اورامان تخت" },
                    { 1110, null, null, 1082, 1, "سرو آباد" },
                    { 1109, null, null, 1082, 1, "بلبان آباد" },
                    { 1108, null, null, 1082, 1, "دهگلان" },
                    { 1097, null, null, 1082, 1, "دلبران" },
                    { 1107, null, null, 1082, 1, "موچش" },
                    { 1105, null, null, 1082, 1, "زرینه" },
                    { 1104, null, null, 1082, 1, "دیواندره" },
                    { 1103, null, null, 1082, 1, "برده رشه" },
                    { 1102, null, null, 1082, 1, "چناره" },
                    { 1101, null, null, 1082, 1, "کانی دینار" },
                    { 1100, null, null, 1082, 1, "مریوان" },
                    { 1099, null, null, 1082, 1, "دزج" },
                    { 1106, null, null, 1082, 1, "کامیاران" },
                    { 1037, null, null, 1010, 1, "شهباز" },
                    { 1077, null, null, 1044, 1, "پیشین" },
                    { 1075, null, null, 1044, 1, "علی اکبر" },
                    { 1054, null, null, 1044, 1, "بزمان" },
                    { 1053, null, null, 1044, 1, "محمدان" },
                    { 1052, null, null, 1044, 1, "بمپور" },
                    { 1051, null, null, 1044, 1, "ایرانشهر" },
                    { 1050, null, null, 1044, 1, "نوک آباد" },
                    { 1049, null, null, 1044, 1, "خاش" },
                    { 1048, null, null, 1044, 1, "نصرت آباد" },
                    { 1055, null, null, 1044, 1, "چاه بهار" },
                    { 1047, null, null, 1044, 1, "زاهدان" },
                    { 1045, null, null, 1044, 1, "زابل" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1044, null, null, 1, null, 1, "سیستان و بلوچستان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 1043, null, null, 1010, 1, "جاورسیان" },
                    { 1042, null, null, 1010, 1, "خنداب" },
                    { 1041, null, null, 1010, 1, "خنجین" },
                    { 1040, null, null, 1010, 1, "فرمهین" },
                    { 1039, null, null, 1010, 1, "میلاجرد" },
                    { 1046, null, null, 1044, 1, "بنجار" },
                    { 1076, null, null, 1044, 1, "مهرستان" },
                    { 1056, null, null, 1044, 1, "نگور" },
                    { 1058, null, null, 1044, 1, "گشت" },
                    { 1074, null, null, 1044, 1, "محمد آباد" },
                    { 1073, null, null, 1044, 1, "ادیمی" },
                    { 1072, null, null, 1044, 1, "زهک" },
                    { 1071, null, null, 1044, 1, "فنوج" },
                    { 1070, null, null, 1044, 1, "هیدوچ" },
                    { 1069, null, null, 1044, 1, "سوران" },
                    { 1068, null, null, 1044, 1, "اسپکه" },
                    { 1057, null, null, 1044, 1, "سراوان" },
                    { 1067, null, null, 1044, 1, "بنت" },
                    { 1065, null, null, 1044, 1, "قصر قند" },
                    { 1064, null, null, 1044, 1, "زرآباد" },
                    { 1063, null, null, 1044, 1, "کنارک" },
                    { 1062, null, null, 1044, 1, "میرجاوه" },
                    { 1061, null, null, 1044, 1, "سیرکان" },
                    { 1060, null, null, 1044, 1, "جالق" },
                    { 1059, null, null, 1044, 1, "محمدی" },
                    { 1066, null, null, 1044, 1, "نیک شهر" },
                    { 637, null, null, 619, 1, "ایج" },
                    { 641, null, null, 619, 1, "فدامی" },
                    { 635, null, null, 619, 1, "نوبندگان" },
                    { 215, null, null, 167, 1, "پره سر" },
                    { 214, null, null, 167, 1, "رضوانشهر" },
                    { 213, null, null, 167, 1, "احمد سرگوراب" },
                    { 212, null, null, 167, 1, "شفت" },
                    { 211, null, null, 167, 1, "چوبر" },
                    { 210, null, null, 167, 1, "حویق" },
                    { 209, null, null, 167, 1, "لیسار" },
                    { 208, null, null, 167, 1, "اسالم" },
                    { 207, null, null, 167, 1, "هشتپر" },
                    { 206, null, null, 167, 1, "گوراب زرمیخ" },
                    { 205, null, null, 167, 1, "مرجقل" },
                    { 204, null, null, 167, 1, "صومعه سرا" },
                    { 203, null, null, 167, 1, "بره سر" },
                    { 202, null, null, 167, 1, "توتکابن" },
                    { 201, null, null, 167, 1, "جیرنده" },
                    { 216, null, null, 167, 1, "املش" },
                    { 217, null, null, 167, 1, "رانکوه" },
                    { 218, null, null, 167, 1, "ماسال" },
                    { 219, null, null, 167, 1, "بازار جمعه" },
                    { 235, null, null, 220, 1, "خرمشهر" },
                    { 234, null, null, 220, 1, "الهایی" },
                    { 233, null, null, 220, 1, "اهواز" },
                    { 232, null, null, 220, 1, "اروند کنار" },
                    { 231, null, null, 220, 1, "چوئبده" },
                    { 230, null, null, 220, 1, "آبادان" },
                    { 229, null, null, 220, 1, "چغامیش" },
                    { 200, null, null, 167, 1, "رستم آباد" },
                    { 228, null, null, 220, 1, "حمزه" },
                    { 226, null, null, 220, 1, "سیاه منصور" },
                    { 225, null, null, 220, 1, "شمس آباد" },
                    { 224, null, null, 220, 1, "صفی آباد" },
                    { 223, null, null, 220, 1, "میانرود" },
                    { 222, null, null, 220, 1, "شهر امام" },
                    { 221, null, null, 220, 1, "دزفول" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 220, null, null, 1, null, 1, "خوزستان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 227, null, null, 220, 1, "سالند" },
                    { 199, null, null, 167, 1, "لوشان" },
                    { 198, null, null, 167, 1, "منجیل" },
                    { 197, null, null, 167, 1, "رودبار" },
                    { 176, null, null, 167, 1, "خشکبیجار" },
                    { 175, null, null, 167, 1, "خمام" },
                    { 174, null, null, 167, 1, "لولمان" },
                    { 173, null, null, 167, 1, "کوچصفهان" },
                    { 172, null, null, 167, 1, "سنگر" },
                    { 171, null, null, 167, 1, "رشت" },
                    { 170, null, null, 167, 1, "بندر انزلی" },
                    { 177, null, null, 167, 1, "لشت نشاء" },
                    { 169, null, null, 167, 1, "لوندویل" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 167, null, null, 1, null, 1, "گیلان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 166, null, null, 94, 1, "سلطان آباد" },
                    { 165, null, null, 94, 1, "داورزن" },
                    { 164, null, null, 94, 1, "همت آباد" },
                    { 163, null, null, 94, 1, "فیروزه" },
                    { 162, null, null, 94, 1, "نقاب" },
                    { 161, null, null, 94, 1, "دولت آباد" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 168, null, null, 167, 1, "آستارا" },
                    { 236, null, null, 220, 1, "مقاومت" },
                    { 178, null, null, 167, 1, "لنگرود" },
                    { 180, null, null, 167, 1, "کومله" },
                    { 196, null, null, 167, 1, "آستانه اشرفیه" },
                    { 195, null, null, 167, 1, "کیاشهر" },
                    { 194, null, null, 167, 1, "دیلمان" },
                    { 193, null, null, 167, 1, "سیاهکل" },
                    { 192, null, null, 167, 1, "رودبنه" },
                    { 191, null, null, 167, 1, "لاهیجان" },
                    { 190, null, null, 167, 1, "ماکلوان" },
                    { 179, null, null, 167, 1, "چاف و چمخاله" },
                    { 189, null, null, 167, 1, "ماسوله" },
                    { 187, null, null, 167, 1, "رحیم آباد" },
                    { 186, null, null, 167, 1, "چابکسر" },
                    { 185, null, null, 167, 1, "واجارگاه" },
                    { 184, null, null, 167, 1, "کلاچای" },
                    { 183, null, null, 167, 1, "رودسر" },
                    { 182, null, null, 167, 1, "اطاقور" },
                    { 181, null, null, 167, 1, "شلمان" },
                    { 188, null, null, 167, 1, "فومن" },
                    { 237, null, null, 220, 1, "مینوشهر" },
                    { 238, null, null, 220, 1, "شوشتر" },
                    { 239, null, null, 220, 1, "شرافت" },
                    { 295, null, null, 220, 1, "قلعه خواجه" },
                    { 294, null, null, 220, 1, "حمیدیه" },
                    { 293, null, null, 220, 1, "ویس" },
                    { 292, null, null, 220, 1, "شیبان" },
                    { 291, null, null, 220, 1, "ملاثانی" },
                    { 290, null, null, 220, 1, "لالی" },
                    { 289, null, null, 220, 1, "سماله" },
                    { 296, null, null, 220, 1, "آبژدان" },
                    { 288, null, null, 220, 1, "ترکالکی" },
                    { 286, null, null, 220, 1, "صالح شهر" },
                    { 285, null, null, 220, 1, "گتوند" },
                    { 284, null, null, 220, 1, "میداود" },
                    { 283, null, null, 220, 1, "صیدون" },
                    { 282, null, null, 220, 1, "قلعه تل" },
                    { 281, null, null, 220, 1, "باغ ملک" },
                    { 280, null, null, 220, 1, "هفتگل" },
                    { 287, null, null, 220, 1, "جنت مکان" },
                    { 279, null, null, 220, 1, "مشراگه" },
                    { 297, null, null, 220, 1, "کوت عبدالله" },
                    { 299, null, null, 298, 1, "ماکو" },
                    { 315, null, null, 298, 1, "میاندوآب" },
                    { 636, null, null, 619, 1, "استهبان" },
                    { 313, null, null, 298, 1, "مهاباد" },
                    { 312, null, null, 298, 1, "تکاب" },
                    { 311, null, null, 298, 1, "سیلوانه" },
                    { 310, null, null, 298, 1, "سرو" },
                    { 309, null, null, 298, 1, "نوشین" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 298, null, null, 1, null, 1, "آذربایجان غربی" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 308, null, null, 298, 1, "قوشچی" },
                    { 306, null, null, 298, 1, "زرآباد" },
                    { 305, null, null, 298, 1, "قطور" },
                    { 304, null, null, 298, 1, "ایواوغلی" },
                    { 303, null, null, 298, 1, "دیزج دیز" },
                    { 302, null, null, 298, 1, "فیرورق" },
                    { 301, null, null, 298, 1, "خوی" },
                    { 300, null, null, 298, 1, "بازرگان" },
                    { 307, null, null, 298, 1, "ارومیه" },
                    { 160, null, null, 94, 1, "باخرز" },
                    { 278, null, null, 220, 1, "رامشیر" },
                    { 276, null, null, 220, 1, "مسجد سلیمان" },
                    { 255, null, null, 220, 1, "رفیع" },
                    { 254, null, null, 220, 1, "هویزه" },
                    { 253, null, null, 220, 1, "بستان" },
                    { 252, null, null, 220, 1, "ابوحمیظه" },
                    { 251, null, null, 220, 1, "کوت سیدنعیم" },
                    { 250, null, null, 220, 1, "سوسنگرد" },
                    { 249, null, null, 220, 1, "تشان" },
                    { 256, null, null, 220, 1, "بندر امام خمینی" },
                    { 248, null, null, 220, 1, "سردشت" },
                    { 246, null, null, 220, 1, "بهبهان" },
                    { 245, null, null, 220, 1, "رامهرمز" },
                    { 244, null, null, 220, 1, "خنافره" },
                    { 243, null, null, 220, 1, "دارخوین" },
                    { 242, null, null, 220, 1, "شادگان" },
                    { 241, null, null, 220, 1, "گوریه" },
                    { 240, null, null, 220, 1, "سرداران" },
                    { 247, null, null, 220, 1, "منصوریه" },
                    { 277, null, null, 220, 1, "گلگیر" },
                    { 257, null, null, 220, 1, "بندر ماهشهر" },
                    { 259, null, null, 220, 1, "شوش" },
                    { 275, null, null, 220, 1, "آغاجاری" },
                    { 274, null, null, 220, 1, "جایزان" },
                    { 273, null, null, 220, 1, "امیدیه" },
                    { 272, null, null, 220, 1, "زهره" },
                    { 271, null, null, 220, 1, "هندیجان" },
                    { 270, null, null, 220, 1, "دهدز" },
                    { 269, null, null, 220, 1, "ایذه" },
                    { 258, null, null, 220, 1, "چمران" },
                    { 268, null, null, 220, 1, "بیدروبه" },
                    { 266, null, null, 220, 1, "چم گلک" },
                    { 265, null, null, 220, 1, "آزادی" },
                    { 264, null, null, 220, 1, "اندیمشک" },
                    { 263, null, null, 220, 1, "فتح المبین" },
                    { 262, null, null, 220, 1, "شاوور" },
                    { 261, null, null, 220, 1, "الوان" },
                    { 260, null, null, 220, 1, "حر" },
                    { 267, null, null, 220, 1, "حسینیه" },
                    { 159, null, null, 94, 1, "کندر" },
                    { 158, null, null, 94, 1, "خلیل آباد" },
                    { 157, null, null, 94, 1, "گلمکان" },
                    { 56, null, null, 31, 1, "بناب" },
                    { 55, null, null, 31, 1, "یامچی" },
                    { 54, null, null, 31, 1, "بناب مرند" },
                    { 53, null, null, 31, 1, "کشکسرای" },
                    { 52, null, null, 31, 1, "زنوز" },
                    { 51, null, null, 31, 1, "مرند" },
                    { 50, null, null, 31, 1, "صوفیان" },
                    { 57, null, null, 31, 1, "اسکو" },
                    { 49, null, null, 31, 1, "تسوج" },
                    { 47, null, null, 31, 1, "وایقان" },
                    { 46, null, null, 31, 1, "سیس" },
                    { 45, null, null, 31, 1, "شند آباد" },
                    { 44, null, null, 31, 1, "شرفخانه" },
                    { 43, null, null, 31, 1, "خامنه" },
                    { 42, null, null, 31, 1, "شبستر" },
                    { 41, null, null, 31, 1, "ممقان" },
                    { 48, null, null, 31, 1, "کوزه کنان" },
                    { 40, null, null, 31, 1, "تیمورلو" },
                    { 58, null, null, 31, 1, "شهر جدید سهند" },
                    { 60, null, null, 31, 1, "سراب" },
                    { 76, null, null, 31, 1, "بستان آباد" },
                    { 75, null, null, 31, 1, "نظرکهریزی" },
                    { 74, null, null, 31, 1, "هشترود" },
                    { 73, null, null, 31, 1, "لیلان" },
                    { 72, null, null, 31, 1, "مبارک شهر" },
                    { 71, null, null, 31, 1, "ملکان" },
                    { 70, null, null, 31, 1, "جوان قلعه" },
                    { 59, null, null, 31, 1, "ایلخچی" },
                    { 69, null, null, 31, 1, "عجب شیر" },
                    { 67, null, null, 31, 1, "آقکند" },
                    { 66, null, null, 31, 1, "ترکمانچای" },
                    { 65, null, null, 31, 1, "آچاچی" },
                    { 64, null, null, 31, 1, "میانه" },
                    { 63, null, null, 31, 1, "دوزدوزان" },
                    { 62, null, null, 31, 1, "شربیان" },
                    { 61, null, null, 31, 1, "مهربان" },
                    { 68, null, null, 31, 1, "ترک" },
                    { 77, null, null, 31, 1, "تیکمه داش" },
                    { 39, null, null, 31, 1, "گوگان" },
                    { 37, null, null, 31, 1, "خداجو" },
                    { 16, null, null, 1, 1, "سامن" },
                    { 15, null, null, 1, 1, "ملایر" },
                    { 14, null, null, 1, 1, "فرسفج" },
                    { 13, null, null, 1, 1, "سرکان" },
                    { 12, null, null, 1, 1, "تویسرکان" },
                    { 11, null, null, 1, 1, "آجین" },
                    { 10, null, null, 1, 1, "اسد آباد" },
                    { 17, null, null, 1, 1, "ازندریان" },
                    { 9, null, null, 1, 1, "گیان" },
                    { 7, null, null, 1, 1, "فیروزان" },
                    { 6, null, null, 1, 1, "نهاوند" },
                    { 5, null, null, 1, 1, "قهاوند" },
                    { 4, null, null, 1, 1, "جورقان" },
                    { 3, null, null, 1, 1, "مریانج" },
                    { 2, null, null, 1, 1, "همدان" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 1, null, null, 1, null, 1, "همدان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 8, null, null, 1, 1, "برزول" },
                    { 38, null, null, 31, 1, "آذرشهر" },
                    { 18, null, null, 1, 1, "جوکار" },
                    { 20, null, null, 1, 1, "بهار" },
                    { 36, null, null, 31, 1, "مراغه" },
                    { 35, null, null, 31, 1, "خسروشاه" },
                    { 34, null, null, 31, 1, "سردرود" },
                    { 33, null, null, 31, 1, "باسمنج" },
                    { 32, null, null, 31, 1, "تبریز" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 31, null, null, 1, null, 1, "آذربایجان شرقی" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 30, null, null, 1, 1, "فامنین" },
                    { 19, null, null, 1, 1, "زنگنه" },
                    { 29, null, null, 1, 1, "دمق" },
                    { 27, null, null, 1, 1, "قروه در جزین" },
                    { 26, null, null, 1, 1, "گل تپه" },
                    { 25, null, null, 1, 1, "شیرین سو" },
                    { 24, null, null, 1, 1, "کبودر آهنگ" },
                    { 23, null, null, 1, 1, "صالح آباد" },
                    { 22, null, null, 1, 1, "مهاجران" },
                    { 21, null, null, 1, 1, "لالجین" },
                    { 28, null, null, 1, 1, "رزن" },
                    { 316, null, null, 298, 1, "چهار برج" },
                    { 78, null, null, 31, 1, "هریس" },
                    { 80, null, null, 31, 1, "بخشایش" },
                    { 136, null, null, 94, 1, "جنگل" },
                    { 135, null, null, 94, 1, "رشتخوار" },
                    { 134, null, null, 94, 1, "یونسی" },
                    { 133, null, null, 94, 1, "بجستان" },
                    { 132, null, null, 94, 1, "کاخک" },
                    { 131, null, null, 94, 1, "بیدخت" },
                    { 130, null, null, 94, 1, "گناباد" },
                    { 137, null, null, 94, 1, "درگز" },
                    { 129, null, null, 94, 1, "سفید سنگ" },
                    { 127, null, null, 94, 1, "فرهاد گرد" },
                    { 126, null, null, 94, 1, "فریمان" },
                    { 125, null, null, 94, 1, "ششتمد" },
                    { 124, null, null, 94, 1, "روداب" },
                    { 123, null, null, 94, 1, "سبزوار" },
                    { 122, null, null, 94, 1, "سلامی" },
                    { 121, null, null, 94, 1, "قاسم آباد" },
                    { 128, null, null, 94, 1, "قلندر آباد" },
                    { 120, null, null, 94, 1, "سنگان" },
                    { 138, null, null, 94, 1, "نوخندان" },
                    { 140, null, null, 94, 1, "چاپشلو" },
                    { 156, null, null, 94, 1, "چناران" },
                    { 155, null, null, 94, 1, "شهرآباد" },
                    { 154, null, null, 94, 1, "انابد" },
                    { 153, null, null, 94, 1, "بردسکن" },
                    { 152, null, null, 94, 1, "جغتای" },
                    { 151, null, null, 94, 1, "شادمهر" },
                    { 150, null, null, 94, 1, "فیض آباد" },
                    { 139, null, null, 94, 1, "لطف آباد" },
                    { 149, null, null, 94, 1, "شاندیز" },
                    { 147, null, null, 94, 1, "شهر زو" },
                    { 146, null, null, 94, 1, "کلات" },
                    { 145, null, null, 94, 1, "مشهدریزه" },
                    { 144, null, null, 94, 1, "کاریز" },
                    { 143, null, null, 94, 1, "تایباد" },
                    { 142, null, null, 94, 1, "مزدآوند" },
                    { 141, null, null, 94, 1, "سرخس" },
                    { 148, null, null, 94, 1, "طرقبه" },
                    { 79, null, null, 31, 1, "زرنق" },
                    { 119, null, null, 94, 1, "نشتیفان" },
                    { 117, null, null, 94, 1, "احمدآباد صولت" },
                    { 96, null, null, 94, 1, "ملک آباد" },
                    { 95, null, null, 94, 1, "مشهد" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 94, null, null, 1, null, 1, "خراسان رضوی" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 93, null, null, 31, 1, "خمارلو" },
                    { 92, null, null, 31, 1, "قره آغاج" },
                    { 91, null, null, 31, 1, "خاروانا" },
                    { 90, null, null, 31, 1, "ورزقان" },
                    { 97, null, null, 94, 1, "رضویه" },
                    { 89, null, null, 31, 1, "هوراند" },
                    { 87, null, null, 31, 1, "آبش احمد" },
                    { 86, null, null, 31, 1, "کلیبر" },
                    { 85, null, null, 31, 1, "سیه رود" },
                    { 84, null, null, 31, 1, "هادیشهر" },
                    { 83, null, null, 31, 1, "جلفا" },
                    { 82, null, null, 31, 1, "خواجه" },
                    { 81, null, null, 31, 1, "کلوانق" },
                    { 88, null, null, 31, 1, "اهر" },
                    { 118, null, null, 94, 1, "خواف" },
                    { 98, null, null, 94, 1, "قوچان" },
                    { 100, null, null, 94, 1, "تربت حیدریه" },
                    { 116, null, null, 94, 1, "نیل شهر" },
                    { 115, null, null, 94, 1, "نصرآباد" },
                    { 114, null, null, 94, 1, "صالح آباد" },
                    { 113, null, null, 94, 1, "تربت جام" },
                    { 112, null, null, 94, 1, "چکنه" },
                    { 111, null, null, 94, 1, "عشق آباد" },
                    { 110, null, null, 94, 1, "خرو" },
                    { 99, null, null, 94, 1, "باجگیران" },
                    { 109, null, null, 94, 1, "قدمگاه" },
                    { 107, null, null, 94, 1, "بار" },
                    { 106, null, null, 94, 1, "نیشابور" },
                    { 105, null, null, 94, 1, "ریوش" },
                    { 104, null, null, 94, 1, "کاشمر" },
                    { 103, null, null, 94, 1, "رباط سنگ" },
                    { 102, null, null, 94, 1, "بایک" },
                    { 101, null, null, 94, 1, "کدکن" },
                    { 108, null, null, 94, 1, "درود" },
                    { 317, null, null, 298, 1, "باروق" },
                    { 314, null, null, 298, 1, "خلیفان" },
                    { 319, null, null, 298, 1, "محمود آباد" },
                    { 534, null, null, 516, 1, "سگز آباد" },
                    { 533, null, null, 516, 1, "بوئین زهرا" },
                    { 532, null, null, 516, 1, "آبگرم" },
                    { 531, null, null, 516, 1, "آوج" },
                    { 530, null, null, 516, 1, "خاکعلی" },
                    { 529, null, null, 516, 1, "آبیک" },
                    { 528, null, null, 516, 1, "خرمدشت" },
                    { 527, null, null, 516, 1, "ضیاء آباد" },
                    { 526, null, null, 516, 1, "اسفرورین" },
                    { 525, null, null, 516, 1, "نرجه" },
                    { 524, null, null, 516, 1, "تاکستان" },
                    { 523, null, null, 516, 1, "سیردان" },
                    { 522, null, null, 516, 1, "کوهین" },
                    { 521, null, null, 516, 1, "رازمیان" },
                    { 520, null, null, 516, 1, "معلم کلایه" },
                    { 535, null, null, 516, 1, "شال" },
                    { 536, null, null, 516, 1, "دانسفهان" },
                    { 537, null, null, 516, 1, "ارداق" },
                    { 538, null, null, 516, 1, "الوند" },
                    { 554, null, null, 542, 1, "گرمی" },
                    { 553, null, null, 542, 1, "کلور" },
                    { 552, null, null, 542, 1, "هشتجین" },
                    { 551, null, null, 542, 1, "خلخال" },
                    { 550, null, null, 542, 1, "قصابه" },
                    { 549, null, null, 542, 1, "مرادلو" },
                    { 548, null, null, 542, 1, "فخرآباد" },
                    { 519, null, null, 516, 1, "محمود آباد نمونه" },
                    { 547, null, null, 542, 1, "لاهرود" },
                    { 545, null, null, 542, 1, "مشگین شهر" },
                    { 544, null, null, 542, 1, "هیر" },
                    { 543, null, null, 542, 1, "اردبیل" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 542, null, null, 1, null, 1, "اردبیل" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 541, null, null, 516, 1, "شریفیه" },
                    { 540, null, null, 516, 1, "بیدستان" },
                    { 539, null, null, 516, 1, "محمدیه" },
                    { 546, null, null, 542, 1, "رضی" },
                    { 518, null, null, 516, 1, "اقبالیه" },
                    { 517, null, null, 516, 1, "قزوین" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 516, null, null, 1, null, 1, "قزوین" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[] { 495, null, null, 494, 1, "زنجان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 494, null, null, 1, null, 1, "زنجان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 493, null, null, 450, 1, "صفادشت" },
                    { 492, null, null, 450, 1, "ملارد" },
                    { 491, null, null, 450, 1, "صالحیه" },
                    { 490, null, null, 450, 1, "نصیرشهر" },
                    { 489, null, null, 450, 1, "گلستان" },
                    { 496, null, null, 494, 1, "ارمخانخانه" },
                    { 488, null, null, 450, 1, "نسیم شهر" },
                    { 486, null, null, 450, 1, "فرون آباد" },
                    { 485, null, null, 450, 1, "پاکدشت" },
                    { 484, null, null, 450, 1, "قدس" },
                    { 483, null, null, 450, 1, "شهر جدید پرند" },
                    { 318, null, null, 298, 1, "شاهین دژ" },
                    { 481, null, null, 450, 1, "چهاردانگه" },
                    { 480, null, null, 450, 1, "اسلامشهر" },
                    { 487, null, null, 450, 1, "شریف آباد" },
                    { 555, null, null, 542, 1, "تازه کند انگوت" },
                    { 497, null, null, 494, 1, "نیک پی" },
                    { 499, null, null, 494, 1, "هیدج" },
                    { 515, null, null, 494, 1, "حلب" },
                    { 514, null, null, 494, 1, "زرین آباد" },
                    { 513, null, null, 494, 1, "چورزق" },
                    { 512, null, null, 494, 1, "آب بر" },
                    { 511, null, null, 494, 1, "دندی" },
                    { 510, null, null, 494, 1, "ماه نشان" },
                    { 509, null, null, 494, 1, "زرین رود" },
                    { 498, null, null, 494, 1, "ابهر" },
                    { 508, null, null, 494, 1, "سجاس" },
                    { 506, null, null, 494, 1, "نوربهار" },
                    { 505, null, null, 494, 1, "کرسف" },
                    { 504, null, null, 494, 1, "سهرورد" },
                    { 503, null, null, 494, 1, "قیدار" },
                    { 502, null, null, 494, 1, "سلطانیه" },
                    { 501, null, null, 494, 1, "خرمدره" },
                    { 500, null, null, 494, 1, "صائین قلعه" },
                    { 507, null, null, 494, 1, "گرماب" },
                    { 556, null, null, 542, 1, "گیوی" },
                    { 557, null, null, 542, 1, "نمین" },
                    { 558, null, null, 542, 1, "آبی بیگلو" },
                    { 614, null, null, 598, 1, "گرمسار" },
                    { 613, null, null, 598, 1, "شهمیرزاد" },
                    { 612, null, null, 598, 1, "درجزین" },
                    { 611, null, null, 598, 1, "مهدی شهر" },
                    { 610, null, null, 598, 1, "امیریه" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 609, null, null, 598, 1, "کلاته" },
                    { 608, null, null, 598, 1, "دیباج" },
                    { 615, null, null, 598, 1, "ایوانکی" },
                    { 607, null, null, 598, 1, "دامغان" },
                    { 605, null, null, 598, 1, "کلاته خیج" },
                    { 604, null, null, 598, 1, "مجن" },
                    { 603, null, null, 598, 1, "بسطام" },
                    { 602, null, null, 598, 1, "رودیان" },
                    { 601, null, null, 598, 1, "شاهرود" },
                    { 600, null, null, 598, 1, "سرخه" },
                    { 599, null, null, 598, 1, "سمنان" },
                    { 606, null, null, 598, 1, "بیارجمند" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 598, null, null, 1, null, 1, "سمنان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 616, null, null, 598, 1, "آرادان" },
                    { 618, null, null, 598, 1, "میامی" },
                    { 634, null, null, 619, 1, "میانشهر" },
                    { 633, null, null, 619, 1, "زاهد شهر" },
                    { 632, null, null, 619, 1, "قره بلاغ" },
                    { 631, null, null, 619, 1, "ششده" },
                    { 630, null, null, 619, 1, "فسا" },
                    { 629, null, null, 619, 1, "دوزه" },
                    { 628, null, null, 619, 1, "قطب آباد" },
                    { 617, null, null, 598, 1, "کهن آباد" },
                    { 627, null, null, 619, 1, "باب انار" },
                    { 625, null, null, 619, 1, "جهرم" },
                    { 624, null, null, 619, 1, "سورمق" },
                    { 623, null, null, 619, 1, "ایزد خواست" },
                    { 622, null, null, 619, 1, "بهمن" },
                    { 621, null, null, 619, 1, "صغاد" },
                    { 620, null, null, 619, 1, "آباده" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 619, null, null, 1, null, 1, "فارس" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 626, null, null, 619, 1, "خاوران" },
                    { 479, null, null, 450, 1, "قرچک" },
                    { 597, null, null, 569, 1, "زهان" },
                    { 595, null, null, 569, 1, "گزیک" },
                    { 574, null, null, 569, 1, "عشق آباد" },
                    { 573, null, null, 569, 1, "طبس" },
                    { 572, null, null, 569, 1, "بیرجند" },
                    { 571, null, null, 569, 1, "اسلامیه" },
                    { 570, null, null, 569, 1, "فردوس" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 569, null, null, 1, null, 1, "خراسان جنوبی" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 568, null, null, 542, 1, "جعفر آباد" },
                    { 575, null, null, 569, 1, "دیهوک" },
                    { 567, null, null, 542, 1, "بیله سوار" },
                    { 565, null, null, 542, 1, "اسلام آباد" },
                    { 564, null, null, 542, 1, "تازه کند" },
                    { 563, null, null, 542, 1, "اصلاندوز" },
                    { 562, null, null, 542, 1, "پارس آباد" },
                    { 561, null, null, 542, 1, "کورائیم" },
                    { 560, null, null, 542, 1, "نیر" },
                    { 559, null, null, 542, 1, "عنبران" },
                    { 566, null, null, 542, 1, "سرعین" },
                    { 596, null, null, 569, 1, "حاجی آباد" },
                    { 576, null, null, 569, 1, "قائن" },
                    { 578, null, null, 569, 1, "خضری دشت بیاض" },
                    { 594, null, null, 569, 1, "طبس مسینا" },
                    { 593, null, null, 569, 1, "قهستان" },
                    { 592, null, null, 569, 1, "اسدیه" },
                    { 591, null, null, 569, 1, "محمدشهر" },
                    { 590, null, null, 569, 1, "خوسف" },
                    { 589, null, null, 569, 1, "مود" },
                    { 588, null, null, 569, 1, "سربیشه" },
                    { 577, null, null, 569, 1, "اسفدن" },
                    { 587, null, null, 569, 1, "شوسف" },
                    { 585, null, null, 569, 1, "ارسک" },
                    { 584, null, null, 569, 1, "بشرویه" },
                    { 583, null, null, 569, 1, "سه قلعه" },
                    { 582, null, null, 569, 1, "آیسک" },
                    { 581, null, null, 569, 1, "سرایان" },
                    { 580, null, null, 569, 1, "آرین شهر" },
                    { 579, null, null, 569, 1, "نیمبلوک" },
                    { 586, null, null, 569, 1, "نهبندان" },
                    { 478, null, null, 450, 1, "شمشک" },
                    { 482, null, null, 450, 1, "رباط کریم" },
                    { 476, null, null, 450, 1, "لواسان" },
                    { 375, null, null, 341, 1, "جیرفت" },
                    { 374, null, null, 341, 1, "یزدان شهر" },
                    { 373, null, null, 341, 1, "ریحان" },
                    { 372, null, null, 341, 1, "خانوک" },
                    { 371, null, null, 341, 1, "زرند" },
                    { 370, null, null, 341, 1, "بزنجان" },
                    { 369, null, null, 341, 1, "بافت" },
                    { 376, null, null, 341, 1, "جبالبارز" },
                    { 368, null, null, 341, 1, "بلورد" },
                    { 366, null, null, 341, 1, "هماشهر" },
                    { 365, null, null, 341, 1, "پاریز" },
                    { 364, null, null, 341, 1, "نجف شهر" },
                    { 363, null, null, 341, 1, "زید آباد" },
                    { 362, null, null, 341, 1, "سیرجان" },
                    { 361, null, null, 341, 1, "صفائیه" },
                    { 360, null, null, 341, 1, "بهرمان" },
                    { 367, null, null, 341, 1, "خواجوشهر" },
                    { 359, null, null, 341, 1, "کشکوئیه" },
                    { 377, null, null, 341, 1, "درب بهشت" },
                    { 379, null, null, 341, 1, "شهر بابک" },
                    { 395, null, null, 341, 1, "کوهبنان" },
                    { 394, null, null, 341, 1, "هنزا" },
                    { 477, null, null, 450, 1, "فشم" },
                    { 392, null, null, 341, 1, "هجدک" },
                    { 391, null, null, 341, 1, "راور" },
                    { 390, null, null, 341, 1, "امین شهر" },
                    { 389, null, null, 341, 1, "انار" },
                    { 378, null, null, 341, 1, "بلوک" },
                    { 388, null, null, 341, 1, "لاله زار" },
                    { 386, null, null, 341, 1, "نگار" },
                    { 385, null, null, 341, 1, "گلزار" },
                    { 384, null, null, 341, 1, "بردسیر" },
                    { 383, null, null, 341, 1, "جوزم" },
                    { 382, null, null, 341, 1, "دهج" },
                    { 381, null, null, 341, 1, "خاتون آباد" },
                    { 380, null, null, 341, 1, "خورسند" },
                    { 387, null, null, 341, 1, "دشتکار" },
                    { 396, null, null, 341, 1, "کیانشهر" },
                    { 358, null, null, 341, 1, "مس سرچشمه" },
                    { 356, null, null, 341, 1, "بروات" },
                    { 335, null, null, 298, 1, "آواجیق" },
                    { 334, null, null, 298, 1, "سیه چشمه" },
                    { 333, null, null, 298, 1, "گردکشانه" },
                    { 332, null, null, 298, 1, "پیرانشهر" },
                    { 331, null, null, 298, 1, "مرگنلر" },
                    { 330, null, null, 298, 1, "شوط" },
                    { 329, null, null, 298, 1, "نالوس" },
                    { 336, null, null, 298, 1, "قره ضیاء الدین" },
                    { 328, null, null, 298, 1, "اشنویه" },
                    { 326, null, null, 298, 1, "نقده" },
                    { 325, null, null, 298, 1, "میرآباد" },
                    { 324, null, null, 298, 1, "ربط" },
                    { 323, null, null, 298, 1, "سردشت" },
                    { 322, null, null, 298, 1, "سیمینه" },
                    { 321, null, null, 298, 1, "بوکان" },
                    { 320, null, null, 298, 1, "کشاورز" },
                    { 327, null, null, 298, 1, "محمد یار" },
                    { 357, null, null, 341, 1, "رفسنجان" },
                    { 337, null, null, 298, 1, "سلماس" },
                    { 339, null, null, 298, 1, "پلدشت" },
                    { 355, null, null, 341, 1, "بم" },
                    { 354, null, null, 341, 1, "کاظم آباد" },
                    { 353, null, null, 341, 1, "چترود" },
                    { 352, null, null, 341, 1, "گلباف" },
                    { 351, null, null, 341, 1, "اندوهجرد" },
                    { 350, null, null, 341, 1, "شهداد" },
                    { 349, null, null, 341, 1, "راین" },
                    { 338, null, null, 298, 1, "تازه شهر" },
                    { 348, null, null, 341, 1, "محی آباد" },
                    { 346, null, null, 341, 1, "ماهان" },
                    { 345, null, null, 341, 1, "اختیار آباد" },
                    { 344, null, null, 341, 1, "زنگی آباد" },
                    { 343, null, null, 341, 1, "باغین" },
                    { 342, null, null, 341, 1, "کرمان" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 341, null, null, 1, null, 1, "کرمان" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 340, null, null, 298, 1, "نازک علیا" },
                    { 347, null, null, 341, 1, "جوپار" },
                    { 397, null, null, 341, 1, "کهنوج" },
                    { 393, null, null, 341, 1, "رابر" },
                    { 399, null, null, 341, 1, "دوساری" },
                    { 455, null, null, 450, 1, "پردیس" },
                    { 454, null, null, 450, 1, "بومهن" },
                    { 453, null, null, 450, 1, "تهران" },
                    { 452, null, null, 450, 1, "ارجمند" },
                    { 451, null, null, 450, 1, "فیروزکوه" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 450, null, null, 1, null, 1, "تهران" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 449, null, null, 413, 1, "نخل تقی" },
                    { 456, null, null, 450, 1, "دماوند" },
                    { 448, null, null, 413, 1, "عسلویه" },
                    { 446, null, null, 413, 1, "ریز" },
                    { 445, null, null, 413, 1, "جم" },
                    { 444, null, null, 413, 1, "بردخون" },
                    { 443, null, null, 413, 1, "دوراهک" },
                    { 398, null, null, 341, 1, "عنبر آباد" },
                    { 441, null, null, 413, 1, "آبدان" },
                    { 440, null, null, 413, 1, "بندر دیر" },
                    { 447, null, null, 413, 1, "انارستان" },
                    { 439, null, null, 413, 1, "دلوار" },
                    { 457, null, null, 450, 1, "کیلان" },
                    { 459, null, null, 450, 1, "رودهن" },
                    { 475, null, null, 450, 1, "تجریش" },
                    { 474, null, null, 450, 1, "کهریزک" },
                    { 473, null, null, 450, 1, "باقرشهر" },
                    { 472, null, null, 450, 1, "حسن آباد" },
                    { 471, null, null, 450, 1, "ری" },
                    { 470, null, null, 450, 1, "پیشوا" },
                    { 469, null, null, 450, 1, "باغستان" },
                    { 458, null, null, 450, 1, "آبسرد" },
                    { 468, null, null, 450, 1, "اندیشه" },
                    { 466, null, null, 450, 1, "شاهدشهر" },
                    { 465, null, null, 450, 1, "صبا شهر" },
                    { 464, null, null, 450, 1, "وحیدیه" },
                    { 463, null, null, 450, 1, "شهریار" },
                    { 462, null, null, 450, 1, "جواد آباد" },
                    { 461, null, null, 450, 1, "ورامین" },
                    { 460, null, null, 450, 1, "آبعلی" },
                    { 467, null, null, 450, 1, "فردوسیه" },
                    { 438, null, null, 413, 1, "آباد" },
                    { 442, null, null, 413, 1, "بردستان" },
                    { 436, null, null, 413, 1, "بندر ریگ" },
                    { 415, null, null, 413, 1, "چغادک" },
                    { 414, null, null, 413, 1, "بوشهر" },
                    { 437, null, null, 413, 1, "اهرم" },
                    { 412, null, null, 341, 1, "فاریاب" },
                    { 411, null, null, 341, 1, "نظام شهر" },
                    { 410, null, null, 341, 1, "نرماشیر" },
                    { 409, null, null, 341, 1, "گنبکی" },
                    { 416, null, null, 413, 1, "خارک" },
                    { 408, null, null, 341, 1, "محمد آباد" },
                    { 406, null, null, 341, 1, "فهرج" },
                    { 405, null, null, 341, 1, "زهکلوت" },
                    { 404, null, null, 341, 1, "رودبار" },
                    { 403, null, null, 341, 1, "نودژ" },
                    { 402, null, null, 341, 1, "منوجان" },
                    { 401, null, null, 341, 1, "قلعه گنج" },
                    { 400, null, null, 341, 1, "مردهک" },
                    { 407, null, null, 341, 1, "ارزوئیه" },
                    { 417, null, null, 413, 1, "برازجان" }
                });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "Kind", "ParentId", "Status", "Title" },
                values: new object[] { 413, null, null, 1, null, 1, "بوشهر" });

            migrationBuilder.InsertData(
                table: "System.Cities",
                columns: new[] { "Id", "Code", "Description", "ParentId", "Status", "Title" },
                values: new object[,]
                {
                    { 419, null, null, 413, 1, "سعد آباد" },
                    { 435, null, null, 413, 1, "بندر گناوه" },
                    { 434, null, null, 413, 1, "سیراف" },
                    { 433, null, null, 413, 1, "بنک" },
                    { 418, null, null, 413, 1, "دالکی" },
                    { 431, null, null, 413, 1, "امام حسن" },
                    { 430, null, null, 413, 1, "بندر دیلم" },
                    { 429, null, null, 413, 1, "شنبه" },
                    { 428, null, null, 413, 1, "بادوله" },
                    { 432, null, null, 413, 1, "بندر کنگان" },
                    { 426, null, null, 413, 1, "خورموج" },
                    { 425, null, null, 413, 1, "بوشکان" },
                    { 424, null, null, 413, 1, "کلمه" },
                    { 423, null, null, 413, 1, "تنگ ارم" },
                    { 422, null, null, 413, 1, "آبپخش" },
                    { 421, null, null, 413, 1, "شبانکاره" },
                    { 420, null, null, 413, 1, "وحدتیه" },
                    { 427, null, null, 413, 1, "کاکی" }
                });

            migrationBuilder.InsertData(
                table: "System.Currencies",
                columns: new[] { "Id", "Description", "IsBase", "Rate", "Sign", "Status", "Title" },
                values: new object[,]
                {
                    { 2, null, false, 0.1m, "T", 1, "تومان" },
                    { 1, null, true, 1m, "ریال", 1, "ریال" }
                });

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
                name: "IX_System.Websites_DefaultCurrencyId",
                table: "System.Websites",
                column: "DefaultCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Posts_ProductId",
                table: "Content.Posts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Customers_UserId",
                table: "Shop.Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Invoices_CustomerId",
                table: "Shop.Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Invoices_ShippingAddressId",
                table: "Shop.Invoices",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Invoices_ShippingId",
                table: "Shop.Invoices",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Orders_InvoiceId",
                table: "Shop.Orders",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Orders_ProductId",
                table: "Shop.Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Orders_ShippingAddressId",
                table: "Shop.Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Orders_ShippingId",
                table: "Shop.Orders",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Payments_CustomerId",
                table: "Shop.Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Payments_InvoiceId",
                table: "Shop.Payments",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Product_Prices_CreatorUserId",
                table: "Shop.Product_Prices",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Product_Prices_ModifierUserId",
                table: "Shop.Product_Prices",
                column: "ModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Product_Prices_ProductId",
                table: "Shop.Product_Prices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Product_Reviews_CustomerId",
                table: "Shop.Product_Reviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Product_Reviews_ModifierUserId",
                table: "Shop.Product_Reviews",
                column: "ModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Product_Reviews_ProductId",
                table: "Shop.Product_Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.ProductMeta_LangId",
                table: "Shop.ProductMeta",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.ProductMeta_ProductId",
                table: "Shop.ProductMeta",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Products_BrandId",
                table: "Shop.Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Products_CategoryId",
                table: "Shop.Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Products_VendorId",
                table: "Shop.Products",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Shipping_Addresses_CityId",
                table: "Shop.Shipping_Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Shipping_Addresses_CustomerId",
                table: "Shop.Shipping_Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop.Vendors_UserId",
                table: "Shop.Vendors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Content.Posts_Shop.Products_ProductId",
                table: "Content.Posts",
                column: "ProductId",
                principalTable: "Shop.Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_System.Websites_System.Currencies_DefaultCurrencyId",
                table: "System.Websites",
                column: "DefaultCurrencyId",
                principalTable: "System.Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content.Posts_Shop.Products_ProductId",
                table: "Content.Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_System.Websites_System.Currencies_DefaultCurrencyId",
                table: "System.Websites");

            migrationBuilder.DropTable(
                name: "Shop.Orders");

            migrationBuilder.DropTable(
                name: "Shop.Payments");

            migrationBuilder.DropTable(
                name: "Shop.Product_Prices");

            migrationBuilder.DropTable(
                name: "Shop.Product_Reviews");

            migrationBuilder.DropTable(
                name: "Shop.ProductMeta");

            migrationBuilder.DropTable(
                name: "System.Currencies");

            migrationBuilder.DropTable(
                name: "Shop.Invoices");

            migrationBuilder.DropTable(
                name: "Shop.Products");

            migrationBuilder.DropTable(
                name: "Shop.Shipping_Addresses");

            migrationBuilder.DropTable(
                name: "Shop.Shippings");

            migrationBuilder.DropTable(
                name: "Shop.Brands");

            migrationBuilder.DropTable(
                name: "Shop.Vendors");

            migrationBuilder.DropTable(
                name: "System.Cities");

            migrationBuilder.DropTable(
                name: "Shop.Customers");

            migrationBuilder.DropIndex(
                name: "IX_System.Websites_DefaultCurrencyId",
                table: "System.Websites");

            migrationBuilder.DropIndex(
                name: "IX_Content.Posts_ProductId",
                table: "Content.Posts");

            migrationBuilder.DropColumn(
                name: "DefaultCurrencyId",
                table: "System.Websites");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Content.Posts");

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
