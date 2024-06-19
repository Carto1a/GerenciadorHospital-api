namespace Hospital.Domain.Enums;
[Flags]
public enum AgendamentoStatus
{
    Agendado = 1 << 0, // 000001
    Realizado = 1 << 1, // 000010
    EmEspera = 1 << 2, // 000100
    EmAndamento = 1 << 3, // 001000
    Ausencia = 1 << 4, // 010000
    Cancelado = 1 << 5, // 100000
}