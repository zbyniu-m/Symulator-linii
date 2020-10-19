using Microsoft.EntityFrameworkCore.Migrations;

namespace SymulatroLinii.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbSerwers",
                columns: table => new
                {
                    Nazwa = table.Column<string>(nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Haslo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSerwers", x => x.Nazwa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbSerwers");
        }
    }
}
