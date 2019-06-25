﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Squiddly.Data;

namespace Squiddly.Data.Migrations
{
    [DbContext(typeof(SquidDbContext))]
    [Migration("20190625030918_AddingProjects")]
    partial class AddingProjects
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Squiddly.Data.Data.Branch", b =>
                {
                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.HasKey("BranchId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Squiddly.Data.Data.Build", b =>
                {
                    b.Property<int>("BuildId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("BuildId");

                    b.ToTable("Builds");
                });

            modelBuilder.Entity("Squiddly.Data.Data.BuildStep", b =>
                {
                    b.Property<int>("BuildStepId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuildId");

                    b.Property<string>("SquirtName");

                    b.HasKey("BuildStepId");

                    b.HasIndex("BuildId");

                    b.ToTable("BuildSteps");
                });

            modelBuilder.Entity("Squiddly.Data.Data.Deployment", b =>
                {
                    b.Property<long>("DeploymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Completed");

                    b.Property<string>("DeploymentName")
                        .HasMaxLength(256);

                    b.Property<string>("Project");

                    b.Property<DateTime>("Started");

                    b.HasKey("DeploymentId");

                    b.ToTable("Deployments");
                });

            modelBuilder.Entity("Squiddly.Data.Data.Issue", b =>
                {
                    b.Property<long>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DeploymentId");

                    b.Property<long?>("DeploymentId1");

                    b.Property<string>("StackTrace")
                        .HasMaxLength(2048);

                    b.HasKey("IssueId");

                    b.HasIndex("DeploymentId");

                    b.HasIndex("DeploymentId1");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Squiddly.Data.Data.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description")
                        .HasMaxLength(256);

                    b.Property<string>("GitPassword");

                    b.Property<string>("GitRepository");

                    b.Property<string>("GitUserName");

                    b.Property<string>("Name")
                        .HasMaxLength(40);

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Squiddly.Data.Data.Branch", b =>
                {
                    b.HasOne("Squiddly.Data.Data.Project")
                        .WithMany("Branches")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("Squiddly.Data.Data.BuildStep", b =>
                {
                    b.HasOne("Squiddly.Data.Data.Build")
                        .WithMany("BuildSteps")
                        .HasForeignKey("BuildId");
                });

            modelBuilder.Entity("Squiddly.Data.Data.Issue", b =>
                {
                    b.HasOne("Squiddly.Data.Data.Deployment", "Deployment")
                        .WithMany()
                        .HasForeignKey("DeploymentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Squiddly.Data.Data.Deployment")
                        .WithMany("Issues")
                        .HasForeignKey("DeploymentId1");
                });
#pragma warning restore 612, 618
        }
    }
}