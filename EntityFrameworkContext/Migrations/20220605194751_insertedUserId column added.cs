using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Context.Migrations
{
    public partial class insertedUserIdcolumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "UserCources",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "UserCources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "Cources",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "Cources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedUserId", "DateCreated" },
                values: new object[] { "f7882daa-fe0c-4fd1-9656-c2e9426c5fda", new DateTime(2022, 6, 5, 22, 47, 51, 126, DateTimeKind.Local).AddTicks(9838) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedUserId", "DateCreated" },
                values: new object[] { "f7882daa-fe0c-4fd1-9656-c2e9426c5fda", new DateTime(2022, 6, 5, 22, 47, 51, 126, DateTimeKind.Local).AddTicks(9856) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedUserId", "DateCreated" },
                values: new object[] { "f7882daa-fe0c-4fd1-9656-c2e9426c5fda", new DateTime(2022, 6, 5, 22, 47, 51, 126, DateTimeKind.Local).AddTicks(9859) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedUserId", "DateCreated" },
                values: new object[] { "f7882daa-fe0c-4fd1-9656-c2e9426c5fda", new DateTime(2022, 6, 5, 22, 47, 51, 126, DateTimeKind.Local).AddTicks(9860) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "UserCources");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                schema: "dbo",
                table: "Cources");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "UserCources",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedUserId",
                schema: "dbo",
                table: "Cources",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedUserId", "DateCreated" },
                values: new object[] { new Guid("f7882daa-fe0c-4fd1-9656-c2e9426c5fda"), new DateTime(2022, 6, 4, 19, 9, 38, 922, DateTimeKind.Local).AddTicks(870) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedUserId", "DateCreated" },
                values: new object[] { new Guid("f7882daa-fe0c-4fd1-9656-c2e9426c5fda"), new DateTime(2022, 6, 4, 19, 9, 38, 922, DateTimeKind.Local).AddTicks(879) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedUserId", "DateCreated" },
                values: new object[] { new Guid("f7882daa-fe0c-4fd1-9656-c2e9426c5fda"), new DateTime(2022, 6, 4, 19, 9, 38, 922, DateTimeKind.Local).AddTicks(880) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Cources",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedUserId", "DateCreated" },
                values: new object[] { new Guid("f7882daa-fe0c-4fd1-9656-c2e9426c5fda"), new DateTime(2022, 6, 4, 19, 9, 38, 922, DateTimeKind.Local).AddTicks(881) });
        }
    }
}
