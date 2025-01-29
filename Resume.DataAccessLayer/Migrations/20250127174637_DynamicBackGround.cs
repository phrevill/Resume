using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class DynamicBackGround : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImageName",
                table: "AboutMe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BackgroundImageName", "CreateDate" },
                values: new object[] { "", new DateTime(2025, 1, 27, 21, 16, 26, 779, DateTimeKind.Local).AddTicks(2321) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 27, 21, 16, 26, 779, DateTimeKind.Local).AddTicks(2124));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImageName",
                table: "AboutMe");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 27, 13, 45, 31, 980, DateTimeKind.Local).AddTicks(2769));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 27, 13, 45, 31, 980, DateTimeKind.Local).AddTicks(2550));
        }
    }
}
