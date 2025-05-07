using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Repositories
{
    public class MemberRepository(AppDbContext context) : IMemberRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Member>> Get(CancellationToken cancellationToken)
        {
            var members = await _context.Members.ToListAsync(cancellationToken);
            return members ?? Enumerable.Empty<Member>();
        }

        public async Task<Member> GetById(int memberId, CancellationToken cancellationToken)
        {
            var member = await _context.Members.FindAsync(memberId, cancellationToken);

            if (member is null)
                throw new InvalidOperationException("Member not found");

            return member;
        }

        public async Task<Member> Add(Member member, CancellationToken cancellationToken)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            await _context.Members.AddAsync(member, cancellationToken);
            return member;
        }

        public void Update(Member member, CancellationToken cancellationToken)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            _context.Members.Update(member);
        }

        public async Task<Member> DeleteMember(int memberId, CancellationToken cancellationToken)
        {
            var member = await GetById(memberId, cancellationToken);

            if (member is null)
                throw new InvalidOperationException("Member not found");

            _context.Members.Remove(member);
            return member;
        }
    }
}
