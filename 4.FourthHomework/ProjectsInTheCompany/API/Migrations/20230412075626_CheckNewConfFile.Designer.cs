﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectsInTheCompany.Infrastructure.Foundation;

#nullable disable

namespace ProjectsInTheCompany.API.Migrations
{
    [DbContext(typeof(ProjectsCompanyDbContext))]
    [Migration("20230412075626_CheckNewConfFile")]
    partial class CheckNewConfFile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectsInTheCompany.Domain.Employees.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProjectTaskId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectTaskId")
                        .IsUnique();

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("ProjectsInTheCompany.Domain.ProjectTasks.ProjectTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Project Tasks", (string)null);
                });

            modelBuilder.Entity("ProjectsInTheCompany.Domain.Projects.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("ProjectsInTheCompany.Domain.Employees.Employee", b =>
                {
                    b.HasOne("ProjectsInTheCompany.Domain.ProjectTasks.ProjectTask", "ProjectTask")
                        .WithOne("Employee")
                        .HasForeignKey("ProjectsInTheCompany.Domain.Employees.Employee", "ProjectTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectTask");
                });

            modelBuilder.Entity("ProjectsInTheCompany.Domain.ProjectTasks.ProjectTask", b =>
                {
                    b.HasOne("ProjectsInTheCompany.Domain.Projects.Project", "Project")
                        .WithMany("ProjectTasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectsInTheCompany.Domain.ProjectTasks.ProjectTask", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ProjectsInTheCompany.Domain.Projects.Project", b =>
                {
                    b.Navigation("ProjectTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
