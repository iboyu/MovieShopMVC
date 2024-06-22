using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangingMoviesTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Movie_MovieId",
                table: "Trailers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Title",
                table: "Movies",
                newName: "IX_Movies_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Revenue",
                table: "Movies",
                newName: "IX_Movies_Revenue");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Price",
                table: "Movies",
                newName: "IX_Movies_Price");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_Budget",
                table: "Movies",
                newName: "IX_Movies_Budget");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailers_Movies_MovieId",
                table: "Trailers",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Movies_MovieId",
                table: "Trailers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "Movie");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_Title",
                table: "Movie",
                newName: "IX_Movie_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_Revenue",
                table: "Movie",
                newName: "IX_Movie_Revenue");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_Price",
                table: "Movie",
                newName: "IX_Movie_Price");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_Budget",
                table: "Movie",
                newName: "IX_Movie_Budget");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trailers_Movie_MovieId",
                table: "Trailers",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
