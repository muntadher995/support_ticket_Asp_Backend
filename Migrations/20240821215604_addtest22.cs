using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BugProject.Migrations
{
    /// <inheritdoc />
    public partial class addtest22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bug_Atachment",
                table: "Bug_Atachment");

            migrationBuilder.DropIndex(
                name: "IX_Bug_Atachment_Bugsid",
                table: "Bug_Atachment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "057086fe-f2d9-4252-8d42-2e5f098b5641");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a713bd-4108-4ad2-8de0-c5b32e896bcc");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "EmployeeImages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bug_Atachment");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "EmployeeImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bug_Atachment",
                table: "Bug_Atachment",
                column: "Bugsid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adcf5a99-14eb-424d-ad72-afcb7c4cf5cf", null, "User", "USER" },
                    { "efbf5458-bb8f-43c8-945c-7478e9659801", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bug_Atachment",
                table: "Bug_Atachment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adcf5a99-14eb-424d-ad72-afcb7c4cf5cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efbf5458-bb8f-43c8-945c-7478e9659801");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "EmployeeImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "EmployeeImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Bug_Atachment",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bug_Atachment",
                table: "Bug_Atachment",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "057086fe-f2d9-4252-8d42-2e5f098b5641", null, "User", "USER" },
                    { "74a713bd-4108-4ad2-8de0-c5b32e896bcc", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bug_Atachment_Bugsid",
                table: "Bug_Atachment",
                column: "Bugsid");
        }
    }
}
