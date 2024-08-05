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

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreatedDate", "IsActive", "ModifiedDate", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 5, 21, 27, 59, 912, DateTimeKind.Local).AddTicks(6477), false, new DateTime(2024, 8, 5, 21, 27, 59, 912, DateTimeKind.Local).AddTicks(6494), "LG", "LG-logo.jpg" },
                    { 2, new DateTime(2024, 8, 5, 21, 27, 59, 912, DateTimeKind.Local).AddTicks(6502), false, new DateTime(2024, 8, 5, 21, 27, 59, 912, DateTimeKind.Local).AddTicks(6503), "Samsung", "Samsung-logo.jpg" },
                    { 3, new DateTime(2024, 8, 5, 21, 27, 59, 912, DateTimeKind.Local).AddTicks(6505), false, new DateTime(2024, 8, 5, 21, 27, 59, 912, DateTimeKind.Local).AddTicks(6507), "JBL", "JBL-logo.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsHome", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 5, 21, 27, 59, 913, DateTimeKind.Local).AddTicks(5468), "HiFi Home Teathre", true, true, new DateTime(2024, 8, 5, 21, 27, 59, 913, DateTimeKind.Local).AddTicks(5480), "Home Theathre" },
                    { 2, new DateTime(2024, 8, 5, 21, 27, 59, 913, DateTimeKind.Local).AddTicks(5486), "HiFi soundbar", true, true, new DateTime(2024, 8, 5, 21, 27, 59, 913, DateTimeKind.Local).AddTicks(5487), "Soundbars" },
                    { 3, new DateTime(2024, 8, 5, 21, 27, 59, 913, DateTimeKind.Local).AddTicks(5490), "HiFi Headphone", true, true, new DateTime(2024, 8, 5, 21, 27, 59, 913, DateTimeKind.Local).AddTicks(5492), "Headphones" }
                });

            migrationBuilder.InsertData(
                table: "HiFis",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "ImageUrl", "IsActive", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Stock" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 5, 21, 27, 59, 916, DateTimeKind.Local).AddTicks(7803), "HiFi Home Teathre", "lg.jpg", true, true, new DateTime(2024, 8, 5, 21, 27, 59, 916, DateTimeKind.Local).AddTicks(7818), "LG HT-1000EV", 30000m, "DTS, Dolby Atmos, Bluetooth", 200 },
                    { 2, 2, new DateTime(2024, 8, 5, 21, 27, 59, 916, DateTimeKind.Local).AddTicks(7831), "HiFi Soundbar", "samsung.jpg", true, true, new DateTime(2024, 8, 5, 21, 27, 59, 916, DateTimeKind.Local).AddTicks(7832), "Samsung Q800C", 20000m, "DTS, Dolby Atmos, Bluetooth", 150 },
                    { 3, 3, new DateTime(2024, 8, 5, 21, 27, 59, 916, DateTimeKind.Local).AddTicks(7837), "HiFi Headphone", "jbl.png", true, true, new DateTime(2024, 8, 5, 21, 27, 59, 916, DateTimeKind.Local).AddTicks(7839), "JBL Quantum One", 10000m, "DTS, Dolby Atmos", 100 }
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
                name: "IX_HiFiCategories_CategoryId",
                table: "HiFiCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HiFis_BrandId",
                table: "HiFis",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HiFiCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "HiFis");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
