namespace Hospital.Models.Generics.Interfaces;
public interface IAtendimento<TCreation>
{
    public void Creation(TCreation request, Medico medico, Paciente paciente);
}
