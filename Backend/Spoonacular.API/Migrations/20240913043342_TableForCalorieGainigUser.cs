using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spoonacular.API.Migrations
{
    /// <inheritdoc />
    public partial class TableForCalorieGainigUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalorieGainigUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetGainedCalories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalorieGainigUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyGainedCalories",
                columns: table => new
                {
                    WeeklyGainedCaloriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalGainedCalories = table.Column<int>(type: "int", nullable: false),
                    CalorieGainigUserUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyGainedCalories", x => x.WeeklyGainedCaloriesId);
                    table.ForeignKey(
                        name: "FK_WeeklyGainedCalories_CalorieGainigUsers_CalorieGainigUserUserId",
                        column: x => x.CalorieGainigUserUserId,
                        principalTable: "CalorieGainigUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DailyGainedCalories",
                columns: table => new
                {
                    DailyGainedCaloriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GainedCaloriesGoal = table.Column<int>(type: "int", nullable: false),
                    TotalGainedCalories = table.Column<int>(type: "int", nullable: false),
                    CalorieGainigUserUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WeeklyGainedCaloriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyGainedCalories", x => x.DailyGainedCaloriesId);
                    table.ForeignKey(
                        name: "FK_DailyGainedCalories_CalorieGainigUsers_CalorieGainigUserUserId",
                        column: x => x.CalorieGainigUserUserId,
                        principalTable: "CalorieGainigUsers",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_DailyGainedCalories_WeeklyGainedCalories_WeeklyGainedCaloriesId",
                        column: x => x.WeeklyGainedCaloriesId,
                        principalTable: "WeeklyGainedCalories",
                        principalColumn: "WeeklyGainedCaloriesId");
                });

            migrationBuilder.CreateTable(
                name: "FoodWithCalorie",
                columns: table => new
                {
                    FoodWithCalorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GainedCalories = table.Column<int>(type: "int", nullable: false),
                    DailyGainedCaloriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodWithCalorie", x => x.FoodWithCalorieId);
                    table.ForeignKey(
                        name: "FK_FoodWithCalorie_DailyGainedCalories_DailyGainedCaloriesId",
                        column: x => x.DailyGainedCaloriesId,
                        principalTable: "DailyGainedCalories",
                        principalColumn: "DailyGainedCaloriesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyGainedCalories_CalorieGainigUserUserId",
                table: "DailyGainedCalories",
                column: "CalorieGainigUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyGainedCalories_WeeklyGainedCaloriesId",
                table: "DailyGainedCalories",
                column: "WeeklyGainedCaloriesId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodWithCalorie_DailyGainedCaloriesId",
                table: "FoodWithCalorie",
                column: "DailyGainedCaloriesId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyGainedCalories_CalorieGainigUserUserId",
                table: "WeeklyGainedCalories",
                column: "CalorieGainigUserUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodWithCalorie");

            migrationBuilder.DropTable(
                name: "DailyGainedCalories");

            migrationBuilder.DropTable(
                name: "WeeklyGainedCalories");

            migrationBuilder.DropTable(
                name: "CalorieGainigUsers");
        }
    }
}
