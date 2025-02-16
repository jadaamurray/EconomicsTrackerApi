﻿// <auto-generated />
using System;
using EconomicsTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EconomicsTrackerApi.Migrations
{
    [DbContext(typeof(EconomicsTrackerContext))]
    partial class EconomicsTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("EconomicsTrackerApi.Models.Data", b =>
                {
                    b.Property<string>("DataId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("IndicatorId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SourceId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("DataId");

                    b.HasIndex("IndicatorId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SourceId");

                    b.ToTable("Data");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.DataLog", b =>
                {
                    b.Property<string>("DataLogId")
                        .HasColumnType("TEXT");

                    b.Property<string>("DataId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTimeAccessed")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DataLogId");

                    b.HasIndex("DataId");

                    b.HasIndex("UserId");

                    b.ToTable("DataLog");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.Indicator", b =>
                {
                    b.Property<string>("IndicatorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("IndicatorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IndicatorId");

                    b.ToTable("Indicators");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.Region", b =>
                {
                    b.Property<string>("RegionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.Source", b =>
                {
                    b.Property<string>("SourceId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SourceId");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.Data", b =>
                {
                    b.HasOne("EconomicsTrackerApi.Models.Indicator", null)
                        .WithMany("Values")
                        .HasForeignKey("IndicatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EconomicsTrackerApi.Models.Region", null)
                        .WithMany("RegionDataPoints")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EconomicsTrackerApi.Models.Source", null)
                        .WithMany("SourceDataPoints")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.DataLog", b =>
                {
                    b.HasOne("EconomicsTrackerApi.Models.Data", "Data")
                        .WithMany("DataLogs")
                        .HasForeignKey("DataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EconomicsTrackerApi.Models.User", "User")
                        .WithMany("DataLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Data");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.Data", b =>
                {
                    b.Navigation("DataLogs");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.Indicator", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.Region", b =>
                {
                    b.Navigation("RegionDataPoints");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.Source", b =>
                {
                    b.Navigation("SourceDataPoints");
                });

            modelBuilder.Entity("EconomicsTrackerApi.Models.User", b =>
                {
                    b.Navigation("DataLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
