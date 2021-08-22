using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.requests
{
    public partial class Email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "uEmail",
                table: "requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uEmail",
                table: "requests");
        }
    }
}
