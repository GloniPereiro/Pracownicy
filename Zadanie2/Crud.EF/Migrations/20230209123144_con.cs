using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.EF.Migrations
{
    /// <inheritdoc />
    public partial class con : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListaPracownikowIdPracownika",
                table: "ListaZadan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pracownik",
                table: "ListaZadan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ListaZadan_ListaPracownikowIdPracownika",
                table: "ListaZadan",
                column: "ListaPracownikowIdPracownika");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaZadan_ListaPracownikow_ListaPracownikowIdPracownika",
                table: "ListaZadan",
                column: "ListaPracownikowIdPracownika",
                principalTable: "ListaPracownikow",
                principalColumn: "IdPracownika",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaZadan_ListaPracownikow_ListaPracownikowIdPracownika",
                table: "ListaZadan");

            migrationBuilder.DropIndex(
                name: "IX_ListaZadan_ListaPracownikowIdPracownika",
                table: "ListaZadan");

            migrationBuilder.DropColumn(
                name: "ListaPracownikowIdPracownika",
                table: "ListaZadan");

            migrationBuilder.DropColumn(
                name: "Pracownik",
                table: "ListaZadan");
        }
    }
}
