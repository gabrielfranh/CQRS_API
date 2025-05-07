using FluentValidation;

namespace CleanArch.Application.Members.Commands.DeleteMember
{
    public class DeleteMemberValidator : AbstractValidator<DeleteMemberCommand>
    {
        public DeleteMemberValidator()
        {
            RuleFor(command => command.Id)
                .LessThan(0)
                .WithMessage("Id cannot be less than zero");
        }
    }
}
