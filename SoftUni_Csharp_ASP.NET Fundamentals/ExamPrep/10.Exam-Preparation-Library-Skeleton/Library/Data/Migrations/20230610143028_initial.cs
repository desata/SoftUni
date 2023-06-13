using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Book's Category");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "BookId")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Book Title"),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Book Author"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Book Description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Book ImageUrl"),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Book Rating"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Book CategoryId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Library Books");

            migrationBuilder.CreateTable(
                name: "IdentityUserBook",
                columns: table => new
                {
                    CollectorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "UserId"),
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "BookId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserBook", x => new { x.BookId, x.CollectorId });
                    table.ForeignKey(
                        name: "FK_IdentityUserBook_AspNetUsers_CollectorId",
                        column: x => x.CollectorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserBook_CollectorId",
                table: "IdentityUserBook",
                column: "CollectorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserBook");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
