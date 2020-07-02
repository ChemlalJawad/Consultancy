﻿// <auto-generated />
using Consultancy.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Consultancy.Data.Migrations
{
    [DbContext(typeof(ConsultingContext))]
    [Migration("20200701095804_FirstDesign")]
    partial class FirstDesign
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Consultancy.Core.Domains.Consultant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Consultants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Experience = 0,
                            Firstname = "Jawad",
                            Lastname = "Chemlal"
                        },
                        new
                        {
                            Id = 2,
                            Experience = 1,
                            Firstname = "Xavier",
                            Lastname = "Piekara"
                        },
                        new
                        {
                            Id = 3,
                            Experience = 2,
                            Firstname = "Loic",
                            Lastname = "Ramelot"
                        });
                });

            modelBuilder.Entity("Consultancy.Core.Domains.ConsultantMission", b =>
                {
                    b.Property<int>("ConsultantId")
                        .HasColumnType("int");

                    b.Property<int>("MissionId")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ConsultantId", "MissionId");

                    b.HasIndex("MissionId");

                    b.ToTable("ConsultantMissions");

                    b.HasData(
                        new
                        {
                            ConsultantId = 1,
                            MissionId = 3,
                            isActive = true
                        },
                        new
                        {
                            ConsultantId = 2,
                            MissionId = 1,
                            isActive = true
                        },
                        new
                        {
                            ConsultantId = 2,
                            MissionId = 3,
                            isActive = false
                        },
                        new
                        {
                            ConsultantId = 3,
                            MissionId = 2,
                            isActive = true
                        },
                        new
                        {
                            ConsultantId = 3,
                            MissionId = 3,
                            isActive = false
                        },
                        new
                        {
                            ConsultantId = 3,
                            MissionId = 1,
                            isActive = false
                        });
                });

            modelBuilder.Entity("Consultancy.Core.Domains.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExperienceRequired")
                        .HasColumnType("int");

                    b.Property<int>("MaximumRate")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Missions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExperienceRequired = 1,
                            MaximumRate = 500,
                            Name = "Google"
                        },
                        new
                        {
                            Id = 2,
                            ExperienceRequired = 2,
                            MaximumRate = 700,
                            Name = "Amazon"
                        },
                        new
                        {
                            Id = 3,
                            ExperienceRequired = 0,
                            MaximumRate = 400,
                            Name = "NRB"
                        });
                });

            modelBuilder.Entity("Consultancy.Core.Domains.ConsultantMission", b =>
                {
                    b.HasOne("Consultancy.Core.Domains.Consultant", "Consultant")
                        .WithMany("ConsultantMissions")
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Consultancy.Core.Domains.Mission", "Mission")
                        .WithMany("ConsultantMissions")
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}