using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.Infra.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    RazaoSocial = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeFantasia = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FlgStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TelefoneTipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FlgStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneTipos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioPerfis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FlgStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfis", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioPerfilAcessos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioPerfilId = table.Column<Guid>(type: "uuid(36)", nullable: true, collation: "ascii_general_ci"),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FlgStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfilAcessos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfilAcessos_UsuarioPerfis_UsuarioPerfilId",
                        column: x => x.UsuarioPerfilId,
                        principalTable: "UsuarioPerfis",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    EmpresaId = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioPerfilId = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    Login = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Documento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VerificaIP = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ListaIps = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VerificaMacAddress = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MacAddress = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataUltimoAcesso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUltimaTrocaSenha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    QuantidadeTentativasLogin = table.Column<int>(type: "int", nullable: false),
                    TrocarSenha = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UsuarioTrocaSenhaId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FlgStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_UsuarioPerfis_UsuarioPerfilId",
                        column: x => x.UsuarioPerfilId,
                        principalTable: "UsuarioPerfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioTelefones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    Numero = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    TelefoneTipoId = table.Column<Guid>(type: "uuid(36)", nullable: false, collation: "ascii_general_ci"),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FlgStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTelefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioTelefones_TelefoneTipos_TelefoneTipoId",
                        column: x => x.TelefoneTipoId,
                        principalTable: "TelefoneTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioTelefones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfilAcessos_UsuarioPerfilId",
                table: "UsuarioPerfilAcessos",
                column: "UsuarioPerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioPerfilId",
                table: "Usuarios",
                column: "UsuarioPerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTelefones_TelefoneTipoId",
                table: "UsuarioTelefones",
                column: "TelefoneTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTelefones_UsuarioId",
                table: "UsuarioTelefones",
                column: "UsuarioId");

            
            migrationBuilder.Sql($"INSERT INTO TelefoneTipos(Id, Nome, CriadoEm, ModificadoEm, FlgStatus) values('{Guid.NewGuid()}', 'Celular', '{DateTime.Now:s}','{DateTime.Now:s}', 'A');");
            migrationBuilder.Sql($"INSERT INTO TelefoneTipos(Id, Nome, CriadoEm, ModificadoEm, FlgStatus) values('{Guid.NewGuid()}', 'Residencial', '{DateTime.Now:s}','{DateTime.Now:s}', 'A');");
            migrationBuilder.Sql($"INSERT INTO TelefoneTipos(Id, Nome, CriadoEm, ModificadoEm, FlgStatus) values('{Guid.NewGuid()}', 'Comercial', '{DateTime.Now:s}', '{DateTime.Now:s}','A');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioPerfilAcessos");

            migrationBuilder.DropTable(
                name: "UsuarioTelefones");

            migrationBuilder.DropTable(
                name: "TelefoneTipos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "UsuarioPerfis");
        }
    }
}
