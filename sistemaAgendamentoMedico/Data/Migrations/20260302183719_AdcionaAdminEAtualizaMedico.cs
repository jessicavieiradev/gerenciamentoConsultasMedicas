using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaAgendamentoMedico.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdcionaAdminEAtualizaMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_medico_crm",
                table: "medico");

            migrationBuilder.RenameColumn(
                name: "Especialidade",
                table: "medico",
                newName: "especialidade");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "medico",
                newName: "ativo");

            migrationBuilder.AlterColumn<string>(
                name: "crm",
                table: "medico",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "especialidade",
                table: "medico",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId",
                table: "medico",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "medico",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "uf",
                table: "medico",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmailCorporativo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admin_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medico_cpf",
                table: "medico",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medico_crm_uf",
                table: "medico",
                columns: new[] { "crm", "uf" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medico_UsuarioId",
                table: "medico",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_admin_UsuarioId",
                table: "admin",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_medico_AspNetUsers_UsuarioId",
                table: "medico",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medico_AspNetUsers_UsuarioId",
                table: "medico");

            migrationBuilder.DropTable(
                name: "admin");

            migrationBuilder.DropIndex(
                name: "IX_medico_cpf",
                table: "medico");

            migrationBuilder.DropIndex(
                name: "IX_medico_crm_uf",
                table: "medico");

            migrationBuilder.DropIndex(
                name: "IX_medico_UsuarioId",
                table: "medico");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "medico");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "medico");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "medico");

            migrationBuilder.RenameColumn(
                name: "especialidade",
                table: "medico",
                newName: "Especialidade");

            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "medico",
                newName: "Ativo");

            migrationBuilder.AlterColumn<string>(
                name: "Especialidade",
                table: "medico",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "crm",
                table: "medico",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.CreateIndex(
                name: "IX_medico_crm",
                table: "medico",
                column: "crm",
                unique: true);
        }
    }
}
