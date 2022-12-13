using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unik.SqlServerContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Med : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Medarbejder_MedarbejderEntityId",
                schema: "booking",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_MedarbejderEntityId",
                schema: "booking",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "MedarbejderEntityId",
                schema: "booking",
                table: "Booking");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MedarbejderId",
                schema: "booking",
                table: "Booking",
                column: "MedarbejderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Medarbejder_MedarbejderId",
                schema: "booking",
                table: "Booking",
                column: "MedarbejderId",
                principalSchema: "medarbejder",
                principalTable: "Medarbejder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Medarbejder_MedarbejderId",
                schema: "booking",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_MedarbejderId",
                schema: "booking",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "MedarbejderEntityId",
                schema: "booking",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MedarbejderEntityId",
                schema: "booking",
                table: "Booking",
                column: "MedarbejderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Medarbejder_MedarbejderEntityId",
                schema: "booking",
                table: "Booking",
                column: "MedarbejderEntityId",
                principalSchema: "medarbejder",
                principalTable: "Medarbejder",
                principalColumn: "Id");
        }
    }
}
