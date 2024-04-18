using FluentResults;

using Hospital.Dto.Auth;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Cadastro;
public class Paciente
: Cadastro
{
    public Guid? ConvenioId { get; set; }
    public virtual Convenio? Convenio { get; set; }
    public string? ImgCarteiraConvenio { get; set; }
    public required string ImgDocumento { get; set; }
    public virtual ICollection<Consulta>? Consultas { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Retorno>? Retornos { get; set; }

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

            DocConvenioName = SaveDocs(path, request.ConvenioImg);
            if (DocConvenioName.IsFailed)
                return Result.Fail(DocConvenioName.Errors);
        }

        var DocIntentifiName = SaveDocs(path, request.DocumentoImg);
        if (DocIntentifiName.IsFailed)
            return Result.Fail(DocIntentifiName.Errors);

        return new Paciente
        {
            ConvenioId = request.ConvenioId,
            ImgCarteiraConvenio = DocConvenioName?.Value,
            ImgDocumento = DocIntentifiName.Value,
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

    private static Result<string> SaveDocs(string path, IFormFile Doc)
    {
        try
        {
            var DocGuid = Guid.NewGuid().ToString();
            while (File.Exists(Path.Combine(path, DocGuid)))
            {
                DocGuid = Guid.NewGuid().ToString();
            }

            var DocPath = Path.Combine(path, DocGuid);

            Stream fileStream =
                new FileStream(DocPath, FileMode.Create);

            Task task = Doc.CopyToAsync(fileStream)
                .ContinueWith(task => fileStream.Close());

            return DocGuid;
        }
        catch (Exception e)
        {
            // TODO: arrumar para um jeito mais bonito
            return Result.Fail(e.Message);
        }
    }
}