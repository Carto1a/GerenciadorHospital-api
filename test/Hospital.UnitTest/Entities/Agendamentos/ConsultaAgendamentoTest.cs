using Bogus;
using Bogus.Extensions.Brazil;

using Hospital.Domain.Entities;
using Hospital.Domain.Entities.Agendamentos;
using Hospital.Domain.Entities.Agendamentos.Status;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Entities.ValueObjects;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.UnitTest.Entities.Agendamentos;
public class ConsultaAgendamentoTest
{
    [Fact]
    public void QuandoConvenioNaoForOMesmoDoPaciente_LancarDomainException()
    {
        var desconto = 0.1m;
        var custo = 100;
        var convenio = new Faker<Convenio>()
            .RuleFor(c => c.Desconto, f => desconto);
        var message = "O convênio do paciente não é o mesmo do agendamento.";

        var paciente = new Faker<Paciente>();
        var medico = new Faker<Medico>();

        var exception = Assert.Throws<DomainException>(() =>
        {
            var agendamento = new ConsultaAgendamento(
                    DateTime.Now.AddHours(10),
                    medico.Generate(),
                    paciente.Generate(),
                    convenio.Generate(),
                    custo);
        });

        Assert.Equal(message, exception.Message);
    }

    [Fact]
    public void QuandoConvenioForOMesmoDoPaciente_VerificarSeCalculaDesconto()
    {
        var desconto = 0.1m;
        var custo = 100;
        var custoFinal = custo * desconto;
        var convenio = new Faker<Convenio>()
            .RuleFor(c => c.Desconto, f => desconto);

        var paciente = new Faker<Paciente>()
            .RuleFor(p => p.Convenio, f => convenio.Generate()).Generate();
        var medico = new Faker<Medico>();

        var agendamento = new ConsultaAgendamento(
                DateTime.Now.AddHours(10),
                medico.Generate(),
                paciente,
                paciente.Convenio,
                custo);

        Assert.Equal(custoFinal, agendamento.CustoFinal);
    }

    [Fact]
    public void QuandoAtrasadoRetornarTrue()
    {
        var datahora = DateTime.Now.AddHours(10);
        var horarioChegada = datahora.AddYears(1);

        var agendamento = new Faker<ConsultaAgendamento>()
            .RuleFor(a => a.DataHora, f => datahora)
            .Generate();

        var atrasado = agendamento.EstaAtrasado(horarioChegada);

        Assert.True(atrasado);
    }

    [Fact]
    public void QuandoNaoAtrasadoRetornarFalse()
    {
        var datahora = DateTime.Now.AddHours(10);
        var horarioChegada = datahora.AddMinutes(15);

        var agendamento = new Faker<ConsultaAgendamento>()
            .RuleFor(a => a.DataHora, f => datahora)
            .Generate();

        var atrasado = agendamento.EstaAtrasado(horarioChegada);

        Assert.False(atrasado);
    }

    [Fact]
    public void QuandoAusenteRetornarTrue()
    {
        var datahora = DateTime.Now.AddHours(10);
        var horarioChegada = datahora.AddYears(1);

        var agendamento = new Faker<ConsultaAgendamento>()
            .RuleFor(a => a.DataHora, f => datahora)
            .Generate();

        var ausente = agendamento.EstaAusente(horarioChegada);

        Assert.True(ausente);
    }

    [Fact]
    public void QuandoNaoAusenteRetornarFalse()
    {
        var datahora = DateTime.Now.AddHours(10);
        var horarioChegada = datahora.AddMinutes(1);

        var agendamento = new Faker<ConsultaAgendamento>()
            .RuleFor(a => a.DataHora, f => datahora)
            .Generate();

        var ausente = agendamento.EstaAusente(horarioChegada);

        Assert.False(ausente);
    }
}