﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ShipBobApp.Data;
using System;

namespace ShipBobApp.Migrations
{
    [DbContext(typeof(ShipBobAppContext))]
    partial class ShipBobAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShipBobApp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(25);

                    b.Property<string>("RecipientName")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .HasMaxLength(25);

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(50);

                    b.Property<string>("TrackingId")
                        .HasMaxLength(50);

                    b.Property<int>("UserId");

                    b.Property<int>("ZipCode");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ShipBobApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ShipBobApp.Models.Order", b =>
                {
                    b.HasOne("ShipBobApp.Models.User", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
