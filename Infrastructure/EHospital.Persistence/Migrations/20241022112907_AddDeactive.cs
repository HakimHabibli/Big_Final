using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHospital.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDeactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 22, 11, 29, 5, 999, DateTimeKind.Utc).AddTicks(2744),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 21, 11, 29, 16, 97, DateTimeKind.Utc).AddTicks(4550));

            migrationBuilder.CreateIndex(
                name: "IX_UserDeactivatedSchedules_DoctorScheduleId",
                table: "UserDeactivatedSchedules",
                column: "DoctorScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDeactivatedSchedules_DoctorSchedules_DoctorScheduleId",
                table: "UserDeactivatedSchedules",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDeactivatedSchedules_DoctorSchedules_DoctorScheduleId",
                table: "UserDeactivatedSchedules");

            migrationBuilder.DropIndex(
                name: "IX_UserDeactivatedSchedules_DoctorScheduleId",
                table: "UserDeactivatedSchedules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 21, 11, 29, 16, 97, DateTimeKind.Utc).AddTicks(4550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 22, 11, 29, 5, 999, DateTimeKind.Utc).AddTicks(2744));
        }
    }
}
