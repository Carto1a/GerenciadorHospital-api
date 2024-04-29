using System.Diagnostics.CodeAnalysis;

using FluentResults;

using Hospital.Dtos.Input.Authentications;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Models.Medicamentos;

namespace Hospital.Models.Cadastro;
public class Paciente
: Cadastro
{
    public Guid? ConvenioId { get; set; }

    public virtual Convenio? Convenio { get; set; }
    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }
    public virtual ICollection<Laudo>? Laudos { get; set; }
    public virtual ICollection<Medicamento>? Medicamentos { get; set; }
    public virtual ICollection<ConsultaAgendamento>? AgendamentosConsultas { get; set; }
    public virtual ICollection<ExameAgendamento>? AgendamentosExames { get; set; }
    public virtual ICollection<RetornoAgendamento>? AgendamentosRetornos { get; set; }

    public Guid? DocConvenioPath { get; set; }
    public Guid? DocIDPath { get; set; }

    public Paciente() { }
    [SetsRequiredMembers]
    public Paciente(RegisterRequestPacienteDto request)
    : base(request)
    { }

    public static Result<Paciente> Create(
        RegisterRequestPacienteDto request,
        Convenio? convenio,
        string path)
    {
        Result<Guid>? DocConvenioResult = null;

        if (request.ConvenioId != null)
        {
            if (request.DocConvenioImg == null)
                return Result.Fail("Imagem do Convenio esta nulo");

            var ConvenioPath = Path.Combine(path, "Convenios");
            DocConvenioResult = Cadastro
                .SaveDocToPath(ConvenioPath, request.DocConvenioImg);
            if (DocConvenioResult.IsFailed)
                return Result.Fail(DocConvenioResult.Errors);
        }

        var DocumentoPath = Path.Combine(path, "Documentos");
        var DocIDResult = Cadastro
            .SaveDocToPath(DocumentoPath, request.DocIDImg);
        if (DocIDResult.IsFailed)
            return Result.Fail(DocIDResult.Errors);

        return new Paciente
        {
            ConvenioId = request.ConvenioId,
            Sobrenome = request.Sobrenome,
            DocConvenioPath = DocConvenioResult?.Value,
            DocIDPath = DocIDResult.Value,
            Email = request.Email,
            Nome = request.Nome,
            DataNascimento = DateOnly.FromDateTime(
                request.DataNascimento),
            Genero = request.Genero,
            Telefone = request.Telefone,
            CPF = request.CPF,
            CEP = request.CEP,
            NumeroCasa = request.NumeroCasa,
            UserName = request.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };
    }
}