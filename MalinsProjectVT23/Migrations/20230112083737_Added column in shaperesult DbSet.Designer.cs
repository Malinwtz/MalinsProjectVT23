﻿// <auto-generated />
using System;
using MalinsProjectVT23.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230112083737_Added column in shaperesult DbSet")]
    partial class AddedcolumninshaperesultDbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MalinsProjectVT23.Data.Calculation", b =>
                {
                    b.Property<int>("CalculationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CalculationId"), 1L, 1);

                    b.Property<decimal>("Input1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Input2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Result")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CalculationId");

                    b.ToTable("Calculations");
                });

            modelBuilder.Entity("MalinsProjectVT23.Data.RockScissorPaperGameResult", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 1L, 1);

                    b.Property<bool>("Looser")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfLosses")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfWins")
                        .HasColumnType("int");

                    b.Property<bool>("Tie")
                        .HasColumnType("bit");

                    b.Property<bool>("Winner")
                        .HasColumnType("bit");

                    b.HasKey("GameId");

                    b.ToTable("RockScissorPaperGameResults");
                });

            modelBuilder.Entity("MalinsProjectVT23.Data.Shape", b =>
                {
                    b.Property<int>("ShapeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShapeId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShapeId");

                    b.ToTable("Shapes");
                });

            modelBuilder.Entity("MalinsProjectVT23.Data.ShapeResult", b =>
                {
                    b.Property<int>("ShapeResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShapeResultId"), 1L, 1);

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Circumference")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ShapeId")
                        .HasColumnType("int");

                    b.HasKey("ShapeResultId");

                    b.HasIndex("ShapeId");

                    b.ToTable("ShapeResults");
                });

            modelBuilder.Entity("MalinsProjectVT23.Data.ShapeResult", b =>
                {
                    b.HasOne("MalinsProjectVT23.Data.Shape", "Shape")
                        .WithMany()
                        .HasForeignKey("ShapeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shape");
                });
#pragma warning restore 612, 618
        }
    }
}
