using Microsoft.EntityFrameworkCore.Migrations;

namespace BugBlaze.Data.Migrations
{
    public partial class AddingColumnsToIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_OnTeamId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OnTeamId",
                table: "AspNetUsers",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_OnTeamId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "AspNetUsers",
                newName: "OnTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TeamId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_OnTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_OnTeamId",
                table: "AspNetUsers",
                column: "OnTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
