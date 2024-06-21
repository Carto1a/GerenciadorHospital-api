using System.Net.Mail;
using System.Text.RegularExpressions;

using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Validators;
public class DomainValidator
{
    private readonly string? _logMessage;
    private readonly List<string> _errors = [];
    private IDictionary<string, List<string>> _fildErrors = new Dictionary<string, List<string>>();
    private readonly string _fildNameError;
    public DomainValidator(string logMessage, string fildNameError)
    {
        _logMessage = logMessage;
        _fildNameError = fildNameError;
    }

    public DomainValidator(string fildNameError)
    {
        _fildNameError = fildNameError;
    }

    private void AddError(string message)
    {
        _errors.Add(message);
    }

    public void IsNome(string? target, string fildName)
    {
        if (target == null)
        {
            AddError($"{fildName} é inválido");
            return;
        }

        if (!Regex.IsMatch(target, @"^[A-Za-z]{3,30}$"))
            _errors.Add($"{fildName} é inválido");
    }

    public void NotNull(object? target, string fildName)
    {
        if (target is null)
            _errors.Add($"{fildName} não pode ser nulo");
    }

    public void DDD(string? target, string fildName)
    {
        if (target == null)
        {
            _errors.Add($"{fildName} é inválido");
            return;
        }

        if (!Regex.IsMatch(target, @"^[0-9]{2}$"))
            _errors.Add($"{fildName} é inválido");
    }

    public void NotNullOrEmpty(string? target, string fildName)
    {
        if (string.IsNullOrWhiteSpace(target))
            _errors.Add($"{fildName} não pode ser nulo ou vazio");
    }

    public void NotEmptyOrWhitespaces(string? target, string fildName)
    {
        if (target!.Trim().Length == 0)
            _errors.Add($"{fildName} não pode ser vazio ou conter apenas espaços em branco");
    }

    public void MinLength(string? target, int minLenght, string fildName)
    {
        if (target!.Length <= minLenght)
            _errors.Add($"{fildName} deve ter pelo menos {minLenght} caracteres");
    }

    public void MaxLength(string? target, int maxLenght, string fildName)
    {
        if (target!.Length >= maxLenght)
            _errors.Add($"{fildName} deve ter no máximo {maxLenght} caracteres");
    }

    public void MinValue(decimal target, decimal minValue, string fildName)
    {
        if (target <= minValue)
            _errors.Add($"{fildName} deve ser no mínimo {minValue}");
    }

    public void MaxValue(decimal target, decimal minValue, string fildName)
    {
        if (target >= minValue)
            _errors.Add($"{fildName} deve ser no máximo {minValue}");
    }

    public void MinDate(DateTime target, DateTime minDate, string fildName)
    {
        if (target <= minDate)
            _errors.Add($"{fildName} deve ser no mínimo {minDate}");
    }

    public void MaxDate(DateTime target, DateTime maxDate, string fildName)
    {
        if (target >= maxDate)
            _errors.Add($"{fildName} deve ser no máximo {maxDate}");
    }

    public void Cpf(string target, string fildName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{11}$"))
            _errors.Add($"{fildName} é inválido");

        // TODO: CPF validation algorithm
    }

    public void Cep(string target, string fildName)
    {
        // TODO: arrumar

        if (!Regex.IsMatch(target, @"^[0-9]{8}$"))
            _errors.Add($"{fildName} é inválido");
    }

    public void NumeroTelefone(string target, string fildName)
    {
        var regexTelefone = @"^[2-5]\d{7}$";

        if (!Regex.IsMatch(target, regexTelefone))
            _errors.Add($"{fildName} é inválido");
    }

    public void NumeroCelular(string target, string fildName)
    {
        var regexCelular = @"^9\d{8}$";

        if (!Regex.IsMatch(target, regexCelular))
            _errors.Add($"{fildName} é inválido");
    }

    public void Cnpj(string target, string fildName)
    {
        if (!Regex.IsMatch(target,
            @"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}-[0-9]{2}$"))
            _errors.Add($"{fildName} é inválido");
    }

    public void Crm(string target, string fildName)
    {
        var regex = @"^[0-9]{6}$";
        if (!Regex.IsMatch(target, regex))
            _errors.Add($"{fildName} é inválido");
    }

    public void CrmUf(string target, string fildName)
    {
        // TODO: arrumar
        if (!Regex.IsMatch(target, @"^[A-Z]{2}$"))
            _errors.Add($"{fildName} é inválido");
    }

    public void NumeroCasa(string target, string fildName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{1,8}([A-Z]{1,10})?$"))
            _errors.Add($"{fildName} é inválido");
    }


    public void isInEnum<T>(T target, Type type, string fildName)
    {
        if (!Enum.IsDefined(type, target!))
            _errors.Add($"{fildName} é inválido");
    }

    public void Email(string? target, string fildName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                _errors.Add($"{fildName} é inválido");
                return;
            }

            var addr = new MailAddress(target);
        }
        catch
        {
            _errors.Add($"{fildName} é inválido");
        }
    }

    public void Query(int limit, int page)
    {
        if (limit < 1)
            _errors.Add("Parâmetro limit deve ser maior que 0");

        if (page < 0)
            _errors.Add("Parâmetro page deve ser 0 ou maior");
    }

    public virtual void Check()
    {
        InitializeFildErrors();
        if (_fildErrors.Count != 0)
        {
            throw new DomainException(_logMessage!, _fildErrors);
        }
    }

    public void LoadValueObjectValidations(
        DomainValidator validations)
    {
        var errors = validations._errors;
        InitializeFildErrors();
        if (_fildNameError.Contains(validations._fildNameError))
        {
            throw new Exception("FildErrors já foi carregado");
        }

        _fildErrors.Add(validations._fildNameError, errors);
    }

    private void InitializeFildErrors()
    {
        if (_fildErrors.Count != 0)
        {
            return;
        }

        if (_errors.Count == 0)
        {
            return;
        }

        _fildErrors.Add(_fildNameError, _errors);
    }
}