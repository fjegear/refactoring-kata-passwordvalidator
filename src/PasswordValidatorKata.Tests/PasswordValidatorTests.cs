using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorKata.Tests
{
    public class PasswordValidatorTests
    {
        private readonly PasswordValidator _passwordValidator;

        public PasswordValidatorTests()
        {
            _passwordValidator = new PasswordValidator();
        }

        [Fact]
        public void Should_not_validate_When_password_does_not_have_uppercase()
        {
            //Arrange
            var password = "userp@ss0rd";
            var validatioData = new ValidationData(password);

            //Act
            var result = _passwordValidator.Validate(validatioData);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Messages.Should().Contain("Password should have at least one uppercase character");
        }
    }
}
