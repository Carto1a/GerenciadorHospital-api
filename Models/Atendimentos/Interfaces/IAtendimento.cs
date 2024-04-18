using Hospital.Models.Cadastro;

namespace Hospital.Models.Atendimento.Interfaces;
public interface IAtendimento<TCreation>
{
    public void Creation(TCreation request, Medico medico, Paciente paciente);
}