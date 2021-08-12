using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.requests
{
    public partial class pp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Priorite",
                table: "requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priorite",
                table: "requests");
        }
    }
}
