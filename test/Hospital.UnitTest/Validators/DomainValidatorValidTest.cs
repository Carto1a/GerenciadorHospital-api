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

    [Fact]
    public void MinLength()
    {
        // Arrange
        var validator = new DomainValidator("Nome");

        // Act
        validator.MinLength("Nome", 1, "Nome");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void MaxLength()
    {
        // Arrange
        var validator = new DomainValidator("Nome");

        // Act
        validator.MaxLength("Nome", 10, "Nome");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void MinValue()
    {
        // Arrange
        var validator = new DomainValidator("Quantidade");

        // Act
        validator.MinValue(100, 1, "Quantidade");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void MaxValue()
    {
        // Arrange
        var validator = new DomainValidator("Quantidade");

        // Act
        validator.MaxValue(100, 1000, "Quantidade");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void MinDate()
    {
        // Arrange
        var validator = new DomainValidator("Data");
        var date = DateTime.Now;
        var minDate = DateTime.Now.AddYears(-1);

        // Act
        validator.MinDate(date, minDate, "date");
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void MaxDate()
    {
        // Arrange
        var validator = new DomainValidator("Data");
        var date = DateTime.Now;
        var maxDate = DateTime.Now.AddYears(1);

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