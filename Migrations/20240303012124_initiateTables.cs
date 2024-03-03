using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MerchShop.Migrations
{
    /// <inheritdoc />
    public partial class initiateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    WebURL = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    OverallRating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseNumber = table.Column<int>(type: "int", nullable: false),
                    ShelfNumber = table.Column<string>(type: "nvarchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merch",
                columns: table => new
                {
                    MerchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    MerchType = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    ItemDescripion = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merch", x => x.MerchID);
                    table.ForeignKey(
                        name: "FK_Merch_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorReviews",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewScore = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorReviews", x => new { x.VendorID, x.CustomerID });
                    table.ForeignKey(
                        name: "FK_VendorReviews_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorReviews_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchID = table.Column<int>(type: "int", nullable: false),
                    WarehouseID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_Merch_MerchID",
                        column: x => x.MerchID,
                        principalTable: "Merch",
                        principalColumn: "MerchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Warehouses_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MerchReviews",
                columns: table => new
                {
                    MerchID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewScore = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchReviews", x => new { x.MerchID, x.CustomerID });
                    table.ForeignKey(
                        name: "FK_MerchReviews_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchReviews_Merch_MerchID",
                        column: x => x.MerchID,
                        principalTable: "Merch",
                        principalColumn: "MerchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orderlines",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderlines", x => new { x.OrderID, x.InventoryID });
                    table.ForeignKey(
                        name: "FK_Orderlines_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderlines_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Email", "FirstName", "LastName", "UserID" },
                values: new object[,]
                {
                    { 1, "emily.rodriguez@example.com", "Emily", "Rodriguez", null },
                    { 2, "james.thompson@example.com", "James", "Thompson", null },
                    { 3, "sophia.patel@example.com", "Sophia", "Patel", null },
                    { 4, "benjamin.garcia@example.com", "Benjamin", "Garcia", null },
                    { 5, "olivia.nguyen@example.com", "Olivia", "Nguyen", null },
                    { 6, "ethan.taylor@example.com", "Ethan", "Taylor", null },
                    { 7, "mia.smith@example.com", "Mia", "Smith", null },
                    { 8, "jacob.martinez@example.com", "Jacob", "Martinez", null },
                    { 9, "ava.johnson@example.com", "Ava", "Johnson", null },
                    { 10, "isabella.brown@example.com", "Isabella", "Brown", null }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Name", "OverallRating", "WebURL" },
                values: new object[,]
                {
                    { 1, "Merch Master", 4.5f, "www.merchmaster.com" },
                    { 2, "Merch Maven", 4.2f, "www.merchmaven.com" },
                    { 3, "Trendy Threads", 4.8f, "www.trendythreads.com" },
                    { 4, "Merch Mania", 4.4f, "www.merchmania.com" },
                    { 5, "Street Smart Apparel", 4.7f, "www.streetsmartapparel.com" },
                    { 6, "Magic Merch", 4.3f, "www.magicmerch.com" },
                    { 7, "Merch Mode", 4.6f, "www.merchmode.com" },
                    { 8, "Mademoiselle Merch", 4.1f, "www.mademoisellemerch.com" },
                    { 9, "Merch Marvel", 4.9f, "www.merchmarvel.com" },
                    { 10, "Vogue Vibes", 4f, "www.voguevibes.com" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseID", "ShelfNumber", "WarehouseNumber" },
                values: new object[,]
                {
                    { 1, "One", 0 },
                    { 2, "Two", 0 },
                    { 3, "Three", 0 },
                    { 4, "Four", 0 },
                    { 5, "One", 1 },
                    { 6, "Two", 1 },
                    { 7, "Three", 1 },
                    { 8, "Four", 1 },
                    { 9, "One", 2 },
                    { 10, "Two", 2 },
                    { 11, "Three", 2 },
                    { 12, "Four", 2 }
                });

            migrationBuilder.InsertData(
                table: "Merch",
                columns: new[] { "MerchID", "ItemDescripion", "ItemName", "MerchType", "Rating", "VendorID" },
                values: new object[,]
                {
                    { 1, "", "Cotton T-Shirt", 0, 0f, 5 },
                    { 2, "", "Non-Slip Fuzzy Socks", 0, 0f, 2 },
                    { 3, "", "Adjustable Baseball Cap", 0, 0f, 7 },
                    { 4, "", "Reusable Car Decal", 2, 0f, 3 },
                    { 5, "", "Longboard with Logo", 2, 0f, 8 },
                    { 6, "", "iPhone 14 Phone Case", 1, 0f, 1 },
                    { 7, "", "Portable Power Bank", 1, 0f, 1 },
                    { 8, "", "Hoodie With Drawstring Closure", 0, 0f, 5 },
                    { 9, "", "Customizable Bike Handlebar Grips", 2, 0f, 3 },
                    { 10, "", "Personalized Friendship Bracelets", 0, 0f, 4 },
                    { 11, "", "Logo Wireless Headphones", 1, 0f, 6 },
                    { 12, "", "Custom Photo Car Fresheners", 2, 0f, 10 },
                    { 13, "", "Laptop Sleeve with Custom Photo", 1, 0f, 6 },
                    { 14, "", "Iron-On Clothing Patches", 0, 0f, 9 },
                    { 15, "", "Personalized Writing License Plate Cover", 2, 0f, 8 },
                    { 16, "", "Logo Steering Wheel Covers", 2, 0f, 3 },
                    { 17, "", "Sun Glasses - Custom Print", 0, 0f, 2 },
                    { 18, "", "Stylish Sneakers", 0, 0f, 5 },
                    { 19, "", "Locket Necklace - Upload Photo", 0, 0f, 4 },
                    { 20, "", "Logo Beanie For Cold Weather", 0, 0f, 7 },
                    { 21, "", "Modern Boho Belt", 0, 0f, 9 },
                    { 22, "", "Personalized Key Chain", 2, 0f, 3 },
                    { 23, "", "Character Bobbleheads for Dashboard", 2, 0f, 10 },
                    { 24, "", "Classic Demin Jacket with Patch Kit", 0, 0f, 5 },
                    { 25, "", "Graphic Print T-Shirt", 0, 0f, 10 },
                    { 26, "", "Wireless Phone Charger Car Mount", 1, 0f, 8 },
                    { 27, "", "Custom Image Car Floor Mats", 2, 0f, 5 },
                    { 28, "", "Aesthetic Wireless Charging Pad", 1, 0f, 6 },
                    { 29, "", "Retro Flare Jeans with Custom Embroidery", 0, 0f, 1 },
                    { 30, "", "Car Seat Organizer", 2, 0f, 7 },
                    { 31, "", "Personalized Text - Wireless Earbuds Case", 1, 0f, 5 },
                    { 32, "", "Athletic Jogger Pants", 0, 0f, 2 },
                    { 33, "", "Super Hero Inspired Backpacks", 0, 0f, 4 },
                    { 34, "", "TV Show Character Lunch Boxes", 0, 0f, 6 },
                    { 35, "", "Cute Bluetooth Wireless Speaker", 1, 0f, 8 },
                    { 36, "", "Compact Cable Organizer", 1, 0f, 2 },
                    { 37, "", "Mini Car Trash Can", 2, 0f, 3 },
                    { 38, "", "Printed Silk Scarf", 0, 0f, 10 },
                    { 39, "", "Plaid Flannel Shirt", 0, 0f, 6 },
                    { 40, "", "Custom Photo Reusable Shopping Bag", 0, 0f, 9 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "Date", "Total" },
                values: new object[,]
                {
                    { 1, 9, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 4, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 5, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 7, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 1, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 2, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 6, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 10, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 8, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, 3, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "VendorReviews",
                columns: new[] { "CustomerID", "VendorID", "Date", "ReviewScore", "ReviewText" },
                values: new object[,]
                {
                    { 4, 1, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Fast shipping, would purchase again" },
                    { 3, 2, new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "I am not too impressed with this vendor. The items are sometimes so-so and their customer service is not the best" },
                    { 9, 2, new DateTime(2020, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "The stitching started fraying after about a month. Bummer since I loved wearing that shirt" },
                    { 10, 3, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Absolutely perfect! I am excited to buy more." },
                    { 1, 4, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Not the best quality, but not bad for the price" },
                    { 3, 5, new DateTime(2019, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Fantastic quality! So pleased with my purchase" },
                    { 5, 6, new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Purchased some things for my granddaughter and she loved them." },
                    { 7, 7, new DateTime(2022, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Everything is always great from this vendor, I would recommend them to anyone." },
                    { 2, 9, new DateTime(2018, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "My order was perfect but the shipping took fooorever." },
                    { 8, 10, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Order came quickly" }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryID", "MerchID", "PurchaseDate", "PurchasePrice", "Quantity", "SalePrice", "WarehouseID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.25m, 60, 15.99m, 4 },
                    { 2, 2, new DateTime(2019, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.25m, 150, 7.50m, 5 },
                    { 3, 3, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.75m, 257, 19.95m, 8 },
                    { 4, 4, new DateTime(2020, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.20m, 83, 17.88m, 6 },
                    { 5, 5, new DateTime(2021, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.45m, 360, 5.56m, 3 },
                    { 6, 6, new DateTime(2018, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.75m, 184, 23.15m, 1 },
                    { 7, 7, new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.75m, 347, 11.50m, 10 },
                    { 8, 8, new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m, 218, 6.99m, 12 },
                    { 9, 9, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 13.25m, 425, 17.85m, 6 },
                    { 10, 10, new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.00m, 40, 65.99m, 5 },
                    { 11, 11, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.75m, 281, 45.88m, 11 },
                    { 12, 12, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.25m, 204, 10.55m, 9 },
                    { 13, 13, new DateTime(2017, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.75m, 82, 12.54m, 1 },
                    { 14, 14, new DateTime(2019, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.50m, 174, 8.12m, 3 },
                    { 15, 15, new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.20m, 246, 5.45m, 5 },
                    { 16, 16, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.50m, 129, 14.87m, 11 },
                    { 17, 17, new DateTime(2021, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.25m, 95, 25.35m, 10 },
                    { 18, 18, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.50m, 63, 16.21m, 12 },
                    { 19, 19, new DateTime(2019, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.75m, 142, 11.32m, 6 },
                    { 20, 20, new DateTime(2021, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.75m, 276, 8.31m, 2 },
                    { 21, 21, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.50m, 101, 31.57m, 7 },
                    { 22, 22, new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.75m, 165, 28.16m, 9 },
                    { 23, 23, new DateTime(2019, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.25m, 144, 19.54m, 1 },
                    { 24, 24, new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.50m, 297, 30.54m, 4 },
                    { 25, 25, new DateTime(2021, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.75m, 26, 9.95m, 9 },
                    { 26, 26, new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.75m, 258, 15.50m, 7 },
                    { 27, 27, new DateTime(2018, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.50m, 34, 10.05m, 3 },
                    { 28, 28, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.25m, 208, 7.74m, 8 },
                    { 29, 29, new DateTime(2020, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.75m, 25, 55.90m, 10 },
                    { 30, 30, new DateTime(2022, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.75m, 140, 14.32m, 1 },
                    { 31, 31, new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.75m, 275, 11.95m, 11 },
                    { 32, 32, new DateTime(2022, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.50m, 129, 19.78m, 5 },
                    { 33, 33, new DateTime(2020, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.25m, 66, 29.35m, 2 },
                    { 34, 34, new DateTime(2019, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.50m, 152, 9.12m, 6 },
                    { 35, 35, new DateTime(2021, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.75m, 104, 49.99m, 8 },
                    { 36, 36, new DateTime(2020, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.50m, 96, 25.50m, 4 },
                    { 37, 37, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.25m, 188, 10.32m, 7 },
                    { 38, 38, new DateTime(2021, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.75m, 118, 14.50m, 9 },
                    { 39, 39, new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.25m, 107, 27.98m, 12 },
                    { 40, 40, new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.50m, 64, 6.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "MerchReviews",
                columns: new[] { "CustomerID", "MerchID", "Date", "ReviewScore", "ReviewText" },
                values: new object[,]
                {
                    { 7, 7, new DateTime(2022, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Item smelled strongly of chemicals. I returned it immediately." },
                    { 2, 9, new DateTime(2018, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "My order was perfect but the shipping took fooorever." },
                    { 9, 11, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "I love everything about it!" },
                    { 5, 12, new DateTime(2020, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Came as advertised, nothing special about it though." },
                    { 4, 15, new DateTime(2019, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Great product." },
                    { 10, 17, new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Could not be happier with my purchase" },
                    { 6, 25, new DateTime(2019, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Great item, great customer service" },
                    { 3, 26, new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "It was almost perfect! The seams are really itchy and I have to wear an undershirt." },
                    { 8, 30, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Well, its not Gucci but it gets the job done..." },
                    { 1, 40, new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "It has been about 3 months since I purchased and it is already starting to show signs of wear." }
                });

            migrationBuilder.InsertData(
                table: "Orderlines",
                columns: new[] { "InventoryID", "OrderID", "Quantity", "SubTotal" },
                values: new object[,]
                {
                    { 2, 1, 2, null },
                    { 21, 1, 3, null },
                    { 17, 2, 3, null },
                    { 6, 4, 1, null },
                    { 19, 5, 2, null },
                    { 35, 6, 1, null },
                    { 17, 7, 1, null },
                    { 21, 7, 1, null },
                    { 19, 8, 3, null },
                    { 7, 9, 2, null },
                    { 20, 10, 2, null },
                    { 29, 10, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerID",
                table: "AspNetUsers",
                column: "CustomerID",
                unique: true,
                filter: "[CustomerID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_MerchID",
                table: "Inventory",
                column: "MerchID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_WarehouseID",
                table: "Inventory",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Merch_VendorID",
                table: "Merch",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_MerchReviews_CustomerID",
                table: "MerchReviews",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderlines_InventoryID",
                table: "Orderlines",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorReviews_CustomerID",
                table: "VendorReviews",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MerchReviews");

            migrationBuilder.DropTable(
                name: "Orderlines");

            migrationBuilder.DropTable(
                name: "VendorReviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Merch");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
