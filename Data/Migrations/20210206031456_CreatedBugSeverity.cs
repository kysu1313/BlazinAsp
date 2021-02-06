using Microsoft.EntityFrameworkCore.Migrations;

namespace BugBlaze.Data.Migrations
{
    public partial class CreatedBugSeverity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Severity",
                table: "Bugs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Severity",
                table: "Bugs");
        }
    }
}
