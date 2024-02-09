using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_AttendeeEntities_Attendees_AttendeeEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_AttendeeEntities_Sessions_SessionEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Rooms_RoomEntityId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Speakers_SpeakerEntityId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_RoomEntityId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_SpeakerEntityId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session_AttendeeEntities",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropIndex(
                name: "IX_Session_AttendeeEntities_AttendeeEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropIndex(
                name: "IX_Session_AttendeeEntities_SessionEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendees",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "RoomEntityId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SpeakerEntityId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropColumn(
                name: "AttendeeEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropColumn(
                name: "SessionEntityId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Attendees");

            migrationBuilder.AddColumn<Guid>(
                name: "SpeakerId",
                table: "Speakers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoomEntityRoomId",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpeakerEntitySpeakerId",
                table: "Sessions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Session_AttendeeId",
                table: "Session_AttendeeEntities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AttendeeEntityAttendeeId",
                table: "Session_AttendeeEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SessionEntitySessionId",
                table: "Session_AttendeeEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizerId",
                table: "Organizers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AttendeeId",
                table: "Attendees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "SpeakerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session_AttendeeEntities",
                table: "Session_AttendeeEntities",
                column: "Session_AttendeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers",
                column: "OrganizerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendees",
                table: "Attendees",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RoomEntityRoomId",
                table: "Sessions",
                column: "RoomEntityRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SpeakerEntitySpeakerId",
                table: "Sessions",
                column: "SpeakerEntitySpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_AttendeeEntities_AttendeeEntityAttendeeId",
                table: "Session_AttendeeEntities",
                column: "AttendeeEntityAttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_AttendeeEntities_SessionEntitySessionId",
                table: "Session_AttendeeEntities",
                column: "SessionEntitySessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_AttendeeEntities_Attendees_AttendeeEntityAttendeeId",
                table: "Session_AttendeeEntities",
                column: "AttendeeEntityAttendeeId",
                principalTable: "Attendees",
                principalColumn: "AttendeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_AttendeeEntities_Sessions_SessionEntitySessionId",
                table: "Session_AttendeeEntities",
                column: "SessionEntitySessionId",
                principalTable: "Sessions",
                principalColumn: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Rooms_RoomEntityRoomId",
                table: "Sessions",
                column: "RoomEntityRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Speakers_SpeakerEntitySpeakerId",
                table: "Sessions",
                column: "SpeakerEntitySpeakerId",
                principalTable: "Speakers",
                principalColumn: "SpeakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Session_AttendeeEntities_Attendees_AttendeeEntityAttendeeId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_AttendeeEntities_Sessions_SessionEntitySessionId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Rooms_RoomEntityRoomId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Speakers_SpeakerEntitySpeakerId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_RoomEntityRoomId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_SpeakerEntitySpeakerId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Session_AttendeeEntities",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropIndex(
                name: "IX_Session_AttendeeEntities_AttendeeEntityAttendeeId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropIndex(
                name: "IX_Session_AttendeeEntities_SessionEntitySessionId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendees",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "RoomEntityRoomId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SpeakerEntitySpeakerId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Session_AttendeeId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropColumn(
                name: "AttendeeEntityAttendeeId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropColumn(
                name: "SessionEntitySessionId",
                table: "Session_AttendeeEntities");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Organizers");

            migrationBuilder.DropColumn(
                name: "AttendeeId",
                table: "Attendees");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Speakers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RoomEntityId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerEntityId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Session_AttendeeEntities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Organizers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Attendees",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Session_AttendeeEntities",
                table: "Session_AttendeeEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizers",
                table: "Organizers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendees",
                table: "Attendees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RoomEntityId",
                table: "Sessions",
                column: "RoomEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SpeakerEntityId",
                table: "Sessions",
                column: "SpeakerEntityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Rooms_RoomEntityId",
                table: "Sessions",
                column: "RoomEntityId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Speakers_SpeakerEntityId",
                table: "Sessions",
                column: "SpeakerEntityId",
                principalTable: "Speakers",
                principalColumn: "Id");
        }
    }
}
