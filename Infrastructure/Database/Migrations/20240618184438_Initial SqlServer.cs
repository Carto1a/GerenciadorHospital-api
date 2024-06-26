﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCasa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Convenios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrição = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoDeBarras = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Composicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrincipioAtivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeMinima = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<int>(type: "int", nullable: false),
                    CRMUF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DocCRMPath = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Especialidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocConvenioPath = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocIDPath = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "MedicamentoLotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataFabricacao = table.Column<DateOnly>(type: "date", nullable: false),
                    DataVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    QuantidadeDisponivel = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoLotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicamentoLotes_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosConsultas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoAtraso = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosConsultas", x => x.Id);
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicamentoPaciente",
                columns: table => new
                {
                    MedicamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacientesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoPaciente", x => new { x.MedicamentosId, x.PacientesId });
                    table.ForeignKey(
                        name: "FK_MedicamentoPaciente_Medicamentos_MedicamentosId",
                        column: x => x.MedicamentosId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentoPaciente_Pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AgendamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_AgendamentosConsultas_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "AgendamentosConsultas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultas_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosExames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoAtraso = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosExames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentosExames_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgendamentosRetornos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoAtraso = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentosRetornos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendamentosRetornos_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Laudos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocPath = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laudos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laudos_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Laudos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Laudos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Exames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AgendamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_AgendamentosExames_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "AgendamentosExames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exames_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exames_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exames_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exames_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Retornos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Criado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AgendamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConvenioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Custo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retornos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retornos_AgendamentosRetornos_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "AgendamentosRetornos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Retornos_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Retornos_Convenios_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Retornos_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Retornos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LaudoMedicamento",
                columns: table => new
                {
                    LaudosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaudoMedicamento", x => new { x.LaudosId, x.MedicamentosId });
                    table.ForeignKey(
                        name: "FK_LaudoMedicamento_Laudos_LaudosId",
                        column: x => x.LaudosId,
                        principalTable: "Laudos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaudoMedicamento_Medicamentos_MedicamentosId",
                        column: x => x.MedicamentosId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exame_Laudo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LaudoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame_Laudo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_Laudo_Exames_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exames",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exame_Laudo_Laudos_LaudoId",
                        column: x => x.LaudoId,
                        principalTable: "Laudos",
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
                name: "IX_AgendamentosConsultas_Status",
                table: "AgendamentosConsultas",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosExames_ConsultaId",
                table: "AgendamentosExames",
                column: "ConsultaId");

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
                name: "IX_AgendamentosExames_Status",
                table: "AgendamentosExames",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentosRetornos_ConsultaId",
                table: "AgendamentosRetornos",
                column: "ConsultaId");

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
                name: "IX_AgendamentosRetornos_Status",
                table: "AgendamentosRetornos",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "IX_AspNetUsers_Ativo",
                table: "AspNetUsers",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CPF",
                table: "AspNetUsers",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Genero",
                table: "AspNetUsers",
                column: "Genero");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_AgendamentoId",
                table: "Consultas",
                column: "AgendamentoId",
                unique: true,
                filter: "[AgendamentoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ConvenioId",
                table: "Consultas",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoId",
                table: "Consultas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_Status",
                table: "Consultas",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Ativo",
                table: "Convenios",
                column: "Ativo");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_CNPJ",
                table: "Convenios",
                column: "CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Convenios_Email",
                table: "Convenios",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_Laudo_ExameId",
                table: "Exame_Laudo",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_Laudo_LaudoId",
                table: "Exame_Laudo",
                column: "LaudoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_AgendamentoId",
                table: "Exames",
                column: "AgendamentoId",
                unique: true,
                filter: "[AgendamentoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_ConsultaId",
                table: "Exames",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_ConvenioId",
                table: "Exames",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_MedicoId",
                table: "Exames",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteId",
                table: "Exames",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_Status",
                table: "Exames",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_LaudoMedicamento_MedicamentosId",
                table: "LaudoMedicamento",
                column: "MedicamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_ConsultaId",
                table: "Laudos",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_DocPath",
                table: "Laudos",
                column: "DocPath",
                unique: true,
                filter: "[DocPath] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_MedicoId",
                table: "Laudos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Laudos_PacienteId",
                table: "Laudos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoLotes_Codigo",
                table: "MedicamentoLotes",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoLotes_MedicamentoId",
                table: "MedicamentoLotes",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoLotes_Status",
                table: "MedicamentoLotes",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoPaciente_PacientesId",
                table: "MedicamentoPaciente",
                column: "PacientesId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_CodigoDeBarras",
                table: "Medicamentos",
                column: "CodigoDeBarras",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_Status",
                table: "Medicamentos",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_CRM",
                table: "Medicos",
                column: "CRM",
                unique: true,
                filter: "[CRM] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_DocCRMPath",
                table: "Medicos",
                column: "DocCRMPath",
                unique: true,
                filter: "[DocCRMPath] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ConvenioId",
                table: "Pacientes",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DocConvenioPath",
                table: "Pacientes",
                column: "DocConvenioPath",
                unique: true,
                filter: "[DocConvenioPath] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_DocIDPath",
                table: "Pacientes",
                column: "DocIDPath",
                unique: true,
                filter: "[DocIDPath] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_AgendamentoId",
                table: "Retornos",
                column: "AgendamentoId",
                unique: true,
                filter: "[AgendamentoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_ConsultaId",
                table: "Retornos",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_ConvenioId",
                table: "Retornos",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_MedicoId",
                table: "Retornos",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_PacienteId",
                table: "Retornos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Retornos_Status",
                table: "Retornos",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

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
                name: "Exame_Laudo");

            migrationBuilder.DropTable(
                name: "LaudoMedicamento");

            migrationBuilder.DropTable(
                name: "MedicamentoLotes");

            migrationBuilder.DropTable(
                name: "MedicamentoPaciente");

            migrationBuilder.DropTable(
                name: "Retornos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Exames");

            migrationBuilder.DropTable(
                name: "Laudos");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "AgendamentosRetornos");

            migrationBuilder.DropTable(
                name: "AgendamentosExames");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "AgendamentosConsultas");

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
