using Hospital.Domain.Validators;

namespace Hospital.UnitTest.Validators;
public class DomainValidatorTest
{
    [Fact]
    public void DomainValidatorValidConstructor()
    {
        // Arrange
        var logMessage = "Namelog";
        var fildNameError = "Namefild";

        // Act
        var validator = new DomainValidator(logMessage, fildNameError);
        // NOTE: force a erro to get domain exception
        validator.IsNome("", "Nome");
        var exception = Record.Exception(() => validator.Check());

        // Assert
        Assert.NotNull(exception);
        Assert.Equal(exception.Message, logMessage);

    }
}