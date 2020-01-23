﻿// <auto-generated />
using System;
using GroazApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroazApi.Migrations
{
    [DbContext(typeof(GroazContext))]
    partial class GroazContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroazApi.Models.Groaz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IdParain")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NiveauDeBins")
                        .HasColumnType("int");

                    b.Property<string>("Trut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdParain");

                    b.ToTable("GroazSet");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c6773d4-02a4-4a70-96e6-98f28dc8c0a5"),
                            DateNaissance = new DateTime(1908, 10, 9, 12, 22, 12, 0, DateTimeKind.Unspecified),
                            NiveauDeBins = 3,
                            Trut = "Braz pizza"
                        },
                        new
                        {
                            Id = new Guid("2d4ff6cf-ae3f-4fde-b3a5-f08d352e1491"),
                            DateNaissance = new DateTime(2020, 1, 23, 10, 17, 57, 469, DateTimeKind.Local).AddTicks(8683),
                            IdParain = new Guid("2c6773d4-02a4-4a70-96e6-98f28dc8c0a5"),
                            NiveauDeBins = 5,
                            Trut = "Papa pizza"
                        });
                });

            modelBuilder.Entity("GroazApi.Models.Groaz", b =>
                {
                    b.HasOne("GroazApi.Models.Groaz", "Parain")
                        .WithMany("FilleulSet")
                        .HasForeignKey("IdParain");
                });
#pragma warning restore 612, 618
        }
    }
}