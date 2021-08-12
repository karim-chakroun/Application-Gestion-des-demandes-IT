using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations.requests
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "requests",
                columns: table => new
                {
                    RequestsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameT = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DateT = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    customer = table.Column<string>(nullable: true),
                    Agent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.RequestsId);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    commentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    RequestsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.commentId);
                    table.ForeignKey(
                        name: "FK_comments_requests_RequestsId",
                        column: x => x.RequestsId,
                        principalTable: "requests",
                        principalColumn: "RequestsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_RequestsId",
                table: "comments",
                column: "RequestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "requests");
        }
    }
}
