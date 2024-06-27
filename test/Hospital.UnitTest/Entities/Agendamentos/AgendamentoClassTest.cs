using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.UnitTest.Entities.Agendamentos;
public class AgendamentoClassTest : Agendamento
{
    public AgendamentoClassTest() { }
    public AgendamentoClassTest(
        DateTime dataHora, Medico medico, Paciente paciente,
        Convenio? convenio, decimal custo)
    : base(dataHora, medico, paciente, convenio, custo)
    { }
}