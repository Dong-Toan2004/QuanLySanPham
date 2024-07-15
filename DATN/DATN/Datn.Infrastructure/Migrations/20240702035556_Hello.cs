using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Datn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartsDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartsDetails_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartsDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mô hình anime" },
                    { 2, "Mô hình GunDam" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PassWord", "UserName" },
                values: new object[] { new Guid("3f69cdc7-faf2-47e6-823b-4687d5924526"), "123", "Admin1" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("3b4f1691-71a8-42bb-90aa-fd3b7d0d17b3"), 1, "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.", "/img/sanpham4.jpg", "SP5", 100000m, 100 },
                    { new Guid("5c89f8da-3bf1-4e4c-be36-b0e38e74158c"), 1, "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.", "/img/sanpham4.jpg", "SP1", 100000m, 100 },
                    { new Guid("96a26b0e-2ee5-42f6-a77c-e52583747883"), 2, "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.", "/img/sanpham6.jpg", "SP4", 150000m, 100 },
                    { new Guid("eac1ac4c-09ac-4520-86a5-de82e82c4f23"), 2, "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.", "/img/sanpham6.jpg", "SP2", 150000m, 100 },
                    { new Guid("fad0aa11-2ccd-4bfa-a552-bb43b3ac3b21"), 1, "Mô hình anime tái hiện nhân vật chi tiết từ anime với trang phục và cảm xúc đặc trưng.", "/img/sanpham5.jpg", "SP3", 200000m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartsDetails_CartId",
                table: "CartsDetails",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartsDetails_ProductId",
                table: "CartsDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartsDetails");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
