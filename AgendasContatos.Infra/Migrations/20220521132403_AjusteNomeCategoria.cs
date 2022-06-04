using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendasContatos.Infra.Migrations
{
    public partial class AjusteNomeCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descricao",
                value: "Família");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descricao",
                value: "Familia");
        }
    }
}
