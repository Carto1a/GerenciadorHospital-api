using Hospital.Domain.Entities.Cadastros;

namespace Hospital.Domain;
public interface IDescontavel
{
    public void CalcularDesconto(Convenio? convenio);
}