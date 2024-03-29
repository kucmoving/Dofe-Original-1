﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetCafeCustomerWebApp.Data;

#nullable disable

namespace PetCafeCustomerWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PetCafeCustomerWebApp.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VisitTimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitTimeId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("PetCafeCustomerWebApp.Models.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DogCategory")
                        .HasColumnType("int");

                    b.Property<string>("DogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitTimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VisitTimeId");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("PetCafeCustomerWebApp.Models.Sharing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SharingCategory")
                        .HasColumnType("int");

                    b.Property<string>("SharingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitTimeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VisitTimeId");

                    b.ToTable("Sharings");
                });

            modelBuilder.Entity("PetCafeCustomerWebApp.Models.VisitTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeFrame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VisitTimes");
                });

            modelBuilder.Entity("PetCafeCustomerWebApp.Models.Customer", b =>
                {
                    b.HasOne("PetCafeCustomerWebApp.Models.VisitTime", "VisitTime")
                        .WithMany()
                        .HasForeignKey("VisitTimeId");

                    b.Navigation("VisitTime");
                });

            modelBuilder.Entity("PetCafeCustomerWebApp.Models.Dog", b =>
                {
                    b.HasOne("PetCafeCustomerWebApp.Models.Customer", "Customer")
                        .WithMany("Dogs")
                        .HasForeignKey("CustomerId");

                    b.HasOne("PetCafeCustomerWebApp.Models.VisitTime", "VisitTime")
                        .WithMany()
                        .HasForeignKey("VisitTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("VisitTime");
                });

            modelBuilder.Entity("PetCafeCustomerWebApp.Models.Sharing", b =>
                {
                    b.HasOne("PetCafeCustomerWebApp.Models.Customer", "Customer")
                        .WithMany("Sharings")
                        .HasForeignKey("CustomerId");

                    b.HasOne("PetCafeCustomerWebApp.Models.VisitTime", "VisitTime")
                        .WithMany()
                        .HasForeignKey("VisitTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("VisitTime");
                });

            modelBuilder.Entity("PetCafeCustomerWebApp.Models.Customer", b =>
                {
                    b.Navigation("Dogs");

                    b.Navigation("Sharings");
                });
#pragma warning restore 612, 618
        }
    }
}
