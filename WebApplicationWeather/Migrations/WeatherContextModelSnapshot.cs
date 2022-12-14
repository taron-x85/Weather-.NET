// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationWeather.DataSrc;

#nullable disable

namespace WebApplicationWeather.Migrations
{
    [DbContext(typeof(WeatherContext))]
    partial class WeatherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplicationWeather.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WebApplicationWeather.Models.Summary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsNight")
                        .HasColumnType("bit");

                    b.Property<string>("PicPath")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.ToTable("Summaries");
                });

            modelBuilder.Entity("WebApplicationWeather.Models.WeatherDaily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("SummaryId")
                        .HasColumnType("int");

                    b.Property<float>("TemperatureMaxC")
                        .HasColumnType("real");

                    b.Property<float>("TemperatureMinC")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Date");

                    b.HasIndex("LocationId");

                    b.HasIndex("SummaryId");

                    b.ToTable("WeatherDailies");
                });

            modelBuilder.Entity("WebApplicationWeather.Models.WeatherHourly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("SummaryId")
                        .HasColumnType("int");

                    b.Property<float>("TemperatureC")
                        .HasColumnType("real");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WeatherDailyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("SummaryId");

                    b.HasIndex("Time");

                    b.HasIndex("WeatherDailyId");

                    b.ToTable("WeatherHourlies");
                });

            modelBuilder.Entity("WebApplicationWeather.Models.WeatherDaily", b =>
                {
                    b.HasOne("WebApplicationWeather.Models.Location", "Location")
                        .WithMany("Weathers")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationWeather.Models.Summary", "Summary")
                        .WithMany("WeatherDailies")
                        .HasForeignKey("SummaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Summary");
                });

            modelBuilder.Entity("WebApplicationWeather.Models.WeatherHourly", b =>
                {
                    b.HasOne("WebApplicationWeather.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationWeather.Models.Summary", "Summary")
                        .WithMany("WeatherHourlies")
                        .HasForeignKey("SummaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationWeather.Models.WeatherDaily", "WeatherDaily")
                        .WithMany("WeatherHourlies")
                        .HasForeignKey("WeatherDailyId");

                    b.Navigation("Location");

                    b.Navigation("Summary");

                    b.Navigation("WeatherDaily");
                });

            modelBuilder.Entity("WebApplicationWeather.Models.Location", b =>
                {
                    b.Navigation("Weathers");
                });

            modelBuilder.Entity("WebApplicationWeather.Models.Summary", b =>
                {
                    b.Navigation("WeatherDailies");

                    b.Navigation("WeatherHourlies");
                });

            modelBuilder.Entity("WebApplicationWeather.Models.WeatherDaily", b =>
                {
                    b.Navigation("WeatherHourlies");
                });
#pragma warning restore 612, 618
        }
    }
}
