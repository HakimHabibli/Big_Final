using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHospital.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 11, 29, 16, 97, DateTimeKind.Utc).AddTicks(4550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 19, 18, 33, 50, 705, DateTimeKind.Utc).AddTicks(9333));

            migrationBuilder.CreateTable(
                name: "UserDeactivatedSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DoctorScheduleId = table.Column<int>(type: "int", nullable: false),
                    DeactivatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeactivatedSchedules", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDeactivatedSchedules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 19, 18, 33, 50, 705, DateTimeKind.Utc).AddTicks(9333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 11, 29, 16, 97, DateTimeKind.Utc).AddTicks(4550));
        }
    }
}
