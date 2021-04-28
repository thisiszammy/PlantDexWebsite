using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantDex.Infrastructure.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<byte[]>(
                name: "SubmittedImage",
                table: "ContributionSubmissions",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittedImage",
                table: "ContributionSubmissions");
        }
    }
}
