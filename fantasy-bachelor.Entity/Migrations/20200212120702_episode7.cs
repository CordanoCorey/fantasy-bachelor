using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class episode7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 12,
                column: "Finish",
                value: 7);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 22,
                column: "Finish",
                value: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 12,
                column: "Finish",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 22,
                column: "Finish",
                value: null);
        }
    }
}
