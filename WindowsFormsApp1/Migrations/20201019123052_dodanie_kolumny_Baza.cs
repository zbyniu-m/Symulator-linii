using Microsoft.EntityFrameworkCore.Migrations;

namespace SymulatroLinii.Migrations
{
    public partial class dodanie_kolumny_Baza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Baza",
                table: "DbSerwers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Baza",
                table: "DbSerwers");
        }
    }
}
