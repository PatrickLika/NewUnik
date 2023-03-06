using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unik.SqlServerContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Virker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opgave_Medarbejder_MedarbejderId",
                schema: "opgave",
                table: "Opgave");

            migrationBuilder.DropIndex(
                name: "IX_Opgave_MedarbejderId",
                schema: "opgave",
                table: "Opgave");

            migrationBuilder.DropColumn(
                name: "MedarbejderId",
                schema: "opgave",
                table: "Opgave");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedarbejderId",
                schema: "opgave",
                table: "Opgave",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opgave_MedarbejderId",
                schema: "opgave",
                table: "Opgave",
                column: "MedarbejderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opgave_Medarbejder_MedarbejderId",
                schema: "opgave",
                table: "Opgave",
                column: "MedarbejderId",
                principalSchema: "medarbejder",
                principalTable: "Medarbejder",
                principalColumn: "Id");
        }
    }
}
