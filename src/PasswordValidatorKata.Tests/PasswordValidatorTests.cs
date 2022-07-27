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

        [Theory]
        [InlineData("userp@ssw0rd", "Password should have at least one uppercase character")]
        [InlineData("USERP@SSW0RD", "Password should have at least one lowercase character")]
        [InlineData("UserP@ssword", "Password should have at least one digit")]
        [InlineData("UserPassw0rd", "Password should have at least one special character")]
        [InlineData("UserP@sw0rd", "Password should be at least 12 characters long")]
        [InlineData("User   P@ss w0rd", "Password should not have any whitespaces")]
        public void Should_not_validate_When(string password, string message)
        {
            //Arrange
            var validatioData = new ValidationData(password);

            //Act
            var result = _passwordValidator.Validate(validatioData);

            //Assert
            result.IsValid.Should().BeFalse();
            result.Messages.Should().Contain(message);
        }
    }
}
