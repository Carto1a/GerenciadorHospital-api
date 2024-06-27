using Hospital.Domain.Exceptions;
using Hospital.Domain.Validators;

namespace Hospital.UnitTest.Validators;
public class DomainValidatorValueObjects
{
    [Fact]
    public void QuandoCarregarValueObjectValidacionInvalidMostrar1Messagens()
    {
        // Arrange
        var email = "email";
        var fieldName = "Email";
        var validator = new DomainValidator("Entity");
        var validatorEmail = new DomainValidator("Email");
        var message = "Email é inválido";

        // Act
        validatorEmail.Email(email, fieldName);
        validator.LoadValueObjectValidations(validatorEmail);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = exception as DomainException;

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<DomainException>(exception);
        Assert.Single(exceptionCast.Errors.Keys);
        Assert.Equal(fieldName, exceptionCast.Errors.Keys.First());
        Assert.Single(exceptionCast.Errors[fieldName]);
        Assert.Equal(message, exceptionCast.Errors[fieldName].First());
    }

    [Fact]
    public void QuandoCarregarValueObjectValidacionInvalidMostrar2Messagens()
    {
        // Arrange
        var email = "email";
        var value = "value";
        var minLength = 10;
        var fieldName = "Email";
        var validator = new DomainValidator("Entity");
        var validatorEmail = new DomainValidator(fieldName);
        var message = $"{fieldName} é inválido";
        var message2 = $"{fieldName} deve ter pelo menos {minLength} caracteres";

        // Act
        validatorEmail.Email(email, fieldName);
        validatorEmail.MinLength(value, minLength, fieldName);
        validator.LoadValueObjectValidations(validatorEmail);
        var exception = Record.Exception(validator.Check);
        var exceptionCast = exception as DomainException;

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<DomainException>(exception);
        Assert.Single(exceptionCast.Errors.Keys);
        Assert.Equal(fieldName, exceptionCast.Errors.Keys.First());
        Assert.Equal(2, exceptionCast.Errors[fieldName].Count);
        Assert.Equal(message, exceptionCast.Errors[fieldName][0]);
        Assert.Equal(message2, exceptionCast.Errors[fieldName][1]);
    }

    [Fact]
    public void QuandoCarregar2ValidacoesComOMesmoFieldNameLancaDomainInternalException()
    {
        // Arrange
        var value = "value";
        var minLength = 10;
        var fieldName = "Email";

        var validator = new DomainValidator("Entity");
        var validatorEmail = new DomainValidator(fieldName);
        validatorEmail.MinLength(value, minLength, fieldName);
        validator.LoadValueObjectValidations(validatorEmail);

        // Act
        var exception = Record.Exception(() =>
        {
            validator.LoadValueObjectValidations(validatorEmail);
        });

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<DomainInternalException>(exception);
        Assert.Equal("FieldErrors já foi carregado", exception.Message);
    }

    [Fact]
    public void QuandoCarregarValueObjectValidacionsValidECheckNaoLancarDomainException()
    {
        // Arrange
        var fieldName = "Email";

        var validator = new DomainValidator("Entity");
        var validatorEmail = new DomainValidator(fieldName);
        validator.LoadValueObjectValidations(validatorEmail);

        // Act
        var exception = Record.Exception(validator.Check);

        // Assert
        Assert.Null(exception);
    }

    // TODO: testar quando a entitade for invalida e o value object for invalido

}