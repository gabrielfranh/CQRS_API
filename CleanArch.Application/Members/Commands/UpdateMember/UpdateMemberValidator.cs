using CleanArch.Application.Validators;
using FluentValidation;

namespace CleanArch.Application.Members.Commands.UpdateMember
{
    public class UpdateMemberValidator : AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberValidator()
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
