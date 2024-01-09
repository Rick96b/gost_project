﻿// <auto-generated />
using System;
using Gost_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gost_Project.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240109095429_AddNullableEnums")]
    partial class AddNullableEnums
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Gost_Project.Data.Entities.DocEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ActualFieldId")
                        .HasColumnType("bigint");

                    b.Property<long>("PrimaryFieldId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Docs");
                });

            modelBuilder.Entity("Gost_Project.Data.Entities.DocReferenceEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ChildDocId")
                        .HasColumnType("bigint");

                    b.Property<long>("ParentalDocId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("DocsReferences");
                });

            modelBuilder.Entity("Gost_Project.Data.Entities.DocStatisticEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Changed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("DocId")
                        .HasColumnType("bigint");

                    b.Property<int>("Views")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("DocStatistics");
                });

            modelBuilder.Entity("Gost_Project.Data.Entities.FieldEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("AcceptanceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AcceptedFirstTimeOrReplaced")
                        .HasColumnType("text");

                    b.Property<string>("ActivityField")
                        .HasColumnType("text");

                    b.Property<int?>("AdoptionLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Amendments")
                        .HasColumnType("text");

                    b.Property<string>("ApplicationArea")
                        .HasColumnType("text");

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<string>("Changes")
                        .HasColumnType("text");

                    b.Property<string>("CodeOKS")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CommissionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Designation")
                        .HasColumnType("text");

                    b.Property<string>("DocumentText")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<int?>("Harmonization")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("boolean");

                    b.Property<string>("KeyPhrases")
                        .HasColumnType("text");

                    b.Property<string>("KeyWords")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("Gost_Project.Data.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("OrgActivity")
                        .HasColumnType("text");

                    b.Property<string>("OrgBranch")
                        .HasColumnType("text");

                    b.Property<string>("OrgName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
