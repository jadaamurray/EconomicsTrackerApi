using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomicsTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class FixSourceAutoIncrement3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Drop existing primary key constraint
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sources",
                table: "Sources");

            // Recreate column with auto-increment
            migrationBuilder.AlterColumn<int>(
                name: "SourceId",
                table: "Sources",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            // Restore primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_Sources",
                table: "Sources",
                column: "SourceId");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
