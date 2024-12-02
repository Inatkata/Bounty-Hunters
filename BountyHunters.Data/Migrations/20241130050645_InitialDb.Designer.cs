﻿// <auto-generated />
using System;
using BountyHunters.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BountyHunters.Data.Migrations
{
    [DbContext(typeof(BountyHuntersDbContext))]
    [Migration("20241130050645_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BountyHunters.Data.Models.Achievement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BountyHunterId")
                        .HasColumnType("int");

                    b.Property<Guid>("BountyHunterId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAchieved")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BountyHunterId1");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("BountyHunters.Data.Models.BountyHunter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CaptureCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("BountyHunters");
                });

            modelBuilder.Entity("BountyHunters.Data.Models.Capture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BountyHunterId")
                        .HasColumnType("int");

                    b.Property<Guid>("BountyHunterId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CaptureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CriminalId")
                        .HasColumnType("int");

                    b.Property<Guid>("CriminalId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("BountyHunterId1");

                    b.HasIndex("CriminalId1");

                    b.ToTable("Captures");
                });

            modelBuilder.Entity("BountyHunters.Data.Models.Criminal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Bounty")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CaptureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CrimeType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Criminals");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77341690-0fec-40dc-af8f-1347562f1c84"),
                            Bounty = 10000m,
                            CrimeType = "Hacking",
                            Name = "Eve Rogue",
                            Status = "At Large"
                        },
                        new
                        {
                            Id = new Guid("559c6554-e160-4003-a977-f09daec53c83"),
                            Bounty = 5000m,
                            CrimeType = "Bank Robbery",
                            Name = "John Doe",
                            Status = "At Large"
                        },
                        new
                        {
                            Id = new Guid("c699b3bd-7bb7-4d82-a2ba-7d8ff2ca65df"),
                            Bounty = 3000m,
                            CrimeType = "Fraud",
                            Name = "Jane Smith",
                            Status = "At Large"
                        });
                });

            modelBuilder.Entity("BountyHunters.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BountyHunters.Data.Models.Achievement", b =>
                {
                    b.HasOne("BountyHunters.Data.Models.BountyHunter", "BountyHunter")
                        .WithMany("Achievements")
                        .HasForeignKey("BountyHunterId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BountyHunter");
                });

            modelBuilder.Entity("BountyHunters.Data.Models.Capture", b =>
                {
                    b.HasOne("BountyHunters.Data.Models.BountyHunter", "BountyHunter")
                        .WithMany("Captures")
                        .HasForeignKey("BountyHunterId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BountyHunters.Data.Models.Criminal", "Criminal")
                        .WithMany("Captures")
                        .HasForeignKey("CriminalId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BountyHunter");

                    b.Navigation("Criminal");
                });

            modelBuilder.Entity("BountyHunters.Data.Models.BountyHunter", b =>
                {
                    b.Navigation("Achievements");

                    b.Navigation("Captures");
                });

            modelBuilder.Entity("BountyHunters.Data.Models.Criminal", b =>
                {
                    b.Navigation("Captures");
                });
#pragma warning restore 612, 618
        }
    }
}