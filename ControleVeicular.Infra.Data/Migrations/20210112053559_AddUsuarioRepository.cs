using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleVeicular.Infra.Data.Migrations
{
    public partial class AddUsuarioRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_Marca_MarcaId",
                table: "Anuncio");

            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_Modelo_ModeloId",
                table: "Anuncio");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Login",
                table: "Usuario",
                column: "Login",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_Marca_MarcaId",
                table: "Anuncio",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_Modelo_ModeloId",
                table: "Anuncio",
                column: "ModeloId",
                principalTable: "Modelo",
                principalColumn: "ModeloId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_Marca_MarcaId",
                table: "Anuncio");

            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_Modelo_ModeloId",
                table: "Anuncio");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_Marca_MarcaId",
                table: "Anuncio",
                column: "MarcaId",
                principalTable: "Marca",
                principalColumn: "MarcaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_Modelo_ModeloId",
                table: "Anuncio",
                column: "ModeloId",
                principalTable: "Modelo",
                principalColumn: "ModeloId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
