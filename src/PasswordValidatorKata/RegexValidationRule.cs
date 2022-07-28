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
        public bool ValidIfMatch { get; init; }
        public string Message { get; init; }

        public RegexValidationRule(string regex, bool validIfMatch, string message)
        {
            Regex = regex;
            ValidIfMatch = validIfMatch;
            Message = message;
        }

        public bool Validate(string input)
        {
            var match = new Regex(Regex).IsMatch(input);
            return ValidIfMatch ? match : !match;
        }
    }
}
