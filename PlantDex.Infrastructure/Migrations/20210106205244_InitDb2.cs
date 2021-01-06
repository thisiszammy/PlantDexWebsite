using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantDex.Infrastructure.Migrations
{
    public partial class InitDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_plants",
                table: "plants");

            migrationBuilder.DropColumn(
                name: "_Id",
                table: "plants");

            migrationBuilder.RenameTable(
                name: "plants",
                newName: "Plants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plants",
                table: "Plants",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Plants",
                table: "Plants");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "plants");

            migrationBuilder.AddColumn<string>(
                name: "_Id",
                table: "plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_plants",
                table: "plants",
                column: "Id");
        }
    }
}
