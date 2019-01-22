using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDotNetCore.Data.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articleContent",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_info_id = table.Column<Guid>(nullable: false),
                    content = table.Column<string>(nullable: true),
                    is_del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleContent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "articlePicture",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_info_id = table.Column<Guid>(nullable: false),
                    picture = table.Column<byte[]>(nullable: true),
                    picture_url = table.Column<string>(nullable: true),
                    is_del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articlePicture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "articleType",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_info_id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    is_del = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "articleInfo",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    create_by = table.Column<string>(nullable: true),
                    create_date = table.Column<DateTime>(nullable: false),
                    update_by = table.Column<string>(nullable: true),
                    update_date = table.Column<DateTime>(nullable: false),
                    version = table.Column<string>(nullable: true),
                    is_del = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    is_top = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    original_link = table.Column<string>(nullable: true),
                    is_original = table.Column<bool>(nullable: false),
                    is_private = table.Column<bool>(nullable: false),
                    article_contentid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_articleInfo_articleContent_article_contentid",
                        column: x => x.article_contentid,
                        principalTable: "articleContent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "articleComment",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_info_id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    is_del = table.Column<bool>(nullable: false),
                    articleInfoid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleComment", x => x.id);
                    table.ForeignKey(
                        name: "FK_articleComment_articleInfo_articleInfoid",
                        column: x => x.articleInfoid,
                        principalTable: "articleInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articleComment_articleInfoid",
                table: "articleComment",
                column: "articleInfoid");

            migrationBuilder.CreateIndex(
                name: "IX_articleInfo_article_contentid",
                table: "articleInfo",
                column: "article_contentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articleComment");

            migrationBuilder.DropTable(
                name: "articlePicture");

            migrationBuilder.DropTable(
                name: "articleType");

            migrationBuilder.DropTable(
                name: "articleInfo");

            migrationBuilder.DropTable(
                name: "articleContent");
        }
    }
}
