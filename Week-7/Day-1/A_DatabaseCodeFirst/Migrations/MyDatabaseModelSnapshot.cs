﻿// <auto-generated />
using A_DatabaseCodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace A_DatabaseCodeFirst.Migrations
{
    [DbContext(typeof(MyDatabase))]
    partial class MyDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("A_DatabaseCodeFirst.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Electronic",
                            Description = "This is Electronic."
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Fruit",
                            Description = "This is a Fruit."
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "TestMaxLengthTestMaxLengthTestMaxLengthTestMaxLengthTestMaxLengthTestMaxLength",
                            Description = "This is a Fruit."
                        });
                });

            modelBuilder.Entity("A_DatabaseCodeFirst.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("Money")
                        .HasColumnName("ProductPrice");

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
                            ProductId = 1,
                            CategoryId = 1,
                            Cost = 0,
                            ProductName = "Radio"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Cost = 0,
                            ProductName = "TV"
                        });
                });

            modelBuilder.Entity("A_DatabaseCodeFirst.Product", b =>
                {
                    b.HasOne("A_DatabaseCodeFirst.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("A_DatabaseCodeFirst.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
