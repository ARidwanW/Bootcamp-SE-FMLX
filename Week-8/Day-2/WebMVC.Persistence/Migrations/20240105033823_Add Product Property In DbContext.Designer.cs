﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMVC.Data;

#nullable disable

namespace WebMVC.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240105033823_Add Product Property In DbContext")]
    partial class AddProductPropertyInDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("WebMVC.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("0d436791-5b81-4429-84b0-b3c474765d0a"),
                            CategoryName = "Electronic",
                            Description = "This in electronics",
                            ProductId = 0
                        },
                        new
                        {
                            CategoryId = new Guid("91815301-2980-4f0c-98bb-4438925064cf"),
                            CategoryName = "Furniture",
                            Description = "This in furnitures",
                            ProductId = 0
                        });
                });

            modelBuilder.Entity("WebMVC.Models.Models.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("8357b2ee-b8ca-4b78-9e90-779beb57639f"),
                            CategoryId = new Guid("0d436791-5b81-4429-84b0-b3c474765d0a"),
                            Description = "This is radio",
                            Price = 10,
                            ProductName = "Radio"
                        },
                        new
                        {
                            ProductId = new Guid("0e50c93b-c218-4451-bdc3-bddf123134fc"),
                            CategoryId = new Guid("0d436791-5b81-4429-84b0-b3c474765d0a"),
                            Description = "This is television",
                            Price = 10,
                            ProductName = "Television"
                        },
                        new
                        {
                            ProductId = new Guid("df7b1e62-f922-4cd6-ac31-c585064733a8"),
                            CategoryId = new Guid("91815301-2980-4f0c-98bb-4438925064cf"),
                            Description = "This is table",
                            Price = 10,
                            ProductName = "Table"
                        });
                });

            modelBuilder.Entity("WebMVC.Models.Models.Product", b =>
                {
                    b.HasOne("WebMVC.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebMVC.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
