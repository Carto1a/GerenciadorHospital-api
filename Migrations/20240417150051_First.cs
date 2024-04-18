﻿using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Genero = table.Column<bool>(type: "INTEGER", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<int>(type: "INTEGER", nullable: false),
                    Cep = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroCasa = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "Convenios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: true),
                    CEP = table.Column<string>(type: "TEXT", nullable: true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descrição = table.Column<string>(type: "TEXT", nullable: true),
                    Desconto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Site = table.Column<string>(type: "TEXT", nullable: true),
                    Criado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Especialidade = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConvenioId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ImgCarteiraConvenio = table.Column<string>(type: "TEXT", nullable: true),
                    ImgDocumento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Diagnostico = table.Column<string>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: true),
                    MedicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Criado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Convenio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Resultado = table.Column<string>(type: "TEXT", nullable: false),
                    MedicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Criado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Convenio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exames_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosConsultas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MedicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConvenioId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Criação = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosConsultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentosConsultas_Consultas_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Consultas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgendamentosConsultas_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgendamentosConsultas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosConsultas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retornos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Observacoes = table.Column<string>(type: "TEXT", nullable: false),
                    MedicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Inicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Criado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Convenio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retornos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retornos_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retornos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retornos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosExames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MedicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConvenioId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Criação = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosExames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Exames_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Exames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosRetornos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoId = table.Column<Guid>(type: "TEXT", nullable: true),
                    MedicoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConvenioId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Criação = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Custo = table.Column<decimal>(type: "TEXT", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosRetornos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentosRetornos_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgendamentosRetornos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosRetornos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosRetornos_Retornos_TipoId",
                        column: x => x.TipoId,
                        principalTable: "Retornos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosConsultas_ConvenioId",
                table: "AgendamentosConsultas",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosConsultas_MedicoId",
                table: "AgendamentosConsultas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosConsultas_PacienteId",
                table: "AgendamentosConsultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosConsultas_TipoId",
                table: "AgendamentosConsultas",
                column: "TipoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosExames_ConvenioId",
                table: "AgendamentosExames",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosExames_MedicoId",
                table: "AgendamentosExames",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosExames_PacienteId",
                table: "AgendamentosExames",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosExames_TipoId",
                table: "AgendamentosExames",
                column: "TipoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosRetornos_ConvenioId",
                table: "AgendamentosRetornos",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosRetornos_MedicoId",
                table: "AgendamentosRetornos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosRetornos_PacienteId",
                table: "AgendamentosRetornos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosRetornos_TipoId",
                table: "AgendamentosRetornos",
                column: "TipoId",
                unique: true);

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
                name: "IX_Consultas_MedicoId",
                table: "Consultas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_MedicoId",
                table: "Exames",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteId",
                table: "Exames",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ConvenioId",
                table: "Pacientes",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_ConsultaId",
                table: "Retornos",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_MedicoId",
                table: "Retornos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_PacienteId",
                table: "Retornos",
                column: "PacienteId");
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

            migrationBuilder.DropTable(
                name: "Convenios");
        }
    }
}