using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class PostSeoFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Content.Posts",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaRobots",
                table: "Content.Posts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Content.Post_Files",
                maxLength: 1000,
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Content.Posts");

            migrationBuilder.DropColumn(
                name: "MetaRobots",
                table: "Content.Posts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Content.Post_Files");

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
