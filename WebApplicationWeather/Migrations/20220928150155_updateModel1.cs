using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationWeather.Migrations
{
    public partial class updateModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsNight",
                table: "Summaries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNight",
                table: "Summaries");
        }
    }
}
