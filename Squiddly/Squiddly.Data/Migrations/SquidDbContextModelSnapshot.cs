﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Squiddly.Data;

namespace Squiddly.Data.Migrations
{
    [DbContext(typeof(SquidDbContext))]
    partial class SquidDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Squiddly.Data.Data.Deployment", b =>
                {
                    b.Property<long>("DeploymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Completed");

                    b.Property<string>("DeploymentName")
                        .HasMaxLength(256);

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