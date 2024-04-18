using Hospital.Dto.Auth;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Cadastro;
public class Paciente
: Cadastro
{
    public Guid? ConvenioId { get; set; }
    public virtual Convenio? Convenio { get; set; }
    public string? ImgCarteiraConvenio { get; set; }
    public string ImgDocumento { get; set; }
    public virtual ICollection<Consulta> Consultas { get; set; }
    public virtual ICollection<Exame> Exames { get; set; }
    public virtual ICollection<Retorno> Retornos { get; set; }

    public void Create(
        RegisterRequestPacienteDto request,
        Convenio? convenio,
        string path)
    {
        // NOTE: se criar uma exeção, todo isso morre
        string? DocConvenioName = null;

        if (request.ConvenioId != null)
        {
            DocConvenioName = Guid.NewGuid().ToString();
            var DocConvenioPath = Path.Combine(
                path, DocConvenioName);
            Stream fileStream = new FileStream(
                DocConvenioPath, FileMode.Create);
            Task task = request.ConvenioImg.CopyToAsync(fileStream)
                .ContinueWith(task => fileStream.Close());
        }

        var DocIntentifiName = Guid.NewGuid().ToString();
        var DocIntentifiPath = Path.Combine(
            path, DocIntentifiName);

        Stream fileStream2 = new FileStream(
            DocIntentifiPath, FileMode.Create);
        // NOTE: que deus abençõe essa task, que ela nunca dê erro
        // NOTE: amem
        Task task1 = request.DocumentoImg.CopyToAsync(fileStream2)
            .ContinueWith(task => fileStream2.Close());

        ImgCarteiraConvenio = DocConvenioName;
        ImgDocumento = DocIntentifiName;
        Email = request.Email;
        Nome = request.Nome;
        DataNascimento = DateOnly.FromDateTime(DateTime.Now);
        Genero = request.Genero;
        Telefone = request.Telefone;
        Cpf = request.Cpf;
        Cep = request.Cep;
        NumeroCasa = request.NumeroCasa;
        UserName = request.Email;
        SecurityStamp = Guid.NewGuid().ToString();
    }
}
