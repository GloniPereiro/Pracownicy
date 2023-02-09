using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.EF.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaPracownikow",
                columns: table => new
                {
                    IdPracownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NiezakonczoneZadania = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPracownikow", x => x.IdPracownika);
                });

            migrationBuilder.CreateTable(
                name: "ListaZadan",
                columns: table => new
                {
                    IdZadania = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriaZadania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpisZadania = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaZadan", x => x.IdZadania);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaPracownikow");

            migrationBuilder.DropTable(
                name: "ListaZadan");
        }
    }
}
