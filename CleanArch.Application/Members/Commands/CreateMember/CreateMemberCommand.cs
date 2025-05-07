using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Commands.CreateMember
{
    public class CreateMemberCommand : IRequest<CreateMemberResponse>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}
