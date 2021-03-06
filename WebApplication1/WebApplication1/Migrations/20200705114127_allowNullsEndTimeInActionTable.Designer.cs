﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200705114127_allowNullsEndTimeInActionTable")]
    partial class allowNullsEndTimeInActionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Action", b =>
                {
                    b.Property<int>("IdAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("NeedSpecialEquipment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAction");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("WebApplication1.Models.FireTruck", b =>
                {
                    b.Property<int>("IdFireTruck")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OperationalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<bool>("SpecialEquipment")
                        .HasColumnType("bit");

                    b.HasKey("IdFireTruck");

                    b.ToTable("FireTrucks");
                });

            modelBuilder.Entity("WebApplication1.Models.FireTruck_Action", b =>
                {
                    b.Property<int>("IdFireTruckAction")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AssigmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAction")
                        .HasColumnType("int");

                    b.Property<int>("IdFireTruck")
                        .HasColumnType("int");

                    b.HasKey("IdFireTruckAction");

                    b.HasIndex("IdAction");

                    b.HasIndex("IdFireTruck");

                    b.ToTable("FireTruck_Actions");
                });

            modelBuilder.Entity("WebApplication1.Models.Firefighter", b =>
                {
                    b.Property<int>("IdFireFighter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdFireFighter");

                    b.ToTable("Firefighters");
                });

            modelBuilder.Entity("WebApplication1.Models.Firefighter_Action", b =>
                {
                    b.Property<int>("IdAction")
                        .HasColumnType("int");

                    b.Property<int>("IdFirefighter")
                        .HasColumnType("int");

                    b.HasKey("IdAction", "IdFirefighter");

                    b.HasIndex("IdFirefighter");

                    b.ToTable("Firefighter_Actions");
                });

            modelBuilder.Entity("WebApplication1.Models.FireTruck_Action", b =>
                {
                    b.HasOne("WebApplication1.Models.Action", "Action")
                        .WithMany("FireTruck_Action")
                        .HasForeignKey("IdAction")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.FireTruck", "FireTruck")
                        .WithMany("FireTruck_Action")
                        .HasForeignKey("IdFireTruck")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Firefighter_Action", b =>
                {
                    b.HasOne("WebApplication1.Models.Action", "Action")
                        .WithMany("Firefighter_Action")
                        .HasForeignKey("IdAction")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Firefighter", "Firefighter")
                        .WithMany("Firefighter_Action")
                        .HasForeignKey("IdFirefighter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
