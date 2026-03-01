using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaAgendamentoMedico.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UsuarioId",
                table: "paciente",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_paciente_UsuarioId",
                table: "paciente",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_paciente_AspNetUsers_UsuarioId",
                table: "paciente",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paciente_AspNetUsers_UsuarioId",
                table: "paciente");

            migrationBuilder.DropIndex(
                name: "IX_paciente_UsuarioId",
                table: "paciente");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "paciente");
        }
    }
}
