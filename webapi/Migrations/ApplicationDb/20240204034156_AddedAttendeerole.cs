using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddedAttendeerole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "a0b72b3c-34af-4200-b756-16c9ceb072d2", "3", "Speaker", "SPEAKER" },
                    { "e22a33af-b2f1-4ba5-b87d-09c026eb65ee", "4", "Attendee", "ATTENDEE" },
                    { "eef07505-103f-4974-9fb3-582153506f2d", "2", "RoomCoordinator", "ROOMCOORDINATOR" },
                    { "f8607e47-dc28-4cc3-91b9-1c89528c9a5b", "1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0b72b3c-34af-4200-b756-16c9ceb072d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e22a33af-b2f1-4ba5-b87d-09c026eb65ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eef07505-103f-4974-9fb3-582153506f2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8607e47-dc28-4cc3-91b9-1c89528c9a5b");

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
    }
}
