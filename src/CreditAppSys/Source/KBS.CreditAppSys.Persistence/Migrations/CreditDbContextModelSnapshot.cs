﻿// <auto-generated />
using System;
using KBS.CreditAppSys.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KBS.CreditAppSys.Persistence.Migrations
{
    [DbContext(typeof(CreditDbContext))]
    partial class CreditDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KBS.CreditAppSys.Domain.Entities.ApplicationResult", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("ApplicationResult", "Credit");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "RequestReceived"
                        },
                        new
                        {
                            Id = (byte)10,
                            Name = "Accepted"
                        },
                        new
                        {
                            Id = (byte)20,
                            Name = "Denied"
                        },
                        new
                        {
                            Id = (byte)30,
                            Name = "ReviewNeeded"
                        });
                });

            modelBuilder.Entity("KBS.CreditAppSys.Domain.Entities.CreditApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(10,2)")
                        .HasColumnOrder(11);

                    b.Property<DateTime>("ApplicationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnOrder(14)
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<byte>("ApplicationResultType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1)
                        .HasColumnOrder(10);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5)
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(9);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(7);

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(4);

                    b.Property<byte>("EntityStatusType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1)
                        .HasColumnOrder(8);

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("DECIMAL(4,2)")
                        .HasColumnOrder(13);

                    b.Property<byte>("LoanTerm")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(12);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(6);

                    b.Property<Guid?>("UpdatedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("CustomerId");

                    b.ToTable("CreditApplication", "Credit");

                    b.HasData(
                        new
                        {
                            Id = new Guid("826df2db-7db8-4b3c-8a7b-7e0b90e5a0e6"),
                            Amount = 500000m,
                            ApplicationDate = new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationResultType = (byte)1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            CustomerId = new Guid("42614cfd-7d0f-471b-9718-c0287776dde4"),
                            EntityStatusType = (byte)1,
                            InterestRate = 1.9m,
                            LoanTerm = (byte)48
                        },
                        new
                        {
                            Id = new Guid("8b93a4f0-8e4c-4c0e-99c8-549b953a1c23"),
                            Amount = 100000m,
                            ApplicationDate = new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationResultType = (byte)2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            CustomerId = new Guid("799e8936-31e4-48db-a751-b378a083ea55"),
                            EntityStatusType = (byte)1,
                            InterestRate = 1.9m,
                            LoanTerm = (byte)60
                        });
                });

            modelBuilder.Entity("KBS.CreditAppSys.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5)
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(7);

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(4);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnOrder(12);

                    b.Property<byte>("EntityStatusType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1)
                        .HasColumnOrder(8);

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnOrder(9);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(10);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(11);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(6);

                    b.Property<Guid?>("UpdatedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Customer", "Credit");

                    b.HasData(
                        new
                        {
                            Id = new Guid("42614cfd-7d0f-471b-9718-c0287776dde4"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            Email = "ufuk.elibol@test.email.com",
                            EntityStatusType = (byte)1,
                            IdentityNumber = "12345678901",
                            Name = "Ufuk",
                            Surname = "Elibol"
                        },
                        new
                        {
                            Id = new Guid("799e8936-31e4-48db-a751-b378a083ea55"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            Email = "yasemin.elibol@test.email.com",
                            EntityStatusType = (byte)1,
                            IdentityNumber = "98765432109",
                            Name = "Yaseminnur",
                            Surname = "Elibol"
                        });
                });

            modelBuilder.Entity("KBS.CreditAppSys.Domain.Entities.CustomerCriteria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<bool>("AdverseCreditHistory")
                        .HasColumnType("bit")
                        .HasColumnOrder(13);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5)
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.Property<short>("CreditScore")
                        .HasColumnType("smallint")
                        .HasColumnOrder(10);

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(9);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(7);

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(4);

                    b.Property<byte>("EntityStatusType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue((byte)1)
                        .HasColumnOrder(8);

                    b.Property<decimal>("MonthlyDebt")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasColumnOrder(12);

                    b.Property<decimal>("MonthlyIncome")
                        .HasColumnType("DECIMAL(8,2)")
                        .HasColumnOrder(11);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(6);

                    b.Property<Guid?>("UpdatedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerCriteria", "Credit");

                    b.HasData(
                        new
                        {
                            Id = new Guid("45ba2cf1-6824-43b9-93bd-0b2a5ef30565"),
                            AdverseCreditHistory = false,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreditScore = (short)900,
                            CustomerId = new Guid("42614cfd-7d0f-471b-9718-c0287776dde4"),
                            EntityStatusType = (byte)1,
                            MonthlyDebt = 10000m,
                            MonthlyIncome = 50000m
                        },
                        new
                        {
                            Id = new Guid("035c056c-a62e-4d9c-9771-3abc43962608"),
                            AdverseCreditHistory = false,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreditScore = (short)900,
                            CustomerId = new Guid("799e8936-31e4-48db-a751-b378a083ea55"),
                            EntityStatusType = (byte)1,
                            MonthlyDebt = 15000m,
                            MonthlyIncome = 40000m
                        });
                });

            modelBuilder.Entity("KBS.CreditAppSys.Domain.Entities.EntityStatus", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnOrder(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("EntityStatus", "Credit");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "Active"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "Passive"
                        },
                        new
                        {
                            Id = (byte)3,
                            Name = "Deleted"
                        });
                });

            modelBuilder.Entity("KBS.CreditAppSys.Domain.Entities.CreditApplication", b =>
                {
                    b.HasOne("KBS.CreditAppSys.Domain.Entities.Customer", "Customer")
                        .WithMany("CreditApplications")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("KBS.CreditAppSys.Domain.Entities.CustomerCriteria", b =>
                {
                    b.HasOne("KBS.CreditAppSys.Domain.Entities.Customer", "Customer")
                        .WithMany("CustomerCriterias")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("KBS.CreditAppSys.Domain.Entities.Customer", b =>
                {
                    b.Navigation("CreditApplications");

                    b.Navigation("CustomerCriterias");
                });
#pragma warning restore 612, 618
        }
    }
}
