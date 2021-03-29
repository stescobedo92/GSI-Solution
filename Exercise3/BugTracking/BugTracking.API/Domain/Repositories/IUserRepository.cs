using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;

namespace BugTracking.API.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        void Update(User user);
        void Remove(User user);
    }
}