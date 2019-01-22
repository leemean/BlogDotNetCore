using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogDotNetCore.Data.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articleConetnts",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_info_id = table.Column<Guid>(nullable: false),
                    content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleConetnts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "articlePictures",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_info_id = table.Column<Guid>(nullable: false),
                    picture = table.Column<byte[]>(nullable: true),
                    picture_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articlePictures", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "articleTypes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_info_id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    value = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "articleInfos",
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
                    table.PrimaryKey("PK_articleInfos", x => x.id);
                    table.ForeignKey(
                        name: "FK_articleInfos_articleConetnts_article_contentid",
                        column: x => x.article_contentid,
                        principalTable: "articleConetnts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "articleComments",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    article_info_id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    content = table.Column<string>(nullable: true),
                    articleInfoid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articleComments", x => x.id);
                    table.ForeignKey(
                        name: "FK_articleComments_articleInfos_articleInfoid",
                        column: x => x.articleInfoid,
                        principalTable: "articleInfos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articleComments_articleInfoid",
                table: "articleComments",
                column: "articleInfoid");

            migrationBuilder.CreateIndex(
                name: "IX_articleInfos_article_contentid",
                table: "articleInfos",
                column: "article_contentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articleComments");

            migrationBuilder.DropTable(
                name: "articlePictures");

            migrationBuilder.DropTable(
                name: "articleTypes");

            migrationBuilder.DropTable(
                name: "articleInfos");

            migrationBuilder.DropTable(
                name: "articleConetnts");
        }
    }
}
