using System.Diagnostics.CodeAnalysis;

using Hospital.Domain.Entities;

namespace Hospital.Infrastructure.Database.Models;
public class PacienteModel : CadastroModel
{
    public Convenio? Convenio { get; set; }

    public Guid? DocConvenioPath { get; set; }
    public Guid DocIDPath { get; set; }

    [SetsRequiredMembers]
    public PacienteModel() { }
}