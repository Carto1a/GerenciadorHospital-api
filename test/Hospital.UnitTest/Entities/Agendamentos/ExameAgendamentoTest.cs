using Bogus;

using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;

namespace Hospital.UnitTest.Entities.Agendamentos;
public class ExameAgendamentoTest
{
    [Fact]
    public void ValidConstructor()
    {
        var dataHora = DateTime.Now.AddHours(1);
        var medico = new Faker<Medico>().Generate();
        var convenio = new Faker<Convenio>().Generate();
        var paciente = new Faker<Paciente>()
            .RuleFor(p => p.Convenio, f => convenio)
            .Generate();
        var custo = 100;
        var consulta = new Faker<Consulta>()
            .RuleFor(c => c.Paciente, f => paciente)
            .Generate();

        var agendamento = new ExameAgendamento(
            dataHora, medico, paciente, convenio, custo, consulta);

        Assert.Equal(dataHora, agendamento.DataHora);
        Assert.Equal(medico, agendamento.Medico);
        Assert.Equal(paciente, agendamento.Paciente);
        Assert.Equal(convenio, agendamento.Convenio);
        Assert.Equal(custo, agendamento.Custo);
        Assert.Equal(consulta, agendamento.Consulta);
    }
}