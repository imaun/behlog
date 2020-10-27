using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class AddCategoryMetaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "System.Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorUserId",
                table: "System.Categories",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierUserId",
                table: "System.Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "System.Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "System.Categories");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "System.Categories");

            migrationBuilder.DropColumn(
                name: "ModifierUserId",
                table: "System.Categories");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "System.Categories");

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
        }
    }
}
