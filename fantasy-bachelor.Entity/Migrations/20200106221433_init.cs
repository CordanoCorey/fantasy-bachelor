using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    PasswordResetCode = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contestant",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(maxLength: 1000, nullable: true),
                    Hometown = table.Column<string>(maxLength: 100, nullable: true),
                    Profession = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contestant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeasonType",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                schema: "Auth",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.ProviderKey, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Auth",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "Auth",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.Value, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunFact",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<int>(maxLength: 1000, nullable: false),
                    ContestantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunFact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FunFact_Contestant",
                        column: x => x.ContestantId,
                        principalSchema: "Common",
                        principalTable: "Contestant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    SeasonTypeId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Season_SeasonType",
                        column: x => x.SeasonTypeId,
                        principalSchema: "Lookup",
                        principalTable: "SeasonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestantSeason_xref",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContestantId = table.Column<int>(nullable: false),
                    SeasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestantSeason_xref", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContestantSeason_Contestant",
                        column: x => x.ContestantId,
                        principalSchema: "Common",
                        principalTable: "Contestant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestantSeason_Season",
                        column: x => x.SeasonId,
                        principalSchema: "Lookup",
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContestantSeasonId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    Rank = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranking_ContestantSeason",
                        column: x => x.ContestantSeasonId,
                        principalSchema: "Common",
                        principalTable: "ContestantSeason_xref",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranking_User",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "f605120f-716d-40c3-9dbd-8ff473410823", "gelbaughcm@gmail.com", false, "System", "Administrator", false, null, "gelbaughcm@gmail.com", "gelbaughcm@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "dfafd561-8cef-40ad-8c7a-339dc67529d0", false, "gelbaughcm@gmail.com" },
                    { 20, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "t_bear25@icloud.com", false, "Tyler", "Bear", false, null, "t_bear25@icloud.com", "t_bear25@icloud.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "t_bear25@icloud.com" },
                    { 19, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "rkbrent1111@gmail.com", false, "Katelin", "Brent", false, null, "rkbrent1111@gmail.com", "rkbrent1111@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "rkbrent1111@gmail.com" },
                    { 17, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "kylie.mcmahan@gmail.com", false, "Kylie", "McMahan", false, null, "kylie.mcmahan@gmail.com", "kylie.mcmahan@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "kylie.mcmahan@gmail.com" },
                    { 16, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "lydiaphelan1@gmail.com", false, "Lydia", "", false, null, "lydiaphelan1@gmail.com", "lydiaphelan1@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "lydiaphelan1@gmail.com" },
                    { 15, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "mw681275@sju.edu", false, "Maddie", "Wargins", false, null, "mw681275@sju.edu", "mw681275@sju.edu", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "mw681275@sju.edu" },
                    { 14, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "er1293@messiah.edu", false, "Emily", "Reisinger", false, null, "er1293@messiah.edu", "er1293@messiah.edu", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "er1293@messiah.edu" },
                    { 13, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "kabrent51@gmail.com", false, "Kelly", "Brent", false, null, "kabrent51@gmail.com", "kabrent51@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "kabrent51@gmail.com" },
                    { 12, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "kwoy1508@yahoo.com", false, "Kyleigh", "Woy", false, null, "kwoy1508@yahoo.com", "kwoy1508@yahoo.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "kwoy1508@yahoo.com" },
                    { 11, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "ceschenman19@gmail.com", false, "Cara", "Eschenmann", false, null, "ceschenman19@gmail.com", "ceschenman19@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "ceschenman19@gmail.com" },
                    { 18, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "keirakapner03@gmail.com", false, "Keira", "Kapner", false, null, "keirakapner03@gmail.com", "keirakapner03@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "keirakapner03@gmail.com" },
                    { 9, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "jeffs99285@gmail.com", false, "Jeff", "", false, null, "jeffs99285@gmail.com", "jeffs99285@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "jeffs99285@gmail.com" },
                    { 8, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "janmcmahan@gmail.com", false, "Jan", "", false, null, "janmcmahan@gmail.com", "janmcmahan@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "janmcmahan@gmail.com" },
                    { 7, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "skyelee91@icloud.com", false, "Skye", "", false, null, "skyelee91@icloud.com", "skyelee91@icloud.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "skyelee91@icloud.com" },
                    { 6, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "adreamarikolk@yahoo.com", false, "Andrea", "", false, null, "adreamarikolk@yahoo.com", "adreamarikolk@yahoo.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "adreamarikolk@yahoo.com" },
                    { 5, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "maryzell4@gmail.com", false, "Mary", "Zell", false, null, "maryzell4@gmail.com", "maryzell4@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "maryzell4@gmail.com" },
                    { 4, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "es2531@gmail.com", false, "Evan", "Simon", false, null, "es2531@gmail.com", "es2531@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "es2531@gmail.com" },
                    { 3, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "jbrent21@gmail.com", false, "Julie", "Gelbaugh", false, null, "jbrent21@gmail.com", "jbrent21@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "jbrent21@gmail.com" },
                    { 2, 0, "f605120f-716d-40c3-9dbd-8ff473410823", "corey@cordanosports.com", false, "Corey", "Gelbaugh", false, null, "corey@cordanosports.com", "corey@cordanosports.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "dfafd561-8cef-40ad-8c7a-339dc67529d0", false, "corey@cordanosports.com" },
                    { 10, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "deschenmann@gmail.com", false, "Denise", "Eschenmann", false, null, "deschenmann@gmail.com", "deschenmann@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "deschenmann@gmail.com" }
                });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "Contestant",
                columns: new[] { "Id", "Age", "Bio", "Hometown", "Name", "Profession" },
                values: new object[,]
                {
                    { 18, 23, "", "", "Madison", "" },
                    { 19, 23, "", "", "Maurissa", "" },
                    { 20, 26, "", "", "Megan", "" },
                    { 21, 22, "", "", "Mykenna", "" },
                    { 22, 31, "", "", "Natasha", "" },
                    { 23, 23, "", "", "Payton", "" },
                    { 28, 24, "", "", "Tammy", "" },
                    { 25, 27, "", "", "Savannah", "" },
                    { 26, 27, "", "", "Shiann", "" },
                    { 27, 24, "", "", "Sydney", "" },
                    { 29, 25, "", "", "Victoria F.", "" },
                    { 30, 27, "", "", "Victoria P.", "" },
                    { 17, 26, "", "", "Lexi", "" },
                    { 24, 24, "", "", "Sarah", "" },
                    { 16, 26, "", "", "Lauren", "" },
                    { 7, 23, "", "", "Hannah Ann", "" },
                    { 14, 23, "", "", "Kiarra", "" },
                    { 1, 24, "", "", "Alayah", "" },
                    { 2, 27, "", "", "Alexa", "" },
                    { 3, 27, "", "", "Avonlea", "" },
                    { 4, 26, "", "", "Courtney", "" },
                    { 5, 23, "", "", "Deandra", "" },
                    { 15, 25, "", "", "Kylie", "" },
                    { 6, 23, "", "", "Eunice", "" },
                    { 8, 26, "", "", "Jade", "" },
                    { 9, 25, "", "", "Jasmine", "" },
                    { 10, 22, "", "", "Jenna", "" },
                    { 11, 28, "", "", "Katrina", "" },
                    { 12, 28, "", "", "Kelley", "" },
                    { 13, 28, "", "", "Kelsey", "" }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "SeasonType",
                columns: new[] { "Id", "IsActive", "Name", "Sort" },
                values: new object[,]
                {
                    { 1, true, "Bachelor", 1 },
                    { 2, true, "Bachelorette", 2 },
                    { 3, true, "Bachelor Pad", 3 }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "Season",
                columns: new[] { "Id", "EndDate", "IsActive", "Name", "SeasonTypeId", "Sort", "StartDate" },
                values: new object[] { 1, new DateTime(2020, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Season 24", 1, 1, new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                schema: "Common",
                table: "ContestantSeason_xref",
                columns: new[] { "Id", "ContestantId", "SeasonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 28, 28, 1 },
                    { 27, 27, 1 },
                    { 26, 26, 1 },
                    { 25, 25, 1 },
                    { 24, 24, 1 },
                    { 23, 23, 1 },
                    { 22, 22, 1 },
                    { 21, 21, 1 },
                    { 20, 20, 1 },
                    { 19, 19, 1 },
                    { 18, 18, 1 },
                    { 17, 17, 1 },
                    { 16, 16, 1 },
                    { 15, 15, 1 },
                    { 14, 14, 1 },
                    { 13, 13, 1 },
                    { 12, 12, 1 },
                    { 11, 11, 1 },
                    { 10, 10, 1 },
                    { 9, 9, 1 },
                    { 8, 8, 1 },
                    { 7, 7, 1 },
                    { 6, 6, 1 },
                    { 5, 5, 1 },
                    { 4, 4, 1 },
                    { 3, 3, 1 },
                    { 2, 2, 1 },
                    { 29, 29, 1 },
                    { 30, 30, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Auth",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                schema: "Auth",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Auth",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Auth",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "Auth",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                schema: "Auth",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "Auth",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestantSeason_xref_ContestantId",
                schema: "Common",
                table: "ContestantSeason_xref",
                column: "ContestantId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestantSeason_xref_SeasonId",
                schema: "Common",
                table: "ContestantSeason_xref",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_FunFact_ContestantId",
                schema: "Common",
                table: "FunFact",
                column: "ContestantId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_ContestantSeasonId",
                schema: "Common",
                table: "Ranking",
                column: "ContestantSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_UserId",
                schema: "Common",
                table: "Ranking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_SeasonTypeId",
                schema: "Lookup",
                table: "Season",
                column: "SeasonTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaim",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserLogin",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "FunFact",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Ranking",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "ContestantSeason_xref",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Contestant",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Season",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "SeasonType",
                schema: "Lookup");
        }
    }
}
