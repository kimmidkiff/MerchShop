using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MerchShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customers_CustomerID",
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
                name: "Orderline",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderline", x => new { x.OrderID, x.InventoryID });
                    table.ForeignKey(
                        name: "FK_Orderline_Inventory_InventoryID",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orderline_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "Protective phone case created with polycarbonate and TPU materials for the iPhone 14.", "Protective Phone Case for iPhone 14", 1, 3f, 9 },
                    { 2, "High quality cotton baseball cap with adjustable closure to fit most head sizes.", "Cotton Baseball Cap", 0, 4f, 3 }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryID", "MerchID", "PurchaseDate", "PurchasePrice", "Quantity", "SalePrice", "WarehouseID" },
                values: new object[] { 1, 2, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.50m, 243, 14.99m, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_MerchID",
                table: "Inventory",
                column: "MerchID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_WarehouseID",
                table: "Inventory",
                column: "WarehouseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Merch_VendorID",
                table: "Merch",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_MerchReviews_CustomerID",
                table: "MerchReviews",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orderline_InventoryID",
                table: "Orderline",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorReviews_CustomerID",
                table: "VendorReviews",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchReviews");

            migrationBuilder.DropTable(
                name: "Orderline");

            migrationBuilder.DropTable(
                name: "VendorReviews");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Order");

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
