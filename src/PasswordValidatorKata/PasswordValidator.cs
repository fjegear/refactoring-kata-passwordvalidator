using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordValidatorKata
{
    public class PasswordValidator : IPasswordValidator
    {
        private readonly List<IValidationRule> rules = new List<IValidationRule>()
        {
            new RegexValidationRule("[A-Z]", "Password should have at least one uppercase character"),
            new RegexValidationRule("[a-z]", "Password should have at least one lowercase character"),
            new RegexValidationRule("[0-9]", "Password should have at least one digit"),
            new RegexValidationRule("[!”#\\$%&'\\(\\)\\*\\+,-\\.\\:;<=>\\?@\\[/\\]^_`\\{\\|\\}~]", "Password should have at least one special character"),
            new RegexValidationRule(".{12,}", "Password should be at least 12 characters long"),
            new RegexValidationRule("\\s+$", "Password should not have any whitespaces"),
        };

        public ValidationResult Validate(ValidationData validationData)
        {
            var messages = rules
                .Where(rule => !rule.Validate(validationData.Password))
                .Select(rule => rule.Message).ToList();

            return new ValidationResult(!messages.Any(), messages);
        }
    }
}
