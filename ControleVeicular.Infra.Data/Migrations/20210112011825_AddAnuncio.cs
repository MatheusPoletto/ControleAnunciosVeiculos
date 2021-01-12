using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVeicular.Infra.Data.Migrations
{
    public partial class AddAnuncio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anuncio",
                columns: table => new
                {
                    AnuncioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ValorCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoCombustivel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.AnuncioId);
                    table.ForeignKey(
                        name: "FK_Anuncio_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "MarcaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anuncio_Modelo_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelo",
                        principalColumn: "ModeloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_MarcaId",
                table: "Anuncio",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_ModeloId",
                table: "Anuncio",
                column: "ModeloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anuncio");
        }
    }
}
