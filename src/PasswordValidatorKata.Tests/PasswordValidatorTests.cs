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
        [Theory]
        [InlineData("userp@ssw0rd", false, "Password should have at least one uppercase character")]
        [InlineData("USERP@SSW0RD", false, "Password should have at least one lowercase character")]
        [InlineData("UserP@ssword", false, "Password should have at least one digit")]
        [InlineData("UserPassw0rd", false, "Password should have at least one special character")]
        [InlineData("UserP@sw0rd", false, "Password should be at least 12 characters long")]
        [InlineData("User   P@ss w0rd", false, "Password should not have any whitespaces")]
        [InlineData("userpasword", false,
            "Password should have at least one uppercase character;" +
            "Password should have at least one digit;" +
            "Password should have at least one special character;" +
            "Password should be at least 12 characters long")]
        [InlineData("UserP@ssw0rd", true, null)]
        public void Should_validate_When(string password, bool valid, string messageString)
        {
            //Arrange
            var passwordValidator = new PasswordValidator();
            var validationData = new ValidationData(password);
            var messages = messageString is not null ? messageString.Split(';') : Enumerable.Empty<string>();

            //Act
            var result = passwordValidator.Validate(validationData);

            //Assert
            result.IsValid.Should().Be(valid);
            result.Messages.Should().BeEquivalentTo(messages);
        }
    }
}
