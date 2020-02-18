using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class Episode8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 13,
                column: "Finish",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 13,
                column: "Finish",
                value: null);
        }
    }
}
