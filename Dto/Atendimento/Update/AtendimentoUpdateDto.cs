using Hospital.Models.Cadastro;

namespace Hospital.Dto.Atendimento.Update;
public class AtendimentoUpdateDto
{
    public Medico Medico { get; set; }
    public Paciente Paciente { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public DateTime Criado { get; set; }
    public bool Convenio { get; set; }
    public decimal Custo { get; set; }
}
