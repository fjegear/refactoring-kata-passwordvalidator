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
        private readonly List<Func<string, bool>> rules = new List<Func<string, bool>>();
        private readonly Func<string, bool> isUppercase = input => new Regex("[A-Z]").IsMatch(input);
        private readonly Func<string, bool> isLowercase = input => new Regex("[a-z]").IsMatch(input);

        public ValidationResult Validate(ValidationData validationData)
        {
            var messages = new List<string>();

            if (!isUppercase(validationData.Password))
            {
                messages.Add("Password should have at least one uppercase character");
            }
            if (!isLowercase(validationData.Password))
            {
                messages.Add("Password should have at least one lowercase character");
            }

            return new ValidationResult(!messages.Any(), messages);
        }
    }
}
