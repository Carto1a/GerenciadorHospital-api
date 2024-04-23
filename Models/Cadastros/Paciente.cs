using FluentResults;

using Hospital.Dto.Auth;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Cadastro;
public class Paciente
: Cadastro
{
    public Guid? ConvenioId { get; set; }

    public virtual Convenio? Convenio { get; set; }
    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }

    public string? DocConvenioPath { get; set; }
    public string? DocIDPath { get; set; }

    public static Result<Paciente> Create(
        RegisterRequestPacienteDto request,
        Convenio? convenio,
        string path)
    {
        Result<string>? DocConvenioName = null;

        if (request.ConvenioId != null)
        {
            if (request.ConvenioImg == null)
                throw new ArgumentNullException(
                    nameof(request.ConvenioImg));

            var ConvenioPath = Path.Combine(path, "Convenios");
            DocConvenioName = Cadastro
                .SaveDocToPath(ConvenioPath, request.ConvenioImg);
            if (DocConvenioName.IsFailed)
                return Result.Fail(DocConvenioName.Errors);
        }

        var DocumentoPath = Path.Combine(path, "Documentos");
        var DocIntentifiName = Cadastro
            .SaveDocToPath(DocumentoPath, request.DocumentoImg);
        if (DocIntentifiName.IsFailed)
            return Result.Fail(DocIntentifiName.Errors);

        return new Paciente
        {
            ConvenioId = request.ConvenioId,
            DocConvenioPath = DocConvenioName?.Value,
            DocIDPath = DocIntentifiName.Value,
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
    }
}