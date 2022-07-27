using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorKata
{
    public class ValidationData
    {
        public string Password { get; init; }

        public ValidationData(string password)
        {
            Password = password;
        }
    }
}
