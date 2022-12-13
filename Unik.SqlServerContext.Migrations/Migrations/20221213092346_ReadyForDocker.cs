using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unik.SqlServerContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ReadyForDocker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "booking");

            migrationBuilder.EnsureSchema(
                name: "kompetence");

            migrationBuilder.EnsureSchema(
                name: "kunde");

            migrationBuilder.EnsureSchema(
                name: "medarbejder");

            migrationBuilder.EnsureSchema(
                name: "opgave");

            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "Kompetence",
                schema: "kompetence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompetence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kunde",
                schema: "kunde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VirksomhedNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tlf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunde", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medarbejder",
                schema: "medarbejder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tlf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medarbejder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                schema: "sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tlf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                schema: "booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpgaveId = table.Column<int>(type: "int", nullable: false),
                    MedarbejderId = table.Column<int>(type: "int", nullable: false),
                    StartDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    MedarbejderEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Medarbejder_MedarbejderEntityId",
                        column: x => x.MedarbejderEntityId,
                        principalSchema: "medarbejder",
                        principalTable: "Medarbejder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KompetenceEntityMedarbejderEntity",
                columns: table => new
                {
                    KompetenceListeId = table.Column<int>(type: "int", nullable: false),
                    MedarbejderListeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KompetenceEntityMedarbejderEntity", x => new { x.KompetenceListeId, x.MedarbejderListeId });
                    table.ForeignKey(
                        name: "FK_KompetenceEntityMedarbejderEntity_Kompetence_KompetenceListeId",
                        column: x => x.KompetenceListeId,
                        principalSchema: "kompetence",
                        principalTable: "Kompetence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KompetenceEntityMedarbejderEntity_Medarbejder_MedarbejderListeId",
                        column: x => x.MedarbejderListeId,
                        principalSchema: "medarbejder",
                        principalTable: "Medarbejder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjektEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Noter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AntalBoliger = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    KundeId = table.Column<int>(type: "int", nullable: false),
                    SalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjektEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjektEntities_Kunde_KundeId",
                        column: x => x.KundeId,
                        principalSchema: "kunde",
                        principalTable: "Kunde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjektEntities_Sales_SalesId",
                        column: x => x.SalesId,
                        principalSchema: "sales",
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opgave",
                schema: "opgave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ProjektId = table.Column<int>(type: "int", nullable: false),
                    MedarbejderId = table.Column<int>(type: "int", nullable: true),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    Varighed = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opgave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opgave_Booking_BookingId",
                        column: x => x.BookingId,
                        principalSchema: "booking",
                        principalTable: "Booking",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opgave_Medarbejder_MedarbejderId",
                        column: x => x.MedarbejderId,
                        principalSchema: "medarbejder",
                        principalTable: "Medarbejder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opgave_ProjektEntities_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "ProjektEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MedarbejderEntityId",
                schema: "booking",
                table: "Booking",
                column: "MedarbejderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_KompetenceEntityMedarbejderEntity_MedarbejderListeId",
                table: "KompetenceEntityMedarbejderEntity",
                column: "MedarbejderListeId");

            migrationBuilder.CreateIndex(
                name: "IX_Opgave_BookingId",
                schema: "opgave",
                table: "Opgave",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Opgave_MedarbejderId",
                schema: "opgave",
                table: "Opgave",
                column: "MedarbejderId");

            migrationBuilder.CreateIndex(
                name: "IX_Opgave_ProjektId",
                schema: "opgave",
                table: "Opgave",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjektEntities_KundeId",
                table: "ProjektEntities",
                column: "KundeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjektEntities_SalesId",
                table: "ProjektEntities",
                column: "SalesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KompetenceEntityMedarbejderEntity");

            migrationBuilder.DropTable(
                name: "Opgave",
                schema: "opgave");

            migrationBuilder.DropTable(
                name: "Kompetence",
                schema: "kompetence");

            migrationBuilder.DropTable(
                name: "Booking",
                schema: "booking");

            migrationBuilder.DropTable(
                name: "ProjektEntities");

            migrationBuilder.DropTable(
                name: "Medarbejder",
                schema: "medarbejder");

            migrationBuilder.DropTable(
                name: "Kunde",
                schema: "kunde");

            migrationBuilder.DropTable(
                name: "Sales",
                schema: "sales");
        }
    }
}
