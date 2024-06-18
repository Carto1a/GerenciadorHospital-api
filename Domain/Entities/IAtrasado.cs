using Hospital.Domain.Entities;

namespace Hospital.Domain;
public interface IAtrasado
{
    public void CalcularMulta(Convenio? convenio);
    public bool Atrasado(DateTime now);
    public bool Ausente(DateTime now);
}