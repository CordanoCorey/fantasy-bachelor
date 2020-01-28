using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class episode_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 1,
                column: "Finish",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 2,
                column: "Finish",
                value: 17);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 9,
                column: "Finish",
                value: 17);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 24,
                column: "Finish",
                value: 17);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 1,
                column: "Finish",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 2,
                column: "Finish",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 9,
                column: "Finish",
                value: 16);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 24,
                column: "Finish",
                value: 16);
        }
    }
}
