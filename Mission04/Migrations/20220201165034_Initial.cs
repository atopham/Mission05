using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission04.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    Categoryid = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    director = table.Column<string>(nullable: false),
                    rating = table.Column<string>(nullable: false),
                    edited = table.Column<bool>(nullable: false),
                    lentto = table.Column<string>(nullable: true),
                    notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "categoryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[] { 4, "Family" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[] { 5, "Horror/Suspense" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[] { 6, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[] { 7, "Television" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[] { 8, "VHS" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "Categoryid", "director", "edited", "lentto", "notes", "rating", "title", "year" },
                values: new object[] { 1, 1, "Kevin Reynolds", false, "", "One of the best movies ever made", "PG-13", "The Count of Monte Cristo", 2002 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "Categoryid", "director", "edited", "lentto", "notes", "rating", "title", "year" },
                values: new object[] { 2, 1, "Michael Curtis", false, "", "One of the best movies ever made", "PG", "The Adventure of Robin Hood", 1938 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "Categoryid", "director", "edited", "lentto", "notes", "rating", "title", "year" },
                values: new object[] { 3, 1, "Christopher Nolan", false, "", "One of the best movies ever made", "PG-13", "Inception", 2010 });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_Categoryid",
                table: "Responses",
                column: "Categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
