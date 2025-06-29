using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorIdToReserv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_DoctorId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_DoctorId",
                table: "Reservations",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_DoctorId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_DoctorId",
                table: "Reservations",
                column: "DoctorId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
