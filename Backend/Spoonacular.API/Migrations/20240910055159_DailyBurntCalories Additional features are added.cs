using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spoonacular.API.Migrations
{
    /// <inheritdoc />
    public partial class DailyBurntCaloriesAdditionalfeaturesareadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeeklyBurntCaloriesId",
                table: "DailyBurntCalories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BurntCalories = table.Column<int>(type: "int", nullable: false),
                    HoursSpent = table.Column<double>(type: "float", nullable: false),
                    DailyBurntCaloriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activity_DailyBurntCalories_DailyBurntCaloriesId",
                        column: x => x.DailyBurntCaloriesId,
                        principalTable: "DailyBurntCalories",
                        principalColumn: "DailyBurntCaloriesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyBurntCalories_WeeklyBurntCaloriesId",
                table: "DailyBurntCalories",
                column: "WeeklyBurntCaloriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_DailyBurntCaloriesId",
                table: "Activity",
                column: "DailyBurntCaloriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyBurntCalories_WeeklyBurntCalories_WeeklyBurntCaloriesId",
                table: "DailyBurntCalories",
                column: "WeeklyBurntCaloriesId",
                principalTable: "WeeklyBurntCalories",
                principalColumn: "WeeklyBurntCaloriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyBurntCalories_WeeklyBurntCalories_WeeklyBurntCaloriesId",
                table: "DailyBurntCalories");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_DailyBurntCalories_WeeklyBurntCaloriesId",
                table: "DailyBurntCalories");

            migrationBuilder.DropColumn(
                name: "WeeklyBurntCaloriesId",
                table: "DailyBurntCalories");
        }
    }
}
