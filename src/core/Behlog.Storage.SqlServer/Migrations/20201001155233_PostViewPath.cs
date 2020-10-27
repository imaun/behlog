using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class PostViewPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content.Post_Files_Content.Files_FileId",
                table: "Content.Post_Files");

            migrationBuilder.DropColumn(
                name: "RelatedPostFileId",
                table: "Content.Post_Files");

            migrationBuilder.AddColumn<string>(
                name: "ViewPath",
                table: "Content.Posts",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RelatedFileId",
                table: "Content.Post_Files",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Content.Post_Files_Content.Files_FileId",
                table: "Content.Post_Files",
                column: "FileId",
                principalTable: "Content.Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content.Post_Files_Content.Files_FileId",
                table: "Content.Post_Files");

            migrationBuilder.DropColumn(
                name: "ViewPath",
                table: "Content.Posts");

            migrationBuilder.DropColumn(
                name: "RelatedFileId",
                table: "Content.Post_Files");

            migrationBuilder.AddColumn<long>(
                name: "RelatedPostFileId",
                table: "Content.Post_Files",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Content.Post_Files_Content.Files_FileId",
                table: "Content.Post_Files",
                column: "FileId",
                principalTable: "Content.Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
