using EconomicsTrackerApi.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomicsTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class autoIncrementOtherModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var tables = new[] { "Data", "DataLog", "Indicator", "Region" };

            foreach (var table in tables)
            {
                // Drop primary key constraint
                if (table.Equals("Data") || table.Equals("DataLog")){ // table name has s for regions and indicators
                migrationBuilder.DropPrimaryKey(
                    name: $"PK_{table}",
                    table: table);

                // Recreate column with auto-increment
                migrationBuilder.AlterColumn<int>(
                    name: $"{table}Id",
                    table: table,
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "INTEGER")
                    .Annotation("Sqlite:Autoincrement", true); 

                // Restore the primary key
                migrationBuilder.AddPrimaryKey(
                    name: $"PK_{table}",
                    table: table,
                    column: $"{table}Id");
                } else {
                    migrationBuilder.DropPrimaryKey(
                    name: $"PK_{table}",
                    table: $"{table}s");

                // Recreate column with auto-increment
                migrationBuilder.AlterColumn<int>(
                    name: $"{table}Id",
                    table: $"{table}s",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "INTEGER")
                    .Annotation("Sqlite:Autoincrement", true); 

                // Restore the primary key
                migrationBuilder.AddPrimaryKey(
                    name: $"PK_{table}",
                    table: $"{table}s",
                    column: $"{table}Id");
                }

            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
