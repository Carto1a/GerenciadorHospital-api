using Hospital.Domain.Exceptions;

namespace Hospital.UnitTest;
public class DomainExceptionTest
{
    // NOTE: a classe de domain exception não esta 100% para ser testada
    [Fact]
    public void QuandoConstruindoComUmaStringDeveQuardarMensagem()
    {
        // Arrange
        var mensagem = "Mensagem de erro";

        // Act
        var exception = new DomainException(mensagem);

        // Assert
        Assert.Equal(mensagem, exception.Message);
        Assert.Equal(mensagem, exception.LogMessage);
    }
}