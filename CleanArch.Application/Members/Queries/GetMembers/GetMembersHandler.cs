using AutoMapper;
using CleanArch.Domain.Abstractions;
using MediatR;

namespace CleanArch.Application.Members.Queries.GetMembers
{
    public class GetMembersHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetMembersQuery, IEnumerable<GetMembersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<GetMembersResponse>> Handle(GetMembersQuery query, CancellationToken cancellationToken)
        {
            var members = await _unitOfWork.MemberRepository.Get(cancellationToken);
            return _mapper.Map<IEnumerable<GetMembersResponse>>(members);
        }
    }
}
