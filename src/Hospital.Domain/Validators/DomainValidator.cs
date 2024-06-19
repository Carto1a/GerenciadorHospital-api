using System.Net.Mail;
using System.Text.RegularExpressions;

using Hospital.Domain.Exceptions;

namespace Hospital.Domain.Validators;
public class DomainValidator
{
    private readonly string? _logMessage;
    private readonly List<string> _errors = [];
    private IDictionary<string, string> _errors2 = new Dictionary<string, string>();
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

    private void AddToErrors(string message, string fildName)
    {
        _errors2.Add(fildName, message);
    }

    public void IsNome(string? target, string fildName)
    {
        if (target == null)
        {
            _errors.Add($"{fildName} is invalid");
            return;
        }

        if (!Regex.IsMatch(target, @"^[A-Za-z]{3,30}$"))
            _errors.Add($"{fildName} is invalid");
    }

    public void NotNull(object? target, string fildName)
    {
        if (target is null)
            _errors.Add($"{fildName} should not be null");
    }

    public void DDD(string? target, string fildName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{2}$"))
            _errors.Add($"{fildName} is invalid");
    }

    public void NotNullOrEmpty(string? target, string fildName)
    {
        if (string.IsNullOrWhiteSpace(target))
            _errors.Add($"{fildName} not be null or empty");
    }

    public void NotEmptyOrWhitespaces(string? target, string fildName)
    {
        if (target!.Trim().Length == 0)
            _errors.Add($"{fildName} not be empty or whitespaces");
    }

    public void MinLength(string? target, int minLenght, string fildName)
    {
        if (target!.Length < minLenght)
            _errors.Add($"{fildName} must be at least {minLenght} characters");
    }

    public void MaxLength(string? target, int maxLenght, string fildName)
    {
        if (target!.Length > maxLenght)
            _errors.Add($"{fildName} must be at most {maxLenght} characters");
    }

    public void MinValue(decimal target, decimal minValue, string fildName)
    {
        if (target < minValue)
            _errors.Add($"{fildName} must be at least {minValue}");
    }

    public void MinDate(DateTime target, DateTime minDate, string fildName)
    {
        if (target < minDate)
            _errors.Add($"{fildName} must be at least {minDate}");
    }

    public void MaxDate(DateTime target, DateTime maxDate, string fildName)
    {
        if (target > maxDate)
            _errors.Add($"{fildName} must be at most {maxDate}");
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
            _errors.Add($"{fildName} is invalid");
    }

    public void NumeroTelefone(string target, string fildName)
    {
        var regexTelefone = @"/^[2-5]\d{7}$/";

        if (Regex.IsMatch(target, regexTelefone))
            _errors.Add($"{fildName} is invalid");
    }

    public void NumeroCelular(string target, string fildName)
    {
        var regexCelular = @"^/9\d{8}$/";

        if (Regex.IsMatch(target, regexCelular))
            _errors.Add($"{fildName} is invalid");
    }

    public void Cnpj(string target, string fildName)
    {
        if (!Regex.IsMatch(target,
            @"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}-[0-9]{2}$"))
            _errors.Add($"{fildName} is invalid");
    }

    public void Crm(string target, string fildName)
    {
        var regex = @"^[0-9]{6}$";
        if (!Regex.IsMatch(target, regex))
            _errors.Add($"{fildName} is invalid");
    }

    public void CrmUf(string target, string fildName)
    {
        // TODO: arrumar
        if (!Regex.IsMatch(target, @"^[A-Z]{2}$"))
            _errors.Add($"{fildName} is invalid");
    }

    public void NumeroCasa(string target, string fildName)
    {
        if (!Regex.IsMatch(target, @"^[0-9]{1,8}([A-Z]{1,10})?$"))
            _errors.Add($"{fildName} is invalid");
    }


    public void isInEnum<T>(T target, Type type, string fildName)
    {
        if (!Enum.IsDefined(type, target!))
            _errors.Add($"{fildName} is invalid");
    }

    public void Email(string target, string fildName)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                _errors.Add($"{fildName} is invalid");
                return;
            }

            var addr = new MailAddress(target);
        }
        catch
        {
            _errors.Add($"{fildName} is invalid");
        }
    }

    public void Query(int limit, int page)
    {
        if (limit < 1 || page < 0)
            _errors.Add("Invalid query parameters");
    }

    public virtual void Check()
    {
        if (_errors.Count > 0)
        {
            throw new DomainException(_logMessage, _errors);
        }
    }

    public void LoadValueObjectValidations(
        DomainValidator validations)
    {
        var errors = validations._errors2;
        _errors2 = _errors2.Concat(errors).ToDictionary(x => x.Key, x => x.Value);
    }
}