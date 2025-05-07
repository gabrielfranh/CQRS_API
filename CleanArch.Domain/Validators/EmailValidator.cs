using System.Text.RegularExpressions;
using FluentValidation;

namespace CleanArch.Application.Validators
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(email => email)
            .NotEmpty()
            .WithMessage("Email should not be empty.")
            .MaximumLength(150)
            .WithMessage("The email address cannot be longer than 150 characters.")
            .Must(BeValidEmail)
            .WithMessage("The provided email address is not valid.");
        }

        public bool BeValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);
        }
    }
}
