﻿// <auto-generated />
using System;
using Interview.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Interview.Api.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20221102054540_initialmig")]
    partial class initialmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("Interview.Api.Entities.BankCustomer+BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<int>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = "1000000001",
                            Balance = 10450000,
                            CustomerId = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountNumber = "1000000002",
                            Balance = 450000,
                            CustomerId = 1
                        },
                        new
                        {
                            Id = 3,
                            AccountNumber = "1000000003",
                            Balance = 10450000,
                            CustomerId = 2
                        });
                });

            modelBuilder.Entity("Interview.Api.Entities.BankCustomer+Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Nakawa, Bugolobi",
                            EmailAddress = "bk@gmail.com",
                            FullName = "Benard Kalika",
                            Password = "104d3b20ba4ac5dc7f716f43cdc1aefa",
                            PhoneNumber = "0785100504"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Julie, Nakato",
                            EmailAddress = "jn@gmail.com",
                            FullName = "Julie Nakato",
                            Password = "ba1cdd46d798d5070e4a4711b24491bf",
                            PhoneNumber = "0785100505"
                        });
                });

            modelBuilder.Entity("Interview.Api.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CtyCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CtyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CtyCode = "Uganda",
                            CtyName = "Uganda"
                        },
                        new
                        {
                            Id = 1002,
                            CtyCode = "Usa",
                            CtyName = "Usa"
                        },
                        new
                        {
                            Id = 1003,
                            CtyCode = "England",
                            CtyName = "England"
                        },
                        new
                        {
                            Id = 1004,
                            CtyCode = "Kenya",
                            CtyName = "Kenya"
                        });
                });

            modelBuilder.Entity("Interview.Api.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CanTransact")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CanTransact = true,
                            PhoneNo = "075490901"
                        },
                        new
                        {
                            Id = 2,
                            CanTransact = true,
                            PhoneNo = "075490903"
                        },
                        new
                        {
                            Id = 3,
                            CanTransact = true,
                            PhoneNo = "075490501"
                        },
                        new
                        {
                            Id = 4,
                            CanTransact = true,
                            PhoneNo = "075490503"
                        },
                        new
                        {
                            Id = 8,
                            CanTransact = false,
                            PhoneNo = "075490305"
                        },
                        new
                        {
                            Id = 9,
                            CanTransact = false,
                            PhoneNo = "075490304"
                        },
                        new
                        {
                            Id = 10,
                            CanTransact = false,
                            PhoneNo = "075493506"
                        });
                });

            modelBuilder.Entity("Interview.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1001,
                            Description = "This is a best gaming laptop",
                            Name = "Laptop",
                            Price = 20.02,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 1002,
                            Description = "This is a Office Application",
                            Name = "Microsoft Office",
                            Price = 20.989999999999998,
                            Quantity = 50
                        },
                        new
                        {
                            Id = 1003,
                            Description = "The mouse that works on all surface",
                            Name = "Lazer Mouse",
                            Price = 12.02,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 1004,
                            Description = "To store 256GB of data",
                            Name = "USB Storage",
                            Price = 5.0,
                            Quantity = 20
                        });
                });

            modelBuilder.Entity("Interview.Api.Entities.TransactionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelecomId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TranDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AccountTransactions");
                });

            modelBuilder.Entity("Interview.Api.Entities.BankCustomer+BankAccount", b =>
                {
                    b.HasOne("Interview.Api.Entities.BankCustomer+Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}