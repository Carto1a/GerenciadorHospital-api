using FluentResults;

using Hospital.Enums;
using Hospital.Models.Cadastro;


namespace Hospital.Service.Interfaces;
public interface IPacienteService
{
    Result<string> GetPacienteDocumento(Guid id, PacienteDocumentosEnum documentoTipo);
    Result<List<Paciente>> GetPacientes(int limit, int page = 0);
    Result<string> GetPacienteDocumentoByGuid(Guid id, PacienteDocumentosEnum documentoTipo);
    Result<Paciente?> GetPacienteById(Guid pacienteId);
}