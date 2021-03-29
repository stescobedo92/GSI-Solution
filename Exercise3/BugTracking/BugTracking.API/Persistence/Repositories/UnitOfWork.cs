using System.Threading.Tasks;
using BugTracking.API.Domain.Repositories;
using BugTracking.API.Persistence.Contexts;

namespace BugTracking.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        async Task IUnitOfWork.CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}