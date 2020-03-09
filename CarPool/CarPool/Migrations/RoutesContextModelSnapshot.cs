﻿// <auto-generated />
using System;
using CarPool.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CarPool.Migrations
{
    [DbContext(typeof(RoutesContext))]
    partial class RoutesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CarPool.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("CarPool.Models.Route", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("date")
                        .HasColumnName("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("finalDestination")
                        .IsRequired()
                        .HasColumnName("finaldestination")
                        .HasColumnType("text");

                    b.Property<double>("price")
                        .HasColumnName("price")
                        .HasColumnType("double precision");

                    b.Property<int>("seats")
                        .HasColumnName("seats")
                        .HasColumnType("integer");

                    b.Property<string>("startDestination")
                        .IsRequired()
                        .HasColumnName("startdestination")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("route");
                });

            modelBuilder.Entity("CarPool.Models.RouteUser", b =>
                {
                    b.Property<int>("RoutId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("RoutId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RouteUser");
                });

            modelBuilder.Entity("CarPool.Models.RouteUser", b =>
                {
                    b.HasOne("CarPool.Models.Route", "Route")
                        .WithMany("RouteUser")
                        .HasForeignKey("RoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPool.Models.AppUser", "user")
                        .WithMany("RouteUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
