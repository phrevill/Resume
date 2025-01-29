using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateOnly(2025, 1, 28), new DateTime(2025, 1, 28, 19, 5, 42, 519, DateTimeKind.Local).AddTicks(5111) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 28, 19, 5, 42, 519, DateTimeKind.Local).AddTicks(4930));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateOnly(2025, 1, 27), new DateTime(2025, 1, 27, 21, 16, 26, 779, DateTimeKind.Local).AddTicks(2321) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 27, 21, 16, 26, 779, DateTimeKind.Local).AddTicks(2124));
        }
    }
}
