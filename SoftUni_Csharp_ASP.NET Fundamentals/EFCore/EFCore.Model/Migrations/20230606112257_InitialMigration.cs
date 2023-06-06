using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Product name"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Product quantity")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                },
                comment: "Product table");

            migrationBuilder.CreateTable(
                name: "ProductNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product note ID")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Product note text"),
                    NoteDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Product note date"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product note ProductId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductNotes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Product note table");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotes_ProductId",
                table: "ProductNotes",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductNotes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
