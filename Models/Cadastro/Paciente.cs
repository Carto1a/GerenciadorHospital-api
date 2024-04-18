using Hospital.Dto.Auth;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Models.Cadastro;
public class Paciente
: Cadastro
{
    public bool TemConvenio { get; set; }
    public virtual List<Convenio>? Convenios { get; set; }
    public string ImgCarteiraConvenio { get; set; }
    public string ImgDocumento { get; set; }
    public virtual ICollection<Consulta> Consultas { get; set; }
    public virtual ICollection<Exame> Exames { get; set; }
    public virtual ICollection<Retorno> Retornos { get; set; }
    /* public virtual ICollection<ConsultaAgendamento> AgendamentosConsultas { get; set; } */
    /* public virtual ICollection<ExameAgendamento> AgendamentosExames { get; set; } */
    /* public virtual ICollection<RetornoAgendamento> AgendamentosRetornos { get; set; } */

    public async Task Create(
        RegisterRequestPacienteDto request,
        string path)
    {
        var DocConvenioName = Guid.NewGuid().ToString();
        var DocIntentifiName = Guid.NewGuid().ToString();
        var DocConvenioPath = Path.Combine(
            path, DocConvenioName);
        var DocIntentifiPath = Path.Combine(
            path, DocIntentifiName);

        Stream fileStream = new FileStream(
            DocConvenioPath, FileMode.Create);
        Stream fileStream2 = new FileStream(
            DocIntentifiPath, FileMode.Create);

        await request.Convenio.CopyToAsync(fileStream);
        await request.Convenio.CopyToAsync(fileStream2);

        fileStream.Close();
        fileStream2.Close();

        TemConvenio = request.TemConvenio;
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
