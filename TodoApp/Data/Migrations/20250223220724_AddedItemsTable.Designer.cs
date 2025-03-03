﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250223220724_AddedItemsTable")]
    partial class AddedItemsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Data.Entities.TodoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Learn C#",
                            CreatedAt = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = true
                        },
                        new
                        {
                            Id = 2,
                            Content = "Learn EF Core",
                            CreatedAt = new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false
                        },
                        new
                        {
                            Id = 3,
                            Content = "Learn ASP.NET Core",
                            CreatedAt = new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false
                        },
                        new
                        {
                            Id = 4,
                            Content = "Learn hosting models",
                            CreatedAt = new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDone = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
