using System.Text.RegularExpressions;

namespace PasswordValidatorKata
{
    public interface IValidationRule
    {
        string Message { get; init; }
        bool Validate(string input);
    }
}