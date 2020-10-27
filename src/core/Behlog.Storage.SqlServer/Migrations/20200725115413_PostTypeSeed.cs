using Microsoft.EntityFrameworkCore.Migrations;

namespace Behlog.Storage.SqlServer.Migrations
{
    public partial class PostTypeSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "System.PostTypes",
                columns: new[] { "Id", "Description", "Slug", "Status", "Title" },
                values: new object[,]
                {
                    { 1, null, "page", 1, "Page" },
                    { 2, null, "blog", 1, "Blog" },
                    { 3, null, "product", 1, "Product" },
                    { 4, null, "service", 1, "Service" },
                    { 5, null, "gallery", 1, "Gallery" },
                    { 6, null, "article", 1, "Article" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "System.PostTypes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
