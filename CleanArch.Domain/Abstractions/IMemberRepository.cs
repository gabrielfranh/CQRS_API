using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> Get(CancellationToken cancellationToken);
        Task<Member> GetById(int memberId, CancellationToken cancellationToken);
        Task<Member> Add(Member member, CancellationToken cancellationToken);
        void Update(Member member, CancellationToken cancellationToken);
        Task<Member> DeleteMember(int memberId, CancellationToken cancellationToken);
    }
}