namespace PasswordValidatorKata
{
    public interface IPasswordValidator
    {
        ValidationResult Validate(ValidationData validationData);
    }
}