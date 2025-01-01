﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeriodicTable.API.Data;

#nullable disable

namespace PeriodicTable.API.Migrations
{
    [DbContext(typeof(PeriodicTableContext))]
    [Migration("20241231162724_disableAutoIncrementForElements")]
    partial class disableAutoIncrementForElements
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PeriodicTable.API.Model.Discoverer", b =>
                {
                    b.Property<int>("Did")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Did"));

                    b.Property<DateTime?>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<int>("Enumber")
                        .HasColumnType("int");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Did");

                    b.HasIndex("Enumber");

                    b.ToTable("Discoverers");
                });

            modelBuilder.Entity("PeriodicTable.API.Model.Element", b =>
                {
                    b.Property<int>("Enumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Enumber"));

                    b.Property<string>("Appearance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AtomicMass")
                        .HasColumnType("float");

                    b.Property<double?>("BoilingPoint")
                        .HasColumnType("float");

                    b.Property<string>("ESymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gnumber")
                        .HasColumnType("int");

                    b.Property<double?>("MeltingPoint")
                        .HasColumnType("float");

                    b.Property<string>("Phase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Enumber");

                    b.HasIndex("Gnumber");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("PeriodicTable.API.Model.Group", b =>
                {
                    b.Property<int>("Gnumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Gnumber"));

                    b.Property<string>("Gname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Gnumber");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("PeriodicTable.API.Model.Discoverer", b =>
                {
                    b.HasOne("PeriodicTable.API.Model.Element", "ElementDiscovered")
                        .WithMany()
                        .HasForeignKey("Enumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElementDiscovered");
                });

            modelBuilder.Entity("PeriodicTable.API.Model.Element", b =>
                {
                    b.HasOne("PeriodicTable.API.Model.Group", "Egroup")
                        .WithMany()
                        .HasForeignKey("Gnumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Egroup");
                });
#pragma warning restore 612, 618
        }
    }
}
