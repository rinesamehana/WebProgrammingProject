using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventStreamingPlatform.Data.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Category_CategoryId",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Movie",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_CategoryId",
                table: "Movie",
                newName: "IX_Movie_CategoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Category_CategoryID",
                table: "Movie",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Category_CategoryID",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Movie",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_CategoryID",
                table: "Movie",
                newName: "IX_Movie_CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Category",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Category_CategoryId",
                table: "Movie",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
