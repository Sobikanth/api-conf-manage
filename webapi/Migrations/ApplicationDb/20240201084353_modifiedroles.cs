using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class modifiedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "528ea9be-631e-4bc1-b7f9-616b772abb7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f781b439-b629-45bb-9ccf-af07b21089fd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f8d66c3-047d-4d98-960d-5529657d21bd", "1", "Admin", "ADMIN" },
                    { "927b31fd-d8b7-4337-99ed-5abd9d212684", "2", "RoomCoordinator", "ROOMCOORDINATOR" },
                    { "f9b15a49-43ed-497d-b6a5-20418c9542e2", "3", "Speaker", "SPEAKER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f8d66c3-047d-4d98-960d-5529657d21bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "927b31fd-d8b7-4337-99ed-5abd9d212684");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b15a49-43ed-497d-b6a5-20418c9542e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "528ea9be-631e-4bc1-b7f9-616b772abb7a", "2", "User", "USER" },
                    { "f781b439-b629-45bb-9ccf-af07b21089fd", "1", "Admin", "ADMIN" }
                });
        }
    }
}
