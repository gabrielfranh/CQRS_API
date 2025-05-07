using MediatR;

namespace CleanArch.Application.Members.Commands.DeleteMember
{
    public class DeleteMemberCommand : IRequest<DeleteMemberResponse>
    {
        public int Id { get; set; }
    }
}
