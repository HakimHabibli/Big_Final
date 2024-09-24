using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHospital.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 22, 16, 1, 46, 822, DateTimeKind.Utc).AddTicks(7701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 1, 6, 26, 51, 348, DateTimeKind.Utc).AddTicks(3906));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DoctorSchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DoctorSchedules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 1, 6, 26, 51, 348, DateTimeKind.Utc).AddTicks(3906),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 22, 16, 1, 46, 822, DateTimeKind.Utc).AddTicks(7701));
        }
    }
}
