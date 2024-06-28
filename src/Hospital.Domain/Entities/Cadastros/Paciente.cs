using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Cadastros;
public class Paciente : Cadastro
{
    public Convenio? Convenio { get; set; }

    public Guid? DocConvenioPath { get; set; }
    public Guid DocIDPath { get; set; }

    public Paciente() { }

    public Paciente(
        string email, bool emailConfirmed,
        string nome, string sobrenome, DateOnly dataNascimento,
        GeneroEnum genero, string? ddd, string? telefoneNumero, TipoTelefone tipoTelefone,
        string cpf, string cep, string numeroCasa, string? complemento)
    : base(
        email, emailConfirmed,
        nome, sobrenome, dataNascimento,
        genero, ddd, telefoneNumero, tipoTelefone,
        cpf, cep, numeroCasa, complemento)
    { }

    public void AddDocId(Guid docName)
    {
        DocIDPath = docName;
    }

    public void AddDocConvenio(Guid docName)
    {
        if (Convenio == null)
            throw new DomainException(
                "O paciente não possui convênio.");

        DocConvenioPath = docName;
    }

    public void AddConvenio(Convenio convenio)
    {
        if (convenio.Ativo == false)
            throw new DomainException(
                "O convênio não está ativo.");

        Convenio = convenio;
    }

    public override bool CheckUniqueness<TCadastro>(TCadastro cadastro)
    {
        if (cadastro is Paciente paciente)
        {
            return Email == paciente.Email
                || CPF == paciente.CPF;
        }

        throw new ArgumentException(
            "O tipo de registro não é um paciente.");
    }
}