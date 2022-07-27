using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordValidatorKata
{
    public class PasswordValidator
    {
        private readonly Regex hasUppercaseRegex = new Regex("[A-Z]");

        public ValidationResult Validate(ValidationData validationData)
        {
            var messages = new List<string>();

            if (!GetHasUppercase(validationData))
            {
                messages.Add("Password should have at least one uppercase character");
            }

            return new ValidationResult(!messages.Any(), messages);
        }

        private bool GetHasUppercase(ValidationData validationData)
        {
            return hasUppercaseRegex.Match(validationData.Password).Success;
        }
    }
}
