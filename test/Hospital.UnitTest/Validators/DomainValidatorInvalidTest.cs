using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Validators;

namespace Hospital.UnitTest.Validators;
public class DomainValidadtorInvalidTest
{
    [Fact]
    public void IsNomeNull()
    {
        // Arrange
        var validator = new DomainValidator("Nome");
        var fildName = "Nome";
        string? value = null;
        var message = $"{fildName} é inválido";

        // Act
        validator.IsNome(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("ajs12312fs  ")]
    public void IsNomeInvalid(string value)
    {
        // Arrange
        var validator = new DomainValidator("Nome");
        var fildName = "Nome";
        var message = $"{fildName} é inválido";

        // Act
        validator.IsNome(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Fact]
    public void NotNull()
    {
        // Arrange
        var validator = new DomainValidator("Nome");
        var fildName = "Nome";
        string? value = null;
        var message = $"{fildName} não pode ser nulo";

        // Act
        validator.NotNull(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Fact]
    public void DDDNull()
    {
        // Arrange
        var validator = new DomainValidator("DDD");
        var fildName = "DDD";
        string? value = null;
        var message = $"{fildName} é inválido";

        // Act
        validator.DDD(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("")]
    [InlineData("123")]
    [InlineData("dk")]
    [InlineData("1a")]
    public void DDDInvalid(string value)
    {
        // Arrange
        var validator = new DomainValidator("DDD");
        var fildName = "DDD";
        var message = $"{fildName} é inválido";

        // Act
        validator.DDD(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("       ")]
    [InlineData(null)]
    public void NotNullOrEmpty(string? value)
    {
        // Arrange
        var validator = new DomainValidator("Nome");
        var fildName = "Nome";
        var message = $"{fildName} não pode ser nulo ou vazio";

        // Act
        validator.NotNullOrEmpty(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("       ")]
    public void NotEmptyOrWhitespaces(string value)
    {
        // Arrange
        var validator = new DomainValidator("Nome");
        var fildName = "Nome";
        var message = $"{fildName} não pode ser vazio ou conter apenas espaços em branco";

        // Act
        validator.NotEmptyOrWhitespaces(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Fact]
    public void MinLength()
    {
        // Arrange
        var validator = new DomainValidator("Nome");
        var fildName = "Nome";
        var value = "fasd";
        var minLenght = 100;
        var message = $"{fildName} deve ter pelo menos {minLenght} caracteres";

        // Act
        validator.MinLength(value, minLenght, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Fact]
    public void MaxLength()
    {
        // Arrange
        var validator = new DomainValidator("Nome");
        var fildName = "Nome";
        var value = "1231";
        var maxLenght = 2;
        var message = $"{fildName} deve ter no máximo {maxLenght} caracteres";

        // Act
        validator.MaxLength(value, maxLenght, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData(1, 10)]
    [InlineData(0, 10)]
    [InlineData(-1, 10)]
    [InlineData(-1, 0)]
    public void MinValue(int value, int minValue)
    {
        // Arrange
        var validator = new DomainValidator("Quantidade");
        var fildName = "Quantidade";
        var message = $"{fildName} deve ser no mínimo {minValue}";

        // Act
        validator.MinValue(value, minValue, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData(10, 1)]
    [InlineData(10, 0)]
    [InlineData(0, -1)]
    [InlineData(-1, -10)]
    public void MaxValue(int value, int maxValue)
    {
        // Arrange
        var validator = new DomainValidator("Quantidade");
        var fildName = "Quantidade";
        var message = $"{fildName} deve ser no máximo {maxValue}";

        // Act
        validator.MaxValue(value, maxValue, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("2003-10-10", "2003-10-11")]
    [InlineData("2003-10-10", "2004-10-11")]
    public void MinDate(DateTime date, DateTime minDate)
    {
        // Arrange
        var fildName = "date";
        var validator = new DomainValidator(fildName);
        var message = $"{fildName} deve ser no mínimo {minDate}";

        // Act
        validator.MinDate(date, minDate, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("2003-10-10", "2003-10-09")]
    [InlineData("2003-10-10", "2002-10-09")]
    public void MaxDate(DateTime date, DateTime maxDate)
    {
        // Arrange
        var fildName = "date";
        var validator = new DomainValidator(fildName);
        var message = $"{fildName} deve ser no máximo {maxDate}";

        // Act
        validator.MaxDate(date, maxDate, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("12893")]
    [InlineData("12893192839081290")]
    [InlineData("fnasdfjklasjfklasj")]
    [InlineData("123910293a1")]
    public void Cpf(string value)
    {
        // Arrange
        var validator = new DomainValidator("Cpf");
        var fildName = "Cpf";
        var message = $"{fildName} é inválido";

        // Act
        validator.Cpf(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("192039102")]
    [InlineData("1920391022198390812")]
    [InlineData("19203")]
    [InlineData("192039a02")]
    public void Cep(string value)
    {
        // Arrange
        var validator = new DomainValidator("Cep");
        var fildName = "Cep";
        var message = $"{fildName} é inválido";

        // Act
        validator.Cep(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("18293019")]
    [InlineData("291029300")]
    [InlineData("a1920391")]
    [InlineData("19203919120301923091")]
    public void NumeroTelefone(string value)
    {
        // Arrange
        var validator = new DomainValidator("NumeroTelefone");
        var fildName = "NumeroTelefone";
        var message = $"{fildName} é inválido";

        // Act
        validator.NumeroTelefone(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("192039182")]
    [InlineData("9999999999")]
    [InlineData("999a999999")]
    public void NumeroCelular(string value)
    {
        // Arrange
        var validator = new DomainValidator("NumeroCelular");
        var fildName = "NumeroCelular";
        var message = $"{fildName} é inválido";

        // Act
        validator.NumeroCelular(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("1231231231231")]
    [InlineData("12.122.123/1234-121")]
    [InlineData("12.122.123/skdo-12")]
    public void Cnpj(string value)
    {
        // Arrange
        var validator = new DomainValidator("Cnpj");
        var fildName = "Cnpj";
        var message = $"{fildName} é inválido";

        // Act
        validator.Cnpj(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("1829381")]
    [InlineData("a82938")]
    [InlineData("82938222")]
    public void Crm(string value)
    {
        // Arrange
        var validator = new DomainValidator("Crm");
        var fildName = "Crm";
        var message = $"{fildName} é inválido";

        // Act
        validator.Crm(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("123912837dflks")]
    [InlineData("sp")]
    [InlineData("12")]
    [InlineData("")]
    [InlineData("  ")]
    public void CrmUf(string value)
    {
        // Arrange
        var validator = new DomainValidator("CrmUf");
        var fildName = "CrmUf";
        var message = $"{fildName} é inválido";

        // Act
        validator.CrmUf(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("123Akajdfhaklsdjfhsa")]
    [InlineData("123129381928jf")]
    [InlineData("")]
    [InlineData("1920391029")]
    public void NumeroCasa(string value)
    {
        // Arrange
        var validator = new DomainValidator("NumeroCasa");
        var fildName = "NumeroCasa";
        var message = $"{fildName} é inválido";

        // Act
        validator.NumeroCasa(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(10000)]
    public void IsInEmun(int value)
    {
        // Arrange
        var validator = new DomainValidator("Enum");
        var fildName = "Enum";
        var type = typeof(GeneroEnum);
        var message = $"{fildName} é inválido";

        // Act
        validator.isInEnum(value, type, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("  ")]
    [InlineData(null)]
    public void EmailNullOrWhiteSpace(string? value)
    {
        // Arrange
        var validator = new DomainValidator("Email");
        var fildName = "Email";
        var message = $"{fildName} é inválido";

        // Act
        validator.Email(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData("a.@...")]
    [InlineData("@")]
    [InlineData("@com.br")]
    public void EmailInvalid(string value)
    {
        // Arrange
        var validator = new DomainValidator("Email");
        var fildName = "Email";
        var message = $"{fildName} é inválido";

        // Act
        validator.Email(value, fildName);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(message, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void QueryInvalidLimit(int valueLimit)
    {
        // Arrange
        var fildName = "Query";
        var validator = new DomainValidator(fildName);
        var valuePage = 0;
        var messageLimit = "Parâmetro limit deve ser maior que 0";

        // Act
        validator.Query(valueLimit, valuePage);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(messageLimit, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    public void QueryInvalidPage(int valuePage)
    {
        // Arrange
        var fildName = "Query";
        var validator = new DomainValidator(fildName);
        var valueLimit = 1;
        var messagePage = "Parâmetro page deve ser 0 ou maior";

        // Act
        validator.Query(valueLimit, valuePage);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        _ = Assert.Single(exceptionCast.Errors[fildName]);
        Assert.Equal(messagePage, exceptionCast.Errors[fildName][0]);
    }

    [Theory]
    [InlineData(0, -1)]
    [InlineData(-1, -10)]
    public void QueryInvalidPageLimit(int valueLimit, int valuePage)
    {
        // Arrange
        var fildName = "Query";
        var validator = new DomainValidator(fildName);
        var messageLimit = "Parâmetro limit deve ser maior que 0";
        var messagePage = "Parâmetro page deve ser 0 ou maior";

        // Act
        validator.Query(valueLimit, valuePage);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = (DomainException)exception;

        // Assert
        _ = Assert.IsType<DomainException>(exception);
        Assert.Equal(2, exceptionCast.Errors[fildName].Count);
        Assert.Equal(messageLimit, exceptionCast.Errors[fildName][0]);
        Assert.Equal(messagePage, exceptionCast.Errors[fildName][1]);
    }
}