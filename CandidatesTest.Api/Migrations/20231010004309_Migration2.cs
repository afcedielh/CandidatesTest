using Microsoft.EntityFrameworkCore.Migrations;

namespace CandidatesTest.Api.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCandidate",
                table: "candidateExperiences",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCandidate",
                table: "candidateExperiences");
        }
    }
}
