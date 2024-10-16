using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHospital.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientPropertyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HospitalName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 14, 18, 59, 16, 387, DateTimeKind.Utc).AddTicks(7138),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 14, 9, 51, 27, 827, DateTimeKind.Utc).AddTicks(2549));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HospitalName",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 14, 9, 51, 27, 827, DateTimeKind.Utc).AddTicks(2549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 14, 18, 59, 16, 387, DateTimeKind.Utc).AddTicks(7138));
        }
    }
}
