using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Repositories;
using BugTracking.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.API.Persistence.Repositories
{
    public class UserRepository : BaseRepository,IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        async Task<IEnumerable<User>> IUserRepository.ListAsync()
        {
           return await _context.Users.AsNoTracking().ToListAsync(); 
        }
    }
}