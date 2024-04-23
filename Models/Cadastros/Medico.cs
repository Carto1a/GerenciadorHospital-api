using FluentResults;

using Hospital.Dto.Auth;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Cadastro;
public class Medico
: Cadastro
{
    public string CRM { get; set; }
    public string? DocCRMPath { get; set; }
    public string Especialidade { get; set; }
    public bool Ativo { get; set; }

    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<ConsultaAgendamento>? AgendamentosConsultas { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<RetornoAgendamento>? AgendamentosRetornos { get; set; }

    public static Result<Medico> Create(
        RegisterRequestMedicoDto request)
    {
        // NOTE: validar as coisa aqui?
        var medico = new Medico
        {
            Especialidade = request.Especialidade,
            Email = request.Email,
            Nome = request.Nome,
            DataNascimento = DateOnly.FromDateTime(
                request.DataNascimento),
            Genero = request.Genero,
            Telefone = request.Telefone,
            Cpf = request.Cpf,
            Cep = request.Cep,
            NumeroCasa = request.NumeroCasa,
            UserName = request.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        return Result.Ok(medico);
    }
}