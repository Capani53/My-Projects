using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HiFiApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false)
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
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HiFis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiFis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiFis_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HiFiId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_HiFis_HiFiId",
                        column: x => x.HiFiId,
                        principalTable: "HiFis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HiFiCategories",
                columns: table => new
                {
                    HiFiId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiFiCategories", x => new { x.HiFiId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_HiFiCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiFiCategories_HiFis_HiFiId",
                        column: x => x.HiFiId,
                        principalTable: "HiFis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    HiFiId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_HiFis_HiFiId",
                        column: x => x.HiFiId,
                        principalTable: "HiFis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreatedDate", "IsActive", "ModifiedDate", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 13, 20, 26, 46, 619, DateTimeKind.Local).AddTicks(6915), false, new DateTime(2024, 8, 13, 20, 26, 46, 619, DateTimeKind.Local).AddTicks(6936), "LG", "LG-logo.jpg" },
                    { 2, new DateTime(2024, 8, 13, 20, 26, 46, 619, DateTimeKind.Local).AddTicks(6939), false, new DateTime(2024, 8, 13, 20, 26, 46, 619, DateTimeKind.Local).AddTicks(6940), "Samsung", "Samsung-logo.jpg" },
                    { 3, new DateTime(2024, 8, 13, 20, 26, 46, 619, DateTimeKind.Local).AddTicks(6942), false, new DateTime(2024, 8, 13, 20, 26, 46, 619, DateTimeKind.Local).AddTicks(6943), "JBL", "JBL-logo.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsHome", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 13, 20, 26, 46, 621, DateTimeKind.Local).AddTicks(6447), "HiFi Home Teathre", true, true, new DateTime(2024, 8, 13, 20, 26, 46, 621, DateTimeKind.Local).AddTicks(6465), "Home Theathre" },
                    { 2, new DateTime(2024, 8, 13, 20, 26, 46, 621, DateTimeKind.Local).AddTicks(6468), "HiFi soundbar", true, true, new DateTime(2024, 8, 13, 20, 26, 46, 621, DateTimeKind.Local).AddTicks(6468), "Soundbars" },
                    { 3, new DateTime(2024, 8, 13, 20, 26, 46, 621, DateTimeKind.Local).AddTicks(6471), "HiFi Headphone", true, true, new DateTime(2024, 8, 13, 20, 26, 46, 621, DateTimeKind.Local).AddTicks(6471), "Headphones" }
                });

            migrationBuilder.InsertData(
                table: "HiFis",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "ImageUrl", "IsActive", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Stock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 13, 20, 26, 46, 624, DateTimeKind.Local).AddTicks(2474), "HiFi Home Teathre", "images/HiFis/lg.jpg", true, true, new DateTime(2024, 8, 13, 20, 26, 46, 624, DateTimeKind.Local).AddTicks(2488), "LG HT-1000EV", 30000m, "DTS, Dolby Atmos, Bluetooth", 200 },
                    { 2, 2, new DateTime(2024, 8, 13, 20, 26, 46, 624, DateTimeKind.Local).AddTicks(2497), "HiFi Soundbar", "images/HiFis/samsung.jpg", true, true, new DateTime(2024, 8, 13, 20, 26, 46, 624, DateTimeKind.Local).AddTicks(2498), "Samsung Q800C", 20000m, "DTS, Dolby Atmos, Bluetooth", 150 },
                    { 3, 3, new DateTime(2024, 8, 13, 20, 26, 46, 624, DateTimeKind.Local).AddTicks(2502), "HiFi Headphone", "images/HiFis/jbl.png", true, true, new DateTime(2024, 8, 13, 20, 26, 46, 624, DateTimeKind.Local).AddTicks(2502), "JBL Quantum One", 10000m, "DTS, Dolby Atmos", 100 }
                });

            migrationBuilder.InsertData(
                table: "HiFiCategories",
                columns: new[] { "CategoryId", "HiFiId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_HiFiId",
                table: "CartItems",
                column: "HiFiId");

            migrationBuilder.CreateIndex(
                name: "IX_HiFiCategories_CategoryId",
                table: "HiFiCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HiFis_BrandId",
                table: "HiFis",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_HiFiId",
                table: "OrderItems",
                column: "HiFiId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "HiFiCategories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "HiFis");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
