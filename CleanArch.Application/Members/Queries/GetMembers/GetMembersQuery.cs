using MediatR;

namespace CleanArch.Application.Members.Queries.GetMembers
{
    public class GetMembersQuery : IRequest<IEnumerable<GetMembersResponse>>
    {
    }
}
