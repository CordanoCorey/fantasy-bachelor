using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class Episode5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 1,
                column: "Finish",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 5,
                column: "Finish",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 14,
                column: "Finish",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 17,
                column: "Finish",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 25,
                column: "Finish",
                value: 11);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 26,
                column: "Finish",
                value: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 5,
                column: "Finish",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 14,
                column: "Finish",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 17,
                column: "Finish",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 25,
                column: "Finish",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 26,
                column: "Finish",
                value: null);
        }
    }
}
