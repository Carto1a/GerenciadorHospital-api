using Hospital.Domain.Enums;

namespace Hospital.Domain.Entities.Cadastros;
public class Admin : Cadastro
{
    public Admin() { }
    public Admin(
        string email, string passwordHash, bool emailConfirmed,
        string nome, string sobrenome, DateOnly dataNascimento,
        GeneroEnum genero, string? ddd, string? telefoneNumero, TipoTelefone tipoTelefone,
        string cpf, string cep, string numeroCasa, string? complemento)
    : base(
        email, passwordHash, emailConfirmed,
        nome, sobrenome, dataNascimento,
        genero, ddd, telefoneNumero, tipoTelefone,
        cpf, cep, numeroCasa, complemento)
    { }

    public override bool CheckUniqueness<TCadastro>(TCadastro cadastro)
    {
        if (cadastro is Admin)
        {
            return Email == cadastro.Email
                || CPF == cadastro.CPF;
        }

        throw new ArgumentException(
            "O tipo de registro não é um administrador.");
    }
}