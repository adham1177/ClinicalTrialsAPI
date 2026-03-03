using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalTrialsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddClinicalTrial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicalTrialId",
                table: "Patients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClinicalTrials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalTrials", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ClinicalTrialId",
                table: "Patients",
                column: "ClinicalTrialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ClinicalTrials_ClinicalTrialId",
                table: "Patients",
                column: "ClinicalTrialId",
                principalTable: "ClinicalTrials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ClinicalTrials_ClinicalTrialId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "ClinicalTrials");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ClinicalTrialId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ClinicalTrialId",
                table: "Patients");
        }
    }
}
