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
        };

        public ValidationResult Validate(ValidationData validationData)
        {
            var messages = new List<string>();

            foreach (var rule in rules)
            {
                if (!rule.Validate(validationData.Password))
                {
                    messages.Add(rule.Message);
                }
            }

            return new ValidationResult(!messages.Any(), messages);
        }
    }
}
