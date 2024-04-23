using FluentResults;

using Hospital.Dtos.Input.Authentications;
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
        Result<string>? DocConvenioResult = null;

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