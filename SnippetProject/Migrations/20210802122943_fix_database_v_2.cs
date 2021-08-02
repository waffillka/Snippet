using Microsoft.EntityFrameworkCore.Migrations;

namespace SnippetProject.Migrations
{
    public partial class fix_database_v_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SnippetPosts_Languages_LanguageEntityId",
                table: "SnippetPosts");

            migrationBuilder.DropIndex(
                name: "IX_SnippetPosts_LanguageEntityId",
                table: "SnippetPosts");

            migrationBuilder.DropColumn(
                name: "LanguageEntityId",
                table: "SnippetPosts");

            migrationBuilder.CreateIndex(
                name: "IX_SnippetPosts_LanguageId",
                table: "SnippetPosts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SnippetPosts_UserId",
                table: "SnippetPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SnippetPosts_Languages_LanguageId",
                table: "SnippetPosts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SnippetPosts_Users_UserId",
                table: "SnippetPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SnippetPosts_Languages_LanguageId",
                table: "SnippetPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_SnippetPosts_Users_UserId",
                table: "SnippetPosts");

            migrationBuilder.DropIndex(
                name: "IX_SnippetPosts_LanguageId",
                table: "SnippetPosts");

            migrationBuilder.DropIndex(
                name: "IX_SnippetPosts_UserId",
                table: "SnippetPosts");

            migrationBuilder.AddColumn<long>(
                name: "LanguageEntityId",
                table: "SnippetPosts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SnippetPosts_LanguageEntityId",
                table: "SnippetPosts",
                column: "LanguageEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SnippetPosts_Languages_LanguageEntityId",
                table: "SnippetPosts",
                column: "LanguageEntityId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
