using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;

namespace BugTracking.API.Domain.Repositories
{
    public interface IBugRepository
    {
        Task<IEnumerable<Bug>> ListAsync();
        Task AddAsync(Bug bug);
        Task<Bug> FindByIdAsync(int id);
        void Update(Bug bug);
        void Remove(Bug bug); 
    }
}