using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persona.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<string>(nullable: false),
                    Documento = table.Column<long>(maxLength: 11, nullable: false),
                    TipoDocumento = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaID);
                });

            migrationBuilder.CreateTable(
                name: "PersonasDetalles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonaID = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 300, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasDetalles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonasDetalles_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "PersonaID", "Apellidos", "Documento", "FechaNacimiento", "Nombres", "TipoDocumento" },
                values: new object[,]
                {
                    { 1, "Saavedra Castro 1", 15957844L, "13/06/1981", "Marco Antonio 1", "DNI" },
                    { 2, "Saavedra Castro 2", 25957844L, "13/06/1982", "Marco Antonio 2", "DNI" },
                    { 3, "Saavedra Castro 3", 35957844L, "13/06/1983", "Marco Antonio 3", "DNI" },
                    { 4, "Saavedra Castro 4", 45957844L, "13/06/1984", "Marco Antonio 4", "DNI" }
                });

            migrationBuilder.InsertData(
                table: "PersonasDetalles",
                columns: new[] { "ID", "Direccion", "Email", "PersonaID", "Telefono" },
                values: new object[,]
                {
                    { 1, "Santa Anita numero 1", "msaavedra.1@gmail.com", 1, "+51998989333" },
                    { 2, "Santa Anita numero 2", "msaavedra.2@gmail.com", 2, "+52998989333" },
                    { 3, "Santa Anita numero 3", "msaavedra.3@gmail.com", 3, "+53998989333" },
                    { 4, "Santa Anita numero 4", "msaavedra.4@gmail.com", 4, "+54998989333" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonasDetalles_PersonaID",
                table: "PersonasDetalles",
                column: "PersonaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonasDetalles");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
