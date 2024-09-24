using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spoonacular.API.Migrations
{
    /// <inheritdoc />
    public partial class finalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalHourSpent",
                table: "DailyBurntCalories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHourSpent",
                table: "DailyBurntCalories");
        }
    }
}
