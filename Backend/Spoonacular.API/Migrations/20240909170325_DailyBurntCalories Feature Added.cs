using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spoonacular.API.Migrations
{
    /// <inheritdoc />
    public partial class DailyBurntCaloriesFeatureAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetBurntCalories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "DailyBurntCalories",
                columns: table => new
                {
                    DailyBurntCaloriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBurntCalories = table.Column<int>(type: "int", nullable: false),
                    CaloriesGoal = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyBurntCalories", x => x.DailyBurntCaloriesId);
                    table.ForeignKey(
                        name: "FK_DailyBurntCalories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "WeeklyBurntCalories",
                columns: table => new
                {
                    WeeklyBurntCaloriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalBurntCalories = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyBurntCalories", x => x.WeeklyBurntCaloriesId);
                    table.ForeignKey(
                        name: "FK_WeeklyBurntCalories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyBurntCalories_UserId",
                table: "DailyBurntCalories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyBurntCalories_UserId",
                table: "WeeklyBurntCalories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyBurntCalories");

            migrationBuilder.DropTable(
                name: "WeeklyBurntCalories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
