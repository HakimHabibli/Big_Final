using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHospital.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHospitalImagePropery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 12, 14, 3, 44, 740, DateTimeKind.Utc).AddTicks(924),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 12, 13, 24, 0, 666, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Hospitals");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 12, 13, 24, 0, 666, DateTimeKind.Utc).AddTicks(5798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 12, 14, 3, 44, 740, DateTimeKind.Utc).AddTicks(924));
        }
    }
}
