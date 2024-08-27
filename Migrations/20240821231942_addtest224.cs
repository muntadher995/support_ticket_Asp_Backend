using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugProject.Migrations
{
    /// <inheritdoc />
    public partial class addtest224 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adcf5a99-14eb-424d-ad72-afcb7c4cf5cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efbf5458-bb8f-43c8-945c-7478e9659801");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "EmployeeImages",
                newName: "FilePaths");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f57798a-cb6e-45fc-a468-cb370a590598", null, "User", "USER" },
                    { "b43a715f-dc13-4009-8850-fc7f25291499", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f57798a-cb6e-45fc-a468-cb370a590598");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b43a715f-dc13-4009-8850-fc7f25291499");

            migrationBuilder.RenameColumn(
                name: "FilePaths",
                table: "EmployeeImages",
                newName: "FilePath");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adcf5a99-14eb-424d-ad72-afcb7c4cf5cf", null, "User", "USER" },
                    { "efbf5458-bb8f-43c8-945c-7478e9659801", null, "Admin", "ADMIN" }
                });
        }
    }
}
