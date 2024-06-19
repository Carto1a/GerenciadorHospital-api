using Hospital.Domain.Entities;

namespace Hospital.Domain;
public interface IDescontavel
{
    public void CalcularDesconto(Convenio? convenio);
}