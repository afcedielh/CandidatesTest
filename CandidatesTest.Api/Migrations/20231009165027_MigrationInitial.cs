using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidatesTest.Api.Migrations
{
    public partial class MigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    IdCandidate = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidates", x => x.IdCandidate);
                });

            migrationBuilder.CreateTable(
                name: "candidateExperiences",
                columns: table => new
                {
                    IdCandidateExperience = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    Begindate = table.Column<DateTime>(nullable: false),
                    Enddate = table.Column<DateTime>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    CandidateIdCandidate = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidateExperiences", x => x.IdCandidateExperience);
                    table.ForeignKey(
                        name: "FK_candidateExperiences_candidates_CandidateIdCandidate",
                        column: x => x.CandidateIdCandidate,
                        principalTable: "candidates",
                        principalColumn: "IdCandidate",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidateExperiences_CandidateIdCandidate",
                table: "candidateExperiences",
                column: "CandidateIdCandidate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidateExperiences");

            migrationBuilder.DropTable(
                name: "candidates");
        }
    }
}
