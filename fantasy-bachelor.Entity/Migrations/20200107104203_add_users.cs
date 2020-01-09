using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class add_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "andreamariko1k@yahoo.com", "andreamariko1k@yahoo.com", "andreamariko1k@yahoo.com", "andreamariko1k@yahoo.com" });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 22, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "felecia.williamson@gmail.com", false, "Felecia", "Williamson", false, null, "felecia.williamson@gmail.com", "felecia.williamson@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "felecia.williamson@gmail.com" },
                    { 23, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "mxr8@pct.edu", false, "Michalya", "Roberts", false, null, "mxr8@pct.edu", "mxr8@pct.edu", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "mxr8@pct.edu" },
                    { 24, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "cnkford18@yahoo.com", false, "Chad", "Kendrick", false, null, "cnkford18@yahoo.com", "cnkford18@yahoo.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "cnkford18@yahoo.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "adreamarikolk@yahoo.com", "adreamarikolk@yahoo.com", "adreamarikolk@yahoo.com", "adreamarikolk@yahoo.com" });
        }
    }
}
