using Microsoft.EntityFrameworkCore.Migrations;

namespace BugBlaze.Data.Migrations
{
    public partial class AddedResolvedToBugClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Resolved",
                table: "Bugs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resolved",
                table: "Bugs");
        }
    }
}
