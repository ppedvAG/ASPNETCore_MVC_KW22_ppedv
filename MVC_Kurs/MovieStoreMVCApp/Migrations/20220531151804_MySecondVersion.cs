using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStoreMVCApp.Migrations
{
    public partial class MySecondVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IMDBRating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMDBRating",
                table: "Movies");
        }
    }
}
