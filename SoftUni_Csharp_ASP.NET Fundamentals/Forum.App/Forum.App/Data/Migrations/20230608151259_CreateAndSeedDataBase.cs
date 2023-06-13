using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forum.App.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam posuere massa mi, eu pulvinar est dapibus eleifend. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nunc tempor sagittis tempus. Aenean sem nibh, tempor sed tortor et, aliquet tincidunt justo. Aenean non nunc eu leo finibus malesuada. Ut eleifend gravida lacus, a egestas turpis consectetur eget. Praesent pretium pulvinar tempor. Aenean at dictum erat. In nisi augue, consequat quis venenatis a, auctor eget sapien. Sed sed orci quis erat eleifend auctor nec sed nulla. Sed aliquam imperdiet tellus, at ultrices nisi viverra vel. Nulla aliquam imperdiet ante et semper.", "My first post" },
                    { 2, "Donec egestas nunc quis risus scelerisque luctus. Mauris vitae mattis sem, sed sodales orci. Nullam feugiat justo at malesuada suscipit. Nulla facilisi. Proin faucibus dapibus elit, eget fermentum nibh blandit non. Quisque vel tortor vel erat tincidunt laoreet lobortis a est. Etiam bibendum est at semper tempus. Pellentesque suscipit sed dolor ut faucibus.", "My second post" },
                    { 3, "Nullam feugiat justo at malesuada suscipit. Nulla facilisi. Proin faucibus dapibus elit, eget fermentum nibh blandit non. Quisque vel tortor vel erat tincidunt laoreet lobortis a est. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla at bibendum dui, non laoreet lectus. Morbi ut laoreet ex. Cras. ", "My third post" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
