using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoGroupEvaluation.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_TiposTelefone_TipoTelefoneCodigoTipoTelefone",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_TipoTelefoneCodigoTipoTelefone",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "TipoTelefoneCodigoTipoTelefone",
                table: "Telefones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoTelefoneCodigoTipoTelefone",
                table: "Telefones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_TipoTelefoneCodigoTipoTelefone",
                table: "Telefones",
                column: "TipoTelefoneCodigoTipoTelefone");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_TiposTelefone_TipoTelefoneCodigoTipoTelefone",
                table: "Telefones",
                column: "TipoTelefoneCodigoTipoTelefone",
                principalTable: "TiposTelefone",
                principalColumn: "CodigoTipoTelefone");
        }
    }
}
