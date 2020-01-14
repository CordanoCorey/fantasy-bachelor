using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class contestant_finish_retry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finish",
                schema: "Common",
                table: "Contestant");

            migrationBuilder.AddColumn<int>(
                name: "Finish",
                schema: "Common",
                table: "ContestantSeason_xref",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 3,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 4,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 6,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 8,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 10,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 11,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 15,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 16,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 19,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 20,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "ContestantSeason_xref",
                keyColumn: "Id",
                keyValue: 23,
                column: "Finish",
                value: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finish",
                schema: "Common",
                table: "ContestantSeason_xref");

            migrationBuilder.AddColumn<int>(
                name: "Finish",
                schema: "Common",
                table: "Contestant",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 3,
                column: "Finish",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 4,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 6,
                column: "Finish",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 8,
                column: "Finish",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 10,
                column: "Finish",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 11,
                column: "Finish",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 15,
                column: "Finish",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 16,
                column: "Finish",
                value: 20);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 19,
                column: "Finish",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 20,
                column: "Finish",
                value: 23);

            migrationBuilder.UpdateData(
                schema: "Common",
                table: "Contestant",
                keyColumn: "Id",
                keyValue: 23,
                column: "Finish",
                value: 20);
        }
    }
}
