using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class BlockDesigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    AuthorEmail = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Src = table.Column<string>(nullable: true),
                    Attributes = table.Column<string>(nullable: true),
                    BodyType = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    AddedByUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Block_Security.Users_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Block_Block_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Block",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlockSample",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    BlockId = table.Column<Guid>(nullable: false),
                    Attributes = table.Column<string>(nullable: true),
                    OutputSrc = table.Column<string>(nullable: true),
                    BodyType = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockSample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlockSample_Block_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Block",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostBlock",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(nullable: false),
                    BlockId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    OutputSrc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostBlock_Block_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Block",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostBlock_Content.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Content.Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostBlock_Security.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Security.Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Block_AddedByUserId",
                table: "Block",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Block_ParentId",
                table: "Block",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockSample_BlockId",
                table: "BlockSample",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PostBlock_BlockId",
                table: "PostBlock",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_PostBlock_PostId",
                table: "PostBlock",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostBlock_UserId",
                table: "PostBlock",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockSample");

            migrationBuilder.DropTable(
                name: "PostBlock");

            migrationBuilder.DropTable(
                name: "Block");

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
