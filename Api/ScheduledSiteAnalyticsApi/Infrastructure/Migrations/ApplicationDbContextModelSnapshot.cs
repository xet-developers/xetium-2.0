﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Cluster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string[]>("Keywords")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Clusters");
                });

            modelBuilder.Entity("Domain.Entity.ScheduleTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ScheduleTask");
                });

            modelBuilder.Entity("Domain.Entity.ScheduleTaskDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ScheduleTaskDetails");
                });

            modelBuilder.Entity("Domain.Entity.SitePosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClusterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Keyword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ScheduleTaskDetailId")
                        .HasColumnType("uuid");

                    b.Property<int>("SearchSystem")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleTaskDetailId");

                    b.ToTable("siteposition");
                });

            modelBuilder.Entity("Domain.Entity.TaskDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClusterId")
                        .HasColumnType("uuid");

                    b.Property<int>("Frequency")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<string>("JobId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Keywords")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<Guid>("ProjectID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ScheduleTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SearchSystem")
                        .HasColumnType("integer");

                    b.Property<int>("Top")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("tasks");
                });

            modelBuilder.Entity("Domain.Entity.TaskInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClusterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CompletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("TaskInfos");
                });

            modelBuilder.Entity("Domain.Entity.ScheduleTaskDetails", b =>
                {
                    b.HasOne("Domain.Entity.ScheduleTask", "ScheduleTask")
                        .WithMany("Details")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScheduleTask");
                });

            modelBuilder.Entity("Domain.Entity.SitePosition", b =>
                {
                    b.HasOne("Domain.Entity.ScheduleTaskDetails", "ScheduleTaskDetails")
                        .WithMany("PositionAnalysis")
                        .HasForeignKey("ScheduleTaskDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScheduleTaskDetails");
                });

            modelBuilder.Entity("Domain.Entity.ScheduleTask", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Domain.Entity.ScheduleTaskDetails", b =>
                {
                    b.Navigation("PositionAnalysis");
                });
#pragma warning restore 612, 618
        }
    }
}
