using Microsoft.EntityFrameworkCore.Migrations;

namespace BSETracker.Web.Migrations
{
    public partial class MakeEmailUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Registrations_Email",
                table: "Registrations",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registrations_Email",
                table: "Registrations");
        }
    }
}
