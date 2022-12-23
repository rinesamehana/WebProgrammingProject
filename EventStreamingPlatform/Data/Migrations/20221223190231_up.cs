using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventStreamingPlatform.Data.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors_Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors_Movies",
                columns: table => new
                {
                    ActorID = table.Column<int>(type: "int", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors_Movies", x => new { x.ActorID, x.MovieID });
                    table.ForeignKey(
                        name: "FK_Actors_Movies_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actors_Movies_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actors_Movies_MovieID",
                table: "Actors_Movies",
                column: "MovieID");
        }
    }
}
