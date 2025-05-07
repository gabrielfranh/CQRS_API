using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;

namespace CleanArch.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork, IDisposable
    {
        private IMemberRepository? _memberRepository;
        private readonly AppDbContext _context = context;

        public IMemberRepository MemberRepository {
            get
            {
                return _memberRepository = _memberRepository ?? 
                    new MemberRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose() => _context.Dispose();
    }
}
