using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePopulationRecordsCreatedAtConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PopulationRecords",
                newName: "Created at");

            migrationBuilder.AlterColumn<long>(
                name: "Created at",
                table: "PopulationRecords",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created at",
                table: "PopulationRecords",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PopulationRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
