using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationWeather.Migrations
{
    public partial class RelationUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeatherDailyId",
                table: "WeatherHourlies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "WeatherDailies",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Summaries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PicPath",
                table: "Summaries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherHourlies_WeatherDailyId",
                table: "WeatherHourlies",
                column: "WeatherDailyId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherHourlies_WeatherDailies_WeatherDailyId",
                table: "WeatherHourlies",
                column: "WeatherDailyId",
                principalTable: "WeatherDailies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherHourlies_WeatherDailies_WeatherDailyId",
                table: "WeatherHourlies");

            migrationBuilder.DropIndex(
                name: "IX_WeatherHourlies_WeatherDailyId",
                table: "WeatherHourlies");

            migrationBuilder.DropColumn(
                name: "WeatherDailyId",
                table: "WeatherHourlies");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "WeatherDailies",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Summaries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PicPath",
                table: "Summaries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
