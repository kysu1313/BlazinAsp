using Microsoft.EntityFrameworkCore.Migrations;

namespace BugBlaze.Data.Migrations
{
    public partial class RenamedUserModelId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "AspNetUsers");
        }
    }
}
