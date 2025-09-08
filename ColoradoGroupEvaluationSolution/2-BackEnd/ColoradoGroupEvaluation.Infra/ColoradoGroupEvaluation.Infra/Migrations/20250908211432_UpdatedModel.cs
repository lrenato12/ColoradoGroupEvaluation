using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColoradoGroupEvaluation.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_TiposTelefone_TipoTelefoneCodigoTipoTelefone",
                table: "Telefones");

            migrationBuilder.AlterColumn<int>(
                name: "TipoTelefoneCodigoTipoTelefone",
                table: "Telefones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_TiposTelefone_TipoTelefoneCodigoTipoTelefone",
                table: "Telefones",
                column: "TipoTelefoneCodigoTipoTelefone",
                principalTable: "TiposTelefone",
                principalColumn: "CodigoTipoTelefone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_TiposTelefone_TipoTelefoneCodigoTipoTelefone",
                table: "Telefones");

            migrationBuilder.AlterColumn<int>(
                name: "TipoTelefoneCodigoTipoTelefone",
                table: "Telefones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_TiposTelefone_TipoTelefoneCodigoTipoTelefone",
                table: "Telefones",
                column: "TipoTelefoneCodigoTipoTelefone",
                principalTable: "TiposTelefone",
                principalColumn: "CodigoTipoTelefone",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
