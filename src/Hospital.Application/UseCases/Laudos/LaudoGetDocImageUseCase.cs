/* using Hospital.Application.Exceptions; */
/* using Hospital.Application.Services; */
/* using Hospital.Domain.Repositories; */

/* namespace Hospital.Application.UseCases.Laudos; */
/* public class LaudoGetDocImageUseCase */
/* { */
/*     private readonly ILaudoRepository _laudoRepository; */
/*     private readonly IImageService _imageService; */
/*     public LaudoGetDocImageUseCase( */
/*         ILaudoRepository laudoRepository, */
/*         IImageService imageService) */
/*     { */
/*         _laudoRepository = laudoRepository; */
/*         _imageService = imageService; */
/*     } */

/*     public async Task<Stream> Handler(Guid id) */
/*     { */
/*         var laudo = await _laudoRepository.GetByIdAsync(id); */
/*         if (laudo == null) */
/*             throw new ApplicationLayerException( */
/*                 $"Laudo não encontrado: {id}", */
/*                 "Laudo não encontrado"); */

/*         var docIdName = laudo.DocPath; */
/*         if (docIdName == null) */
/*             throw new ApplicationLayerException("Imagem do laudo não encontrada"); */

/*         var stream = _imageService.GetLaudoImagePath((Guid)docIdName); */
/*         return stream; */
/*     } */
/* } */