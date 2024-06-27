using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.UnitTest.Entities.Cadastros;
public class AdminConstructorTest
{
    [Fact]
    public void ValidConstructionAdmin()
    {
        // Arrange
        var email = "admin@amin.admin";
        var passwordHash = "admin";
        var emailConfirmed = true;
        var nome = "Admin";
        var sobrenome = "Admin";
        var dataNascimento = new DateOnly(1990, 1, 1);
        var genero = GeneroEnum.Masculino;
        var ddd = "11";
        var telefoneNumero = "999999999";
        var tipoTelefone = TipoTelefone.Celular;
        var cpf = "99999999999";
        var cep = "99999999";
        var numeroCasa = "123";
        var complemento = "complemento";

        // Act
        var exception = Record.Exception(() =>
        {
            _ = new Admin(
                email, passwordHash, emailConfirmed,
                nome, sobrenome, dataNascimento,
                genero, ddd, telefoneNumero, tipoTelefone,
                cpf, cep, numeroCasa, complemento);
        });

        var exceptionCast = exception as DomainException;

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void InvalidConstructionAdmin()
    {
        // Arrange
        var email = "";
        var passwordHash = "";
        var emailConfirmed = true;
        var nome = "";
        var sobrenome = "";
        var dataNascimento = new DateOnly(1000, 1, 1);
        var genero = (GeneroEnum)(-1);
        var ddd = "";
        var telefoneNumero = "";
        var tipoTelefone = TipoTelefone.Celular;
        var cpf = "";
        var cep = "";
        var numeroCasa = "";
        var complemento = "";

        // Act
        // Assert
        var exception = Assert.ThrowsAsync<DomainException>(async () =>
        {
            _ = new Admin(
                email, passwordHash, emailConfirmed,
                nome, sobrenome, dataNascimento,
                genero, ddd, telefoneNumero, tipoTelefone,
                cpf, cep, numeroCasa, complemento);
        });


    }
}