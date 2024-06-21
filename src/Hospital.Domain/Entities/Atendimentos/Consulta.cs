using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Enums;
using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Entities.Atendimentos;
public class Consulta : Atendimento
{
    public ICollection<Exame>? Exames { get; set; }
    public ICollection<Laudo>? Laudos { get; set; }
    public Prescricao? Prescricao { get; set; }

    public ConsultaStatus Status { get; set; }
    public Consulta(Medico medico,
        DateTime inicio, DateTime fim, ConsultaStatus status = ConsultaStatus.Realizado,
        Prescricao? prescricao = null)
    : base(medico, inicio, fim)
    {
        Status = status;
        Prescricao = prescricao;
    }

    public void AddExame(Exame exame)
    {
        if (Exames == null)
            Exames = new List<Exame>();

        if (Exames.Any(e => e.Id == exame.Id))
            throw new DomainException(
                $"O exame já foi adicionado: {exame.Id}.");

        Exames.Add(exame);
        EmProcessamento();
    }

    public void EmProcessamento()
    {
        if (Exames == null)
            return;

        foreach (var exame in Exames)
        {
            if (exame.Status == ExameStatus.Processando)
            {
                Status = ConsultaStatus.Processando;
                return;
            }
        }

        Status = ConsultaStatus.Realizado;
    }

    public void AddLaudo(Laudo laudo)
    {
        if (Laudos == null)
            Laudos = new List<Laudo>();

        if (Laudos.Any(l => l.Id == laudo.Id))
            throw new DomainException(
                $"O laudo já foi adicionado: {laudo.Id}.");

        Laudos.Add(laudo);
    }
}