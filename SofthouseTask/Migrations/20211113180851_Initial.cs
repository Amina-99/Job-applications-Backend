using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SofthouseTask.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CV = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { 1, new byte[] { 58, 147, 144, 210, 218, 84, 12, 90, 202, 41, 1, 75, 175, 220, 71, 107, 132, 163, 212, 5, 93, 176, 130, 40, 161, 136, 135, 16, 96, 149, 222, 130, 99, 178, 85, 94, 209, 143, 146, 25, 60, 229, 131, 160, 57, 156, 6, 143, 129, 202, 129, 86, 206, 175, 131, 242, 246, 165, 3, 128, 254, 89, 94, 151 }, new byte[] { 17, 115, 156, 231, 78, 228, 249, 112, 193, 183, 1, 147, 16, 202, 221, 169, 233, 182, 253, 211, 241, 156, 175, 173, 250, 32, 86, 135, 234, 223, 44, 206, 142, 157, 193, 76, 238, 161, 214, 232, 39, 183, 122, 123, 42, 243, 172, 99, 6, 153, 38, 205, 235, 105, 74, 19, 90, 7, 98, 193, 243, 151, 77, 77, 118, 171, 123, 134, 87, 166, 39, 226, 145, 88, 41, 87, 168, 248, 8, 162, 31, 183, 63, 172, 16, 129, 120, 77, 227, 125, 35, 116, 146, 140, 200, 221, 204, 202, 237, 212, 66, 110, 243, 254, 253, 19, 31, 238, 87, 92, 237, 91, 232, 47, 65, 28, 53, 130, 35, 119, 190, 17, 96, 74, 161, 173, 137, 26 }, "HrAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
