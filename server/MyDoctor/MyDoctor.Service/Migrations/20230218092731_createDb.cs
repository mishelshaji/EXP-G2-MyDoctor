using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDoctor.Service.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDateTime",
                table: "Appointments",
                newName: "ToTime");

            migrationBuilder.RenameColumn(
                name: "FromDateTime",
                table: "Appointments",
                newName: "FromTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "ToTime",
                table: "Appointments",
                newName: "ToDateTime");

            migrationBuilder.RenameColumn(
                name: "FromTime",
                table: "Appointments",
                newName: "FromDateTime");
        }
    }
}
