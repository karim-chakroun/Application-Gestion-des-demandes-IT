using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "DateT",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameT",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Ticket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateT",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NameT",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
