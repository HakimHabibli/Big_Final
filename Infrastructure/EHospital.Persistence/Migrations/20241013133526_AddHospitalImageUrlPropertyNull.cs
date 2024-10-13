using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHospital.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHospitalImageUrlPropertyNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 13, 13, 35, 24, 614, DateTimeKind.Utc).AddTicks(6413),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 12, 14, 6, 2, 611, DateTimeKind.Utc).AddTicks(1282));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 12, 14, 6, 2, 611, DateTimeKind.Utc).AddTicks(1282),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 13, 13, 35, 24, 614, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
