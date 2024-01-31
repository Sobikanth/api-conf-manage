﻿// <auto-generated />
using System;
using Infrastructure.SQL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace api_conf_manage.Migrations
{
    [DbContext(typeof(ConfContext))]
    [Migration("20240131134357_Initialsetup")]
    partial class Initialsetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.AttendeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Session_AttendeeEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Session_AttendeeEntityId");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.RoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Available")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.SessionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ConfDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoomEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("Session_AttendeeEntityId")
                        .HasColumnType("int");

                    b.Property<int?>("SpeakerEntityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoomEntityId");

                    b.HasIndex("Session_AttendeeEntityId");

                    b.HasIndex("SpeakerEntityId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.Session_AttendeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Session_AttendeeEntities");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.SpeakerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("University")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.AttendeeEntity", b =>
                {
                    b.HasOne("Infrastructure.SQL.Database.Entities.Session_AttendeeEntity", "Session_AttendeeEntity")
                        .WithMany("Attendees")
                        .HasForeignKey("Session_AttendeeEntityId");

                    b.Navigation("Session_AttendeeEntity");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.SessionEntity", b =>
                {
                    b.HasOne("Infrastructure.SQL.Database.Entities.RoomEntity", "RoomEntity")
                        .WithMany("Sessions")
                        .HasForeignKey("RoomEntityId");

                    b.HasOne("Infrastructure.SQL.Database.Entities.Session_AttendeeEntity", "Session_AttendeeEntity")
                        .WithMany("Sessions")
                        .HasForeignKey("Session_AttendeeEntityId");

                    b.HasOne("Infrastructure.SQL.Database.Entities.SpeakerEntity", "SpeakerEntity")
                        .WithMany("Sessions")
                        .HasForeignKey("SpeakerEntityId");

                    b.Navigation("RoomEntity");

                    b.Navigation("Session_AttendeeEntity");

                    b.Navigation("SpeakerEntity");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.RoomEntity", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.Session_AttendeeEntity", b =>
                {
                    b.Navigation("Attendees");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Infrastructure.SQL.Database.Entities.SpeakerEntity", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
