using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordValidatorKata
{
    public class RegexValidationRule : IValidationRule
    {
        public string Regex { get; init; }
        public string Message { get; init; }

        public RegexValidationRule(string regex, string message)
        {
            Regex = regex;
            Message = message;
        }

        public bool Validate(string input)
        {
            return new Regex(Regex).IsMatch(input);
        }
    }
}
