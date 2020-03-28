﻿// <auto-generated />
using System;
using CarPool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarPool.Migrations
{
    [DbContext(typeof(RoutesContext))]
    partial class RoutesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarPool.Models.Route", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("createdBy")
                        .HasColumnName("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnName("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("finalDestination")
                        .IsRequired()
                        .HasColumnName("finaldestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnName("price")
                        .HasColumnType("float");

                    b.Property<int>("seats")
                        .HasColumnName("seats")
                        .HasColumnType("int");

                    b.Property<string>("startDestination")
                        .IsRequired()
                        .HasColumnName("startdestination")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("route");
                });

            modelBuilder.Entity("CarPool.Models.RouteUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoutId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("routeUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
