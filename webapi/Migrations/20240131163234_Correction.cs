using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Session_AttendeeEntities_Session_AttendeeEntityId",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Session_AttendeeEntities_Session_AttendeeEntityId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_Session_AttendeeEntityId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_Session_AttendeeEntityId",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "Session_AttendeeEntityId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Session_AttendeeEntityId",
                table: "Attendees");

            migrationBuilder.AddColumn<int>(
                name: "AttendeeEntityId",
                table: "Session_AttendeeEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionEntityId",
                table: "Session_AttendeeEntities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_AttendeeEntities_AttendeeEntityId",
                table: "Session_AttendeeEntities",
                column: "AttendeeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_AttendeeEntities_SessionEntityId",
                table: "Session_AttendeeEntities",
                column: "SessionEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_AttendeeEntities_Attendees_AttendeeEntityId",
                table: "Session_AttendeeEntities",
                column: "AttendeeEntityId",
                principalTable: "Attendees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_AttendeeEntities_Sessions_SessionEntityId",
                table: "Session_AttendeeEntities",
                column: "SessionEntityId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_AttendeeEntities_Attendees_AttendeeEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_AttendeeEntities_Sessions_SessionEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropIndex(
                name: "IX_Session_AttendeeEntities_AttendeeEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropIndex(
                name: "IX_Session_AttendeeEntities_SessionEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropColumn(
                name: "AttendeeEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropColumn(
                name: "SessionEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.AddColumn<int>(
                name: "Session_AttendeeEntityId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Session_AttendeeEntityId",
                table: "Attendees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Session_AttendeeEntityId",
                table: "Sessions",
                column: "Session_AttendeeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Session_AttendeeEntityId",
                table: "Attendees",
                column: "Session_AttendeeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Session_AttendeeEntities_Session_AttendeeEntityId",
                table: "Attendees",
                column: "Session_AttendeeEntityId",
                principalTable: "Session_AttendeeEntities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Session_AttendeeEntities_Session_AttendeeEntityId",
                table: "Sessions",
                column: "Session_AttendeeEntityId",
                principalTable: "Session_AttendeeEntities",
                principalColumn: "Id");
        }
    }
}
