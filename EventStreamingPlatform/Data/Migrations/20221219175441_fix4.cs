using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventStreamingPlatform.Data.Migrations
{
    public partial class fix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryMovie",
                columns: table => new
                {
                    CategoriesCategoryID = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMovie", x => new { x.CategoriesCategoryID, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Category_CategoriesCategoryID",
                        column: x => x.CategoriesCategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMovie_MoviesId",
                table: "CategoryMovie",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMovie");
        }
    }
}
