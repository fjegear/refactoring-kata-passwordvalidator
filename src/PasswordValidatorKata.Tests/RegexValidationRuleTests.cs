using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorKata.Tests
{
    public class RegexValidationRuleTests
    {
        [Theory]
        [InlineData("[A-Z]", true, "Input", true)]
        [InlineData("[A-Z]", true, "input", false)]
        [InlineData("(\\s)", false, "In put", false)]
        [InlineData("(\\s)", false, "Input", true)]
        public void Should_validate_When(string regex, bool validIfMatch, string input, bool isValid)
        {
            //Arrange
            var rule = new RegexValidationRule(regex, validIfMatch, string.Empty);

            //Act
            var valid = rule.Validate(input);

            //Assert
            valid.Should().Be(isValid);
        }
    }
}
