using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.requests
{
    public partial class notif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    notifId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.notifId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notification");
        }
    }
}
