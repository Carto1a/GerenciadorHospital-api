using Hospital.Domain.Enums;
using Hospital.Domain.Validators;

namespace Hospital.UnitTest.Validators;
public class DomainValidatorValidsTest
{
    [Fact]
    public void IsNome()
    {
        // Arrange
        var validator = new DomainValidator("Nome");

        // Act
        validator.IsNome("Nome", "Nome");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void NotNull()
    {
        // Arrange
        var validator = new DomainValidator("Nome");

        // Act
        validator.NotNull("Nome", "Nome");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void DDD()
    {
        // Arrange
        var validator = new DomainValidator("DDD");

        // Act
        validator.DDD("11", "Telefone");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void NotNullOrEmpty()
    {
        // Arrange
        var validator = new DomainValidator("Nome");

        // Act
        validator.NotNullOrEmpty("Nome", "Nome");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void NotEmptyOrWhitespaces()
    {
        // Arrange
        var validator = new DomainValidator("Nome");

        // Act
        validator.NotEmptyOrWhitespaces("Nome", "Nome");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("carro", 1)]
    [InlineData("carro", 5)]
    public void MinLength(string value, int minLenght)
    {
        // Arrange
        var validator = new DomainValidator("Nome");

        // Act
        validator.MinLength(value, minLenght, "Nome");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("carro", 5)]
    [InlineData("carro", 10)]
    public void MaxLength(string value, int maxLenght)
    {
        // Arrange
        var validator = new DomainValidator("Nome");

        // Act
        validator.MaxLength(value, maxLenght, "Nome");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(100, 1)]
    [InlineData(100, 100)]
    public void MinValue(int value, int minValue)
    {
        // Arrange
        var validator = new DomainValidator("Quantidade");

        // Act
        validator.MinValue(value, minValue, "Quantidade");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData(100, 100)]
    [InlineData(100, 1000)]
    public void MaxValue(int value, int maxValue)
    {
        // Arrange
        var validator = new DomainValidator("Quantidade");

        // Act
        validator.MaxValue(value, maxValue, "Quantidade");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("2021-01-01", "2020-01-01")]
    [InlineData("2021-01-01", "2021-01-01")]
    public void MinDate(DateTime date, DateTime minDate)
    {
        // Arrange
        var validator = new DomainValidator("Data");

        // Act
        validator.MinDate(date, minDate, "date");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Theory]
    [InlineData("2021-01-01", "2022-01-01")]
    [InlineData("2022-01-01", "2022-01-01")]
    public void MaxDate(DateTime date, DateTime maxDate)
    {
        // Arrange
        var validator = new DomainValidator("Data");

        // Act
        validator.MaxDate(date, maxDate, "date");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Cpf()
    {
        // Arrange
        var validator = new DomainValidator("Cpf");

        // Act
        validator.Cpf("12312312312", "Cpf");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Cep()
    {
        // Arrange
        var validator = new DomainValidator("Cep");

        // Act
        validator.Cep("12312312", "Cep");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void NumeroTelefone()
    {
        // Arrange
        var validator = new DomainValidator("NumeroTelefone");

        // Act
        validator.NumeroTelefone("29039102", "NumeroTelefone");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void NumeroCelular()
    {
        // Arrange
        var validator = new DomainValidator("NumeroCelular");

        // Act
        validator.NumeroCelular("910293029", "NumeroCelular");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Cnpj()
    {
        // Arrange
        var validator = new DomainValidator("Cnpj");

        // Act
        validator.Cnpj("12.123.123/1234-12", "Cnpj");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Crm()
    {
        // Arrange
        var validator = new DomainValidator("Crm");

        // Act
        validator.Crm("000000", "Crm");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void CrmUf()
    {
        // Arrange
        var validator = new DomainValidator("CrmUf");

        // Act
        validator.CrmUf("SP", "CrmUf");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void NumeroCasa()
    {
        // Arrange
        var validator = new DomainValidator("NumeroCasa");

        // Act
        validator.NumeroCasa("123A", "NumeroCasa");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void IsInEmun()
    {
        // Arrange
        var validator = new DomainValidator("Enum");

        // Act
        validator.isInEnum(GeneroEnum.Outro, typeof(GeneroEnum), "Enum");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Email()
    {
        // Arrange
        var validator = new DomainValidator("Email");

        // Act
        validator.Email("a@a.a", "Email");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Query()
    {
        // Arrange
        var validator = new DomainValidator("Query");

        // Act
        validator.Query(10, 10);
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }
}