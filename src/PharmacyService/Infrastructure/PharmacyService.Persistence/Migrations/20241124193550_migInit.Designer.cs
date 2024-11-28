﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PharmacyService.Persistence.DbContexts;

#nullable disable

namespace PharmacyService.Persistence.Migrations
{
    [DbContext(typeof(PharmacyDbContext))]
    [Migration("20241124193550_migInit")]
    partial class migInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchAddressEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DistrictId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<long?>("NeighbourhoodId")
                        .HasColumnType("bigint");

                    b.Property<long>("PharmacyBranchEntityBranchId")
                        .HasColumnType("bigint");

                    b.Property<long>("PharmacyBranchEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProvinceId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<long?>("StreetId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyBranchEntityId");

                    b.ToTable("PharmacyBranchAddressEntities");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchContactEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<byte>("ContactType")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("PharmacyBranchEntityId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyBranchEntityId");

                    b.ToTable("PharmacyBranchContactEntities");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("PharmacyEntityId")
                        .HasColumnType("bigint");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyEntityId");

                    b.ToTable("PharmacyBranchEntities");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("CreatedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LicenseNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Status")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("UpdatedUserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UK_Pharmacy_Name")
                        .IsUnique();

                    b.ToTable("PharmacyEntities");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchAddressEntity", b =>
                {
                    b.HasOne("PharmacyService.Domain.Entities.PharmacyBranchEntity", "PharmacyBranchEntity")
                        .WithMany("PharmacyBranchAddressEntities")
                        .HasForeignKey("PharmacyBranchEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PharmacyBranchEntity");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchContactEntity", b =>
                {
                    b.HasOne("PharmacyService.Domain.Entities.PharmacyBranchEntity", "PharmacyBranchEntity")
                        .WithMany("PharmacyBranchContactEntities")
                        .HasForeignKey("PharmacyBranchEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PharmacyBranchEntity");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchEntity", b =>
                {
                    b.HasOne("PharmacyService.Domain.Entities.PharmacyEntity", "PharmacyEntity")
                        .WithMany("PharmacyBranchEntities")
                        .HasForeignKey("PharmacyEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PharmacyEntity");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyBranchEntity", b =>
                {
                    b.Navigation("PharmacyBranchAddressEntities");

                    b.Navigation("PharmacyBranchContactEntities");
                });

            modelBuilder.Entity("PharmacyService.Domain.Entities.PharmacyEntity", b =>
                {
                    b.Navigation("PharmacyBranchEntities");
                });
#pragma warning restore 612, 618
        }
    }
}