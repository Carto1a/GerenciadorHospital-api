using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Genero = table.Column<bool>(type: "INTEGER", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<int>(type: "INTEGER", nullable: false),
                    Cep = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroCasa = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CadastroId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CadastroId = table.Column<string>(type: "TEXT", nullable: false),
                    Especialidade = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medicos_AspNetUsers_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CadastroId = table.Column<string>(type: "TEXT", nullable: false),
                    TemConvenio = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImgCarteiraConvenio = table.Column<string>(type: "TEXT", nullable: false),
                    ImgDocumento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pacientes_AspNetUsers_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MedicoID = table.Column<int>(type: "INTEGER", nullable: false),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    Duracao = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    Diagnostico = table.Column<string>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descrição = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<int>(type: "INTEGER", nullable: false),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Convenios_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicoID = table.Column<int>(type: "INTEGER", nullable: false),
                    Resultado = table.Column<string>(type: "TEXT", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Exames_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exames_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosConsultas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoID = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MedicoID = table.Column<int>(type: "INTEGER", nullable: false),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    Cancelado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosConsultas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgendamentosConsultas_Consultas_TipoID",
                        column: x => x.TipoID,
                        principalTable: "Consultas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosConsultas_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosConsultas_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retornos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConsultaID = table.Column<int>(type: "INTEGER", nullable: false),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    MedicoID = table.Column<int>(type: "INTEGER", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retornos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Retornos_Consultas_ConsultaID",
                        column: x => x.ConsultaID,
                        principalTable: "Consultas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retornos_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retornos_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosExames",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoID = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MedicoID = table.Column<int>(type: "INTEGER", nullable: false),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    Cancelado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosExames", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Exames_TipoID",
                        column: x => x.TipoID,
                        principalTable: "Exames",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosRetornos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoID = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MedicoID = table.Column<int>(type: "INTEGER", nullable: false),
                    PacienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    Cancelado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosRetornos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AgendamentosRetornos_Medicos_MedicoID",
                        column: x => x.MedicoID,
                        principalTable: "Medicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosRetornos_Pacientes_PacienteID",
                        column: x => x.PacienteID,
                        principalTable: "Pacientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosRetornos_Retornos_TipoID",
                        column: x => x.TipoID,
                        principalTable: "Retornos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_CadastroId",
                table: "Admins",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosConsultas_MedicoID",
                table: "AgendamentosConsultas",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosConsultas_PacienteID",
                table: "AgendamentosConsultas",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosConsultas_TipoID",
                table: "AgendamentosConsultas",
                column: "TipoID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosExames_MedicoID",
                table: "AgendamentosExames",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosExames_PacienteID",
                table: "AgendamentosExames",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosExames_TipoID",
                table: "AgendamentosExames",
                column: "TipoID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosRetornos_MedicoID",
                table: "AgendamentosRetornos",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosRetornos_PacienteID",
                table: "AgendamentosRetornos",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosRetornos_TipoID",
                table: "AgendamentosRetornos",
                column: "TipoID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoID",
                table: "Consultas",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteID",
                table: "Consultas",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_PacienteID",
                table: "Convenios",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_MedicoID",
                table: "Exames",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteID",
                table: "Exames",
                column: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_CadastroId",
                table: "Medicos",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CadastroId",
                table: "Pacientes",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_ConsultaID",
                table: "Retornos",
                column: "ConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_MedicoID",
                table: "Retornos",
                column: "MedicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_PacienteID",
                table: "Retornos",
                column: "PacienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AgendamentosConsultas");

            migrationBuilder.DropTable(
                name: "AgendamentosExames");

            migrationBuilder.DropTable(
                name: "AgendamentosRetornos");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Convenios");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "Retornos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
