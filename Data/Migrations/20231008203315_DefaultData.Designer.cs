﻿// <auto-generated />
using CourseContentManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseContentManagement.Data.Migrations
{
    [DbContext(typeof(CourseContentDbContext))]
    [Migration("20231008203315_DefaultData")]
    partial class DefaultData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CourseContentManagement.Data.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            IsHidden = true,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            IsHidden = false,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("CourseContentManagement.Data.Models.InfoPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("InfoPages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsHidden = true,
                            Name = "Introduction",
                            SectionId = 1,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 2,
                            IsHidden = true,
                            Name = "Arithmetic operations",
                            SectionId = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 3,
                            IsHidden = true,
                            Name = "Variables",
                            SectionId = 2,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 4,
                            IsHidden = true,
                            Name = "Function introduction",
                            SectionId = 3,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 5,
                            IsHidden = true,
                            Name = "Function parameters",
                            SectionId = 3,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 6,
                            IsHidden = false,
                            Name = "Windows",
                            SectionId = 4,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 7,
                            IsHidden = false,
                            Name = "Linux",
                            SectionId = 4,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 8,
                            IsHidden = true,
                            Name = "MacOS",
                            SectionId = 4,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 9,
                            IsHidden = false,
                            Name = "Undelying principles",
                            SectionId = 5,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 10,
                            IsHidden = false,
                            Name = "Dockerfile syntax",
                            SectionId = 5,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 11,
                            IsHidden = false,
                            Name = "Docker compose file syntax",
                            SectionId = 6,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 12,
                            IsHidden = true,
                            Name = "Environment files (.env)",
                            SectionId = 6,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        },
                        new
                        {
                            Id = 13,
                            IsHidden = true,
                            Name = "Container management",
                            SectionId = 7,
                            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
                        });
                });

            modelBuilder.Entity("CourseContentManagement.Data.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Description = "What will be learned in this course",
                            IsHidden = true,
                            Name = "Intro"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Description = "Introduction to python variables and arithmetic operations",
                            IsHidden = true,
                            Name = "Variables and arithmetic"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 1,
                            Description = "Python functions",
                            IsHidden = true,
                            Name = "Functions"
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            Description = "Installation process on different OS'es",
                            IsHidden = false,
                            Name = "Installation"
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 2,
                            Description = "Dockerfile writing basics",
                            IsHidden = false,
                            Name = "Dockerfiles"
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 2,
                            Description = "How to write docker compose files",
                            IsHidden = false,
                            Name = "Docker compose"
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 2,
                            Description = "Most commonly used docker CLI commands",
                            IsHidden = true,
                            Name = "Docker CLI"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}