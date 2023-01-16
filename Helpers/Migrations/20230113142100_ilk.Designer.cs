﻿// <auto-generated />
using FutbolDunyasi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FutbolDunyasi.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20230113142100_ilk")]
    partial class ilk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FutbolDunyasi.Data.Oyuncu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FormaNo")
                        .HasColumnType("int");

                    b.Property<int>("Mevki")
                        .HasColumnType("int");

                    b.Property<int>("TakimId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TakimId");

                    b.ToTable("Oyuncular");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Altay Bayındır",
                            FormaNo = 1,
                            Mevki = 1,
                            TakimId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ad = "Serdar Dursun",
                            FormaNo = 19,
                            Mevki = 4,
                            TakimId = 1
                        },
                        new
                        {
                            Id = 3,
                            Ad = "Fernando Muslera",
                            FormaNo = 1,
                            Mevki = 1,
                            TakimId = 2
                        },
                        new
                        {
                            Id = 4,
                            Ad = "Haris Seferovic",
                            FormaNo = 9,
                            Mevki = 4,
                            TakimId = 2
                        });
                });

            modelBuilder.Entity("FutbolDunyasi.Data.Takim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Takimlar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ad = "Fenerbahçe"
                        },
                        new
                        {
                            Id = 2,
                            Ad = "Galatasaray"
                        });
                });

            modelBuilder.Entity("FutbolDunyasi.Data.Oyuncu", b =>
                {
                    b.HasOne("FutbolDunyasi.Data.Takim", "Takim")
                        .WithMany("Oyuncular")
                        .HasForeignKey("TakimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Takim");
                });

            modelBuilder.Entity("FutbolDunyasi.Data.Takim", b =>
                {
                    b.Navigation("Oyuncular");
                });
#pragma warning restore 612, 618
        }
    }
}
