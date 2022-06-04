using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Context.Migrations
{
    public partial class BirthDatechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirdDate",
                schema: "Identity",
                table: "User",
                newName: "BirthDate");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 6, 4, 19, 9, 38, 922, DateTimeKind.Local).AddTicks(870));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 6, 4, 19, 9, 38, 922, DateTimeKind.Local).AddTicks(879));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 6, 4, 19, 9, 38, 922, DateTimeKind.Local).AddTicks(880));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 6, 4, 19, 9, 38, 922, DateTimeKind.Local).AddTicks(881));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                schema: "Identity",
                table: "User",
                newName: "BirdDate");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 6, 4, 14, 11, 2, 422, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2022, 6, 4, 14, 11, 2, 422, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2022, 6, 4, 14, 11, 2, 422, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2022, 6, 4, 14, 11, 2, 422, DateTimeKind.Local).AddTicks(5401));
        }
    }
}
