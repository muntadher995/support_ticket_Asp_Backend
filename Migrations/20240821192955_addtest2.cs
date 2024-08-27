using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugProject.Migrations
{
    /// <inheritdoc />
    public partial class addtest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8b8935c-d8c5-45fa-b983-268bf7689690");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdf99c2f-1205-4aa9-b55e-be47a9ded39c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "057086fe-f2d9-4252-8d42-2e5f098b5641", null, "User", "USER" },
                    { "74a713bd-4108-4ad2-8de0-c5b32e896bcc", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "057086fe-f2d9-4252-8d42-2e5f098b5641");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a713bd-4108-4ad2-8de0-c5b32e896bcc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b8b8935c-d8c5-45fa-b983-268bf7689690", null, "Admin", "ADMIN" },
                    { "bdf99c2f-1205-4aa9-b55e-be47a9ded39c", null, "User", "USER" }
                });
        }
    }
}
