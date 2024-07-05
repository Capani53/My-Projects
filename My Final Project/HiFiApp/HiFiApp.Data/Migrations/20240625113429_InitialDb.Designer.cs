﻿// <auto-generated />
using System;
using HiFiApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HiFiApp.Data.Migrations
{
    [DbContext(typeof(HiFiAppDbContext))]
    [Migration("20240625113429_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HiFiApp.Entity.Concrete.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("HiFiApp.Entity.Concrete.HiFi", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Features")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Properties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("HiFis");
                });

            modelBuilder.Entity("HiFiApp.Entity.Concrete.HiFiCategory", b =>
                {
                    b.Property<int>("HiFiId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("HiFiId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("HiFiCategories");
                });

            modelBuilder.Entity("HiFiApp.Entity.Concrete.HiFiCategory", b =>
                {
                    b.HasOne("HiFiApp.Entity.Concrete.Category", "Category")
                        .WithMany("HiFiCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HiFiApp.Entity.Concrete.HiFi", "HiFi")
                        .WithMany("HiFiCategories")
                        .HasForeignKey("HiFiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("HiFi");
                });

            modelBuilder.Entity("HiFiApp.Entity.Concrete.Category", b =>
                {
                    b.Navigation("HiFiCategories");
                });

            modelBuilder.Entity("HiFiApp.Entity.Concrete.HiFi", b =>
                {
                    b.Navigation("HiFiCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
