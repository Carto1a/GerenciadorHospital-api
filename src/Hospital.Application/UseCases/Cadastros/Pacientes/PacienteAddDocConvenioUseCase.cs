/* using Hospital.Application.Exceptions; */
/* using Hospital.Application.Services; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Cadastros; */

/* namespace Hospital.Application.UseCases.Cadastros.Pacientes; */
/* public class PacienteAddDocConvenioUseCase */
/* { */
/*     private readonly IPacienteRepository _pacienteRepository; */
/*     private readonly IImageService _imageService; */
/*     private readonly IUnitOfWork _uow; */

/*     public PacienteAddDocConvenioUseCase( */
/*         IPacienteRepository pacienteRepository, */
/*         IImageService imageService, */
/*         IUnitOfWork uow) */
/*     { */
/*         _pacienteRepository = pacienteRepository; */
/*         _imageService = imageService; */
/*         _uow = uow; */
/*     } */

/*     public async Task<Guid> Handler(Guid id, Stream image) */
/*     { */
/*         var paciente = await _pacienteRepository.GetByIdAsync(id); */
/*         if (paciente == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Paciente não encontrado: {id}", */
/*                 "Paciente não encontrado"); */

/*         if (paciente.Convenio == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Paciente não possui convênio: {id}", */
/*                 "Paciente não possui convênio"); */

/*         var imageId = _imageService.SavePacienteDocConvenio(image); */
/*         paciente.DocConvenioPath = imageId; */

/*         _pacienteRepository.UpdateAsync(paciente); */
/*         await _uow.SaveAsync(); */

/*         return imageId; */
/*     } */
/* } */