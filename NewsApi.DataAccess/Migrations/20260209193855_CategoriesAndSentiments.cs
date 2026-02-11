using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesAndSentiments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntityNewsEntity_Categories_CategoriesId",
                table: "CategoryEntityNewsEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryEntityNewsEntity_News_NewsId",
                table: "CategoryEntityNewsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryEntityNewsEntity",
                table: "CategoryEntityNewsEntity");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "Sentiment",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SentimentScore",
                table: "News");

            migrationBuilder.RenameTable(
                name: "CategoryEntityNewsEntity",
                newName: "NewsCategories");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryEntityNewsEntity_NewsId",
                table: "NewsCategories",
                newName: "IX_NewsCategories_NewsId");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:sentiment_type", "positive,neutral,negative");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "News",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriesId",
                table: "NewsCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsCategories",
                table: "NewsCategories",
                columns: new[] { "CategoriesId", "NewsId" });

            migrationBuilder.CreateTable(
                name: "RatingEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NewsId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingEntity_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SentimentEntity",
                columns: table => new
                {
                    NewsId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<byte>(type: "sentiment_type", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentimentEntity", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_SentimentEntity_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sport" },
                    { 2, "Business" },
                    { 3, "Technology" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RatingEntity_NewsId",
                table: "RatingEntity",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCategories_Categories_CategoriesId",
                table: "NewsCategories",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCategories_News_NewsId",
                table: "NewsCategories",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsCategories_Categories_CategoriesId",
                table: "NewsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsCategories_News_NewsId",
                table: "NewsCategories");

            migrationBuilder.DropTable(
                name: "RatingEntity");

            migrationBuilder.DropTable(
                name: "SentimentEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsCategories",
                table: "NewsCategories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "NewsCategories",
                newName: "CategoryEntityNewsEntity");

            migrationBuilder.RenameIndex(
                name: "IX_NewsCategories_NewsId",
                table: "CategoryEntityNewsEntity",
                newName: "IX_CategoryEntityNewsEntity_NewsId");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:sentiment_type", "positive,neutral,negative");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "News",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<byte>(
                name: "Sentiment",
                table: "News",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<float>(
                name: "SentimentScore",
                table: "News",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Categories",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "CategoriesId",
                table: "CategoryEntityNewsEntity",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryEntityNewsEntity",
                table: "CategoryEntityNewsEntity",
                columns: new[] { "CategoriesId", "NewsId" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Sport" },
                    { 2L, "Business" },
                    { 3L, "Technology" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntityNewsEntity_Categories_CategoriesId",
                table: "CategoryEntityNewsEntity",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryEntityNewsEntity_News_NewsId",
                table: "CategoryEntityNewsEntity",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
