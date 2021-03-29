using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Repositories;
using BugTracking.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.API.Persistence.Repositories
{
    public class BugRepository : BaseRepository, IBugRepository
    {
        public BugRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Bug bug)
        {
            await _context.Bugs.AddAsync(bug);
        }

        public async Task<Bug> FindByIdAsync(int id)
        {
            return await _context.Bugs.FindAsync(id);
        }

        public async Task<IEnumerable<Bug>> ListAsync()
        {
            return await _context.Bugs.AsNoTracking().ToListAsync();
        }

        public void Remove(Bug bug)
        {
            _context.Bugs.Remove(bug);
        }

        public void Update(Bug bug)
        {
            _context.Bugs.Update(bug);
        }
    }
}