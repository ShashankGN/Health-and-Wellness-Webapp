﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spoonacular.API.Data;

#nullable disable

namespace Spoonacular.API.Migrations
{
    [DbContext(typeof(CostomerDbContext))]
    [Migration("20240913043342_TableForCalorieGainigUser")]
    partial class TableForCalorieGainigUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Spoonacular.API.Model.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"));

                    b.Property<int>("BurntCalories")
                        .HasColumnType("int");

                    b.Property<int?>("DailyBurntCaloriesId")
                        .HasColumnType("int");

                    b.Property<double>("HoursSpent")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId");

                    b.HasIndex("DailyBurntCaloriesId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("Spoonacular.API.Model.CalorieGainigUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TargetGainedCalories")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("CalorieGainigUsers");
                });

            modelBuilder.Entity("Spoonacular.API.Model.Costomer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("BMI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Spoonacular.API.Model.DailyBurntCalories", b =>
                {
                    b.Property<int>("DailyBurntCaloriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyBurntCaloriesId"));

                    b.Property<int>("CaloriesGoal")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalBurntCalories")
                        .HasColumnType("int");

                    b.Property<double>("TotalHourSpent")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("WeeklyBurntCaloriesId")
                        .HasColumnType("int");

                    b.HasKey("DailyBurntCaloriesId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeeklyBurntCaloriesId");

                    b.ToTable("DailyBurntCalories");
                });

            modelBuilder.Entity("Spoonacular.API.Model.DailyGainedCalories", b =>
                {
                    b.Property<int>("DailyGainedCaloriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DailyGainedCaloriesId"));

                    b.Property<string>("CalorieGainigUserUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GainedCaloriesGoal")
                        .HasColumnType("int");

                    b.Property<int>("TotalGainedCalories")
                        .HasColumnType("int");

                    b.Property<int?>("WeeklyGainedCaloriesId")
                        .HasColumnType("int");

                    b.HasKey("DailyGainedCaloriesId");

                    b.HasIndex("CalorieGainigUserUserId");

                    b.HasIndex("WeeklyGainedCaloriesId");

                    b.ToTable("DailyGainedCalories");
                });

            modelBuilder.Entity("Spoonacular.API.Model.FoodWithCalorie", b =>
                {
                    b.Property<int>("FoodWithCalorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodWithCalorieId"));

                    b.Property<int?>("DailyGainedCaloriesId")
                        .HasColumnType("int");

                    b.Property<int>("GainedCalories")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodWithCalorieId");

                    b.HasIndex("DailyGainedCaloriesId");

                    b.ToTable("FoodWithCalorie");
                });

            modelBuilder.Entity("Spoonacular.API.Model.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TargetBurntCalories")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Spoonacular.API.Model.WeeklyBurntCalories", b =>
                {
                    b.Property<int>("WeeklyBurntCaloriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeeklyBurntCaloriesId"));

                    b.Property<int>("TotalBurntCalories")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("WeekStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("WeeklyBurntCaloriesId");

                    b.HasIndex("UserId");

                    b.ToTable("WeeklyBurntCalories");
                });

            modelBuilder.Entity("Spoonacular.API.Model.WeeklyGainedCalories", b =>
                {
                    b.Property<int>("WeeklyGainedCaloriesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeeklyGainedCaloriesId"));

                    b.Property<string>("CalorieGainigUserUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TotalGainedCalories")
                        .HasColumnType("int");

                    b.Property<DateTime>("WeekStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("WeeklyGainedCaloriesId");

                    b.HasIndex("CalorieGainigUserUserId");

                    b.ToTable("WeeklyGainedCalories");
                });

            modelBuilder.Entity("Spoonacular.API.Model.Activity", b =>
                {
                    b.HasOne("Spoonacular.API.Model.DailyBurntCalories", null)
                        .WithMany("Activities")
                        .HasForeignKey("DailyBurntCaloriesId");
                });

            modelBuilder.Entity("Spoonacular.API.Model.DailyBurntCalories", b =>
                {
                    b.HasOne("Spoonacular.API.Model.User", null)
                        .WithMany("DailyBurntCalories")
                        .HasForeignKey("UserId");

                    b.HasOne("Spoonacular.API.Model.WeeklyBurntCalories", null)
                        .WithMany("DailyRecords")
                        .HasForeignKey("WeeklyBurntCaloriesId");
                });

            modelBuilder.Entity("Spoonacular.API.Model.DailyGainedCalories", b =>
                {
                    b.HasOne("Spoonacular.API.Model.CalorieGainigUser", null)
                        .WithMany("DailyGainedCalories")
                        .HasForeignKey("CalorieGainigUserUserId");

                    b.HasOne("Spoonacular.API.Model.WeeklyGainedCalories", null)
                        .WithMany("DailyRecords")
                        .HasForeignKey("WeeklyGainedCaloriesId");
                });

            modelBuilder.Entity("Spoonacular.API.Model.FoodWithCalorie", b =>
                {
                    b.HasOne("Spoonacular.API.Model.DailyGainedCalories", null)
                        .WithMany("foodWithCalories")
                        .HasForeignKey("DailyGainedCaloriesId");
                });

            modelBuilder.Entity("Spoonacular.API.Model.WeeklyBurntCalories", b =>
                {
                    b.HasOne("Spoonacular.API.Model.User", null)
                        .WithMany("WeeklyBurntCalories")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Spoonacular.API.Model.WeeklyGainedCalories", b =>
                {
                    b.HasOne("Spoonacular.API.Model.CalorieGainigUser", null)
                        .WithMany("WeeklyGainedCalories")
                        .HasForeignKey("CalorieGainigUserUserId");
                });

            modelBuilder.Entity("Spoonacular.API.Model.CalorieGainigUser", b =>
                {
                    b.Navigation("DailyGainedCalories");

                    b.Navigation("WeeklyGainedCalories");
                });

            modelBuilder.Entity("Spoonacular.API.Model.DailyBurntCalories", b =>
                {
                    b.Navigation("Activities");
                });

            modelBuilder.Entity("Spoonacular.API.Model.DailyGainedCalories", b =>
                {
                    b.Navigation("foodWithCalories");
                });

            modelBuilder.Entity("Spoonacular.API.Model.User", b =>
                {
                    b.Navigation("DailyBurntCalories");

                    b.Navigation("WeeklyBurntCalories");
                });

            modelBuilder.Entity("Spoonacular.API.Model.WeeklyBurntCalories", b =>
                {
                    b.Navigation("DailyRecords");
                });

            modelBuilder.Entity("Spoonacular.API.Model.WeeklyGainedCalories", b =>
                {
                    b.Navigation("DailyRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
