using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetSwagStore.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Sort = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalPaymentId = table.Column<string>(type: "TEXT", nullable: false),
                    PurchasedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingStreet = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingCity = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingStateOrProvince = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingPostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingCountry = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false, collation: "NOCASE"),
                    Description = table.Column<string>(type: "TEXT", nullable: false, collation: "NOCASE"),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    DiscountPrice = table.Column<double>(type: "REAL", nullable: true),
                    CurrentInventory = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Manufacturer = table.Column<string>(type: "TEXT", nullable: false),
                    ProductOptionName = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalCost = table.Column<double>(type: "REAL", nullable: false),
                    CurrentInventory = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOption_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductOptionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShoppingCartId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ProductOption_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Sort" },
                values: new object[] { 1, ".NET", 1 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Sort" },
                values: new object[] { 2, "Other", 5 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Sort" },
                values: new object[] { 3, "Web", 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Sort" },
                values: new object[] { 4, "Java", 3 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Sort" },
                values: new object[] { 5, "Performance", 4 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 1, null, "JetBrains Rider, the premiere IDE for .NET developers. Show folks your love for Rider with this stylish T-Shirt.", null, "Rider.jpg", "JetBrains", "Rider T-Shirt", 35.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 2, 100, "AppCode for building your iOS applications without the need for XCode. Looking so swift in this cotton shirt.", null, "AppCode.jpg", "JetBrains", "AppCode T-Shirt", 35.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 3, 100, "Look stylish in this 100% cotton T-Shirt while dropping tables like a boss. DataGrip users represent!", null, "DataGrip.jpg", "JetBrains", "DataGrip T-Shirt", 40.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 4, 100, "Allocate a few dollars to your style while finding pesky memory leaks in this one-of-a-kind T-Shirt.", null, "DotMemory.jpg", "JetBrains", "DotMemory T-Shirt", 30.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 5, 100, "Be sure to add this to your clothes library. You'll have everyone taking a peek at this stylish T-shirt.", null, "DotPeek.jpg", "JetBrains", "DotPeek T-Shirt", 40.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 6, 100, "The snug fit T-Shirt will trace around your physique perfectly. One of the most comfortable shirts you'll own.", null, "DotTrace.jpg", "JetBrains", "DotTrace T-Shirt", 30.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 7, null, "Look Intelli-cute in this 100% cotton T-Shirt. Java never looked this good.", 30.0, "IntelliJ.jpg", "JetBrains", "IntelliJ T-Shirt", 40.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 8, 100, "Not only C#, but look sharp in this forward-thinking design. Stand-out in this beautifully crafted attire.", 30.0, "ReSharper.jpg", "JetBrains", "ReSharper T-Shirt", 40.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CurrentInventory", "Description", "DiscountPrice", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[] { 9, 100, "Storm the web scene with this one-of-a-kind outfit. Import this T-shirt into your collection right away.", null, "WebStorm.jpg", "JetBrains", "WebStorm T-Shirt", 30.0 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 1, 8 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 4, 7 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 5, 6 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 5, 8 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 3, 9 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CategoryProduct",
                columns: new[] { "CategoriesId", "ProductsId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 5, 20.0, 20, "XX-Large", 1 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 4, 10.0, 20, "X-Large", 1 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 6, 0.0, 20, "Small", 7 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 7, 0.0, 20, "Medium", 7 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 8, 5.0, 20, "Large", 7 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 9, 10.0, 20, "X-Large", 7 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 10, 20.0, 20, "XX-Large", 7 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 3, 5.0, 20, "Large", 1 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 2, 0.0, 20, "Medium", 1 });

            migrationBuilder.InsertData(
                table: "ProductOption",
                columns: new[] { "Id", "AdditionalCost", "CurrentInventory", "Name", "ProductId" },
                values: new object[] { 1, 0.0, 20, "Small", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_ProductId",
                table: "ProductOption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductId",
                table: "ShoppingCartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductOptionId",
                table: "ShoppingCartItem",
                column: "ProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductOption");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
