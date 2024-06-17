using Hospital.Dtos.Input.Laudos;
using Hospital.Models.Atendimento;
using Hospital.Models.Cadastro;
using Hospital.Models.Medicamentos;

namespace Hospital.Models;
public class Laudo
{
    public Guid Id { get; set; }
    public Guid MedicoId { get; set; }
    public Guid? PacienteId { get; set; }
    public Guid ConsultaId { get; set; }

    public virtual Medico? Medico { get; set; }
    public virtual Paciente? Paciente { get; set; }
    public virtual Consulta? Consulta { get; set; }
    public virtual ICollection<Exame>? Exames { get; set; }
    public virtual ICollection<Medicamento>? Medicamentos { get; set; }

    public string Descricao { get; set; }
    public Guid? DocPath { get; set; }

    public DateTime Criado { get; set; }

    public Laudo()
    {
    }

    public Laudo(LaudoCreateDto dto)
    {
        MedicoId = dto.MedicoId;
        PacienteId = dto.PacienteId;
        ConsultaId = dto.ConsultaId;
        Descricao = dto.Descricao;
    }
}