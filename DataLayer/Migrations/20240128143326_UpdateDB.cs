using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Attendances_AttendanceId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Performances_PerformanceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AttendanceId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PerformanceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PerformanceId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_UserId",
                table: "Performances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_UserId",
                table: "Attendances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Users_UserId",
                table: "Attendances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Users_UserId",
                table: "Performances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Users_UserId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Users_UserId",
                table: "Performances");

            migrationBuilder.DropIndex(
                name: "IX_Performances_UserId",
                table: "Performances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_UserId",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PerformanceId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AttendanceId",
                table: "Users",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PerformanceId",
                table: "Users",
                column: "PerformanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Attendances_AttendanceId",
                table: "Users",
                column: "AttendanceId",
                principalTable: "Attendances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Performances_PerformanceId",
                table: "Users",
                column: "PerformanceId",
                principalTable: "Performances",
                principalColumn: "Id");
        }
    }
}
