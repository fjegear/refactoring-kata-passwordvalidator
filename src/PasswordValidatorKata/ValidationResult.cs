using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorKata
{
    public class ValidationResult
    {
        public bool IsValid { get; init; }
        public List<string> Messages { get; init; }

        public ValidationResult(bool isValid, List<string> messages)
        {
            IsValid = isValid;
            Messages = messages;
        }
    }
}
