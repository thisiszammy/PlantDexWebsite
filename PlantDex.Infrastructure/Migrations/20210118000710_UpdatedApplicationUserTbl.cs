using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantDex.Infrastructure.Migrations
{
    public partial class UpdatedApplicationUserTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdminApproved",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdminApproved",
                table: "AspNetUsers");
        }
    }
}
