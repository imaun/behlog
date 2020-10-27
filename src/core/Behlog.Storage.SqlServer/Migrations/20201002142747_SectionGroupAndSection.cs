using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class SectionGroupAndSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Content.SectionGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.SectionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.SectionGroups_Content.SectionGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Content.SectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.SectionGroups_System.Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "System.Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Content.Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<Guid>(nullable: false),
                    ModifierUserId = table.Column<Guid>(nullable: true),
                    WebsiteId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    BodyType = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ActionFullUrl = table.Column<string>(nullable: true),
                    CoverPhoto = table.Column<string>(nullable: true),
                    IconName = table.Column<string>(nullable: true),
                    ViewPath = table.Column<string>(nullable: true),
                    SectionGroupId = table.Column<int>(nullable: false),
                    RelatedSectionId = table.Column<int>(nullable: true),
                    RelatedPostId = table.Column<int>(nullable: true),
                    LangId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content.Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content.Sections_System.Languages_LangId",
                        column: x => x.LangId,
                        principalTable: "System.Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Sections_Content.Posts_RelatedPostId",
                        column: x => x.RelatedPostId,
                        principalTable: "Content.Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Sections_Content.Sections_RelatedSectionId",
                        column: x => x.RelatedSectionId,
                        principalTable: "Content.Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content.Sections_Content.SectionGroups_SectionGroupId",
                        column: x => x.SectionGroupId,
                        principalTable: "Content.SectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Content.SectionGroups_ParentId",
                table: "Content.SectionGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.SectionGroups_WebsiteId",
                table: "Content.SectionGroups",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Sections_LangId",
                table: "Content.Sections",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Sections_RelatedPostId",
                table: "Content.Sections",
                column: "RelatedPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Sections_RelatedSectionId",
                table: "Content.Sections",
                column: "RelatedSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Content.Sections_SectionGroupId",
                table: "Content.Sections",
                column: "SectionGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Content.Sections");

            migrationBuilder.DropTable(
                name: "Content.SectionGroups");

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: 1);
        }
    }
}
