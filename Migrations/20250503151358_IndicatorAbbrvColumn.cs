using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomicsTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class IndicatorAbbrvColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "Indicators",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Indicators");
        }
    }
}
