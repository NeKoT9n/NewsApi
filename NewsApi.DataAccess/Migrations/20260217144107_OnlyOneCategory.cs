using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OnlyOneCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:sentiment_type", "positive,neutral,negative,mixed")
                .OldAnnotation("Npgsql:Enum:sentiment_type", "positive,neutral,negative");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "News",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Categories_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Categories_CategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "News");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:sentiment_type", "positive,neutral,negative")
                .OldAnnotation("Npgsql:Enum:sentiment_type", "positive,neutral,negative,mixed");

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    NewsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => new { x.CategoriesId, x.NewsId });
                    table.ForeignKey(
                        name: "FK_NewsCategories_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsCategories_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategories_NewsId",
                table: "NewsCategories",
                column: "NewsId");
        }
    }
}
