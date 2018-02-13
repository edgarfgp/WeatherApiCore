﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WeatherApiCore.Data;

namespace WeatherApiCore.Migrations
{
    [DbContext(typeof(WeatherDBContext))]
    partial class WeatherDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherApiCore.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Forecast");
                });

            modelBuilder.Entity("WeatherApiCore.Entities.Day", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CityId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<long>("Humidity");

                    b.Property<string>("Icon");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<double>("Temp");

                    b.Property<long>("TempMax");

                    b.Property<long>("TempMin");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Week");
                });

            modelBuilder.Entity("WeatherApiCore.Entities.Day", b =>
                {
                    b.HasOne("WeatherApiCore.Entities.City", "City")
                        .WithMany("Days")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
