using CleanArch.Application.Validators;
using FluentValidation;

namespace CleanArch.Application.Members.Commands.CreateMember
{
    public class CreateMemberValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberValidator()
        {
            RuleFor(command => command.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("First name cannot be null");

            RuleFor(command => command.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Last name cannot be null");

            RuleFor(command => command.Email).SetValidator(new EmailValidator());
        }
    }
}
