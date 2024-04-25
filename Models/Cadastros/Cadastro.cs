using FluentResults;

using Hospital.Enums;

using Microsoft.AspNetCore.Identity;

namespace Hospital.Models.Cadastro;
public class Cadastro
: IdentityUser<Guid>
{
    public required string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public GeneroEnum Genero { get; set; }
    public string? Telefone { get; set; }
    public int CPF { get; set; }
    public int CEP { get; set; }
    public string? NumeroCasa { get; set; }

    public DateTime Criado { get; set; }
    public bool Ativo { get; set; }

    protected static Result<Guid> SaveDocToPath(
        string path, IFormFile Doc)
    {
        try
        {
            var DocGuid = Guid.NewGuid();
            while (File.Exists(Path.Combine(path, DocGuid.ToString())))
            {
                DocGuid = Guid.NewGuid();
            }

            var DocPath = Path.Combine(path, DocGuid.ToString());

            Stream fileStream =
                new FileStream(DocPath, FileMode.Create);

            Task task = Doc.CopyToAsync(fileStream)
                .ContinueWith(task => fileStream.Close());

            return DocGuid;
        }
        catch (Exception e)
        {
            // TODO: arrumar para um jeito mais bonito
            return Result.Fail(e.Message);
        }
    }
}