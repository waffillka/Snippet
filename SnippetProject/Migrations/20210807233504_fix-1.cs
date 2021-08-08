using Microsoft.EntityFrameworkCore.Migrations;

namespace SnippetProject.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SnippetEntityUserEntity_SnippetPosts_LakedSnippetPostId",
                table: "SnippetEntityUserEntity");

            migrationBuilder.RenameColumn(
                name: "LakedSnippetPostId",
                table: "SnippetEntityUserEntity",
                newName: "LikedPostsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SnippetEntityUserEntity_SnippetPosts_LikedPostsId",
                table: "SnippetEntityUserEntity",
                column: "LikedPostsId",
                principalTable: "SnippetPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SnippetEntityUserEntity_SnippetPosts_LikedPostsId",
                table: "SnippetEntityUserEntity");

            migrationBuilder.RenameColumn(
                name: "LikedPostsId",
                table: "SnippetEntityUserEntity",
                newName: "LakedSnippetPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_SnippetEntityUserEntity_SnippetPosts_LakedSnippetPostId",
                table: "SnippetEntityUserEntity",
                column: "LakedSnippetPostId",
                principalTable: "SnippetPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
