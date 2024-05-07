using Hospital.Dtos.Input.Atendimentos;
using Hospital.Enums;
using Hospital.Exceptions;
using Hospital.Models.Atendimento;
using Hospital.Models.Cadastro;
using Hospital.Repository;

namespace Hospital.Services.Atendimentos.Exames;
public class ExameCreateService
{
    private readonly UnitOfWork _uow;
    public ExameCreateService(UnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handler(
        ExameCreateDto request)
    {
        // NOTE: apressado filho da puta
        var atendimento = new Exame(request);

        var repo = _uow.ExameRepository;
        var agendamentoRepo = _uow.ExameAgendamentoRepository;

        var findAgendamento = await agendamentoRepo
            .GetByIdAsync(request.AgendamentoId);
        if (findAgendamento == null)
            throw new RequestError(
                "Agendamento não encontrado");

        if (findAgendamento.Deletado)
            throw new RequestError(
                "Agendamento deletado");

        var wrongStatus =
            AgendamentoStatus.Ausencia
            | AgendamentoStatus.Realizado
            | AgendamentoStatus.Cancelado
            | AgendamentoStatus.EmAndamento;

        if (wrongStatus.HasFlag(findAgendamento.Status))
            throw new RequestError(
                $"Agendamento {(findAgendamento.Status).ToString()} não permitido");

        Convenio? findConvenio = null;
        if (findAgendamento.ConvenioId != null)
        {
            findConvenio = _uow.ConvenioRepository
                .GetConvenioById((Guid)findAgendamento.ConvenioId);
        }

        var findMedico = _uow.MedicoRepository
            .GetMedicoById(request.MedicoId);
        if (findMedico == null)
            throw new RequestError(
                $"Médico não encontrado: {request.MedicoId}",
                "Médico não encontrado");

        var findPaciente = _uow.PacienteRepository
            .GetPacienteById((Guid)findAgendamento.PacienteId!);
        if (findPaciente == null)
            throw new RequestError(
                $"Paciente não encontrado: {findAgendamento.PacienteId}",
                "Paciente não encontrado");

        atendimento.Custo = findAgendamento.Custo;
        atendimento.CustoFinal = findAgendamento.CustoFinal;
        atendimento.PacienteId = findPaciente.Id;
        atendimento.ConvenioId = findConvenio?.Id;

        findAgendamento.Status = AgendamentoStatus.Realizado;

        var guid = await repo.CreateAsync(atendimento);
        agendamentoRepo.Update(findAgendamento);
        await _uow.Save();

        return guid;
    }
}