using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovePopulationPropertyFromPopulationRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Population",
                table: "PopulationRecords",
                newName: "PopulationSize");

            migrationBuilder.AddColumn<Guid>(
                name: "PopulationId",
                table: "PopulationRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Populations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Createdat = table.Column<long>(name: "Created at", type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Populations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PopulationRecords_PopulationId",
                table: "PopulationRecords",
                column: "PopulationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PopulationRecords_Populations_PopulationId",
                table: "PopulationRecords",
                column: "PopulationId",
                principalTable: "Populations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PopulationRecords_Populations_PopulationId",
                table: "PopulationRecords");

            migrationBuilder.DropTable(
                name: "Populations");

            migrationBuilder.DropIndex(
                name: "IX_PopulationRecords_PopulationId",
                table: "PopulationRecords");

            migrationBuilder.DropColumn(
                name: "PopulationId",
                table: "PopulationRecords");

            migrationBuilder.RenameColumn(
                name: "PopulationSize",
                table: "PopulationRecords",
                newName: "Population");
        }
    }
}
