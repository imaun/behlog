using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class CommentMetaData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Content.Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierUserId",
                table: "Content.Comments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Content.Comments",
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

            migrationBuilder.CreateIndex(
                name: "IX_Content.Comments_ModifierUserId",
                table: "Content.Comments",
                column: "ModifierUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Content.Comments_Security.Users_ModifierUserId",
                table: "Content.Comments",
                column: "ModifierUserId",
                principalTable: "Security.Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content.Comments_Security.Users_ModifierUserId",
                table: "Content.Comments");

            migrationBuilder.DropIndex(
                name: "IX_Content.Comments_ModifierUserId",
                table: "Content.Comments");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Content.Comments");

            migrationBuilder.DropColumn(
                name: "ModifierUserId",
                table: "Content.Comments");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Content.Comments");

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
