using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;

namespace BugTracking.API.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task AddAsync(Project project);
        Task<Project> FindByIdAsync(int id);
        void Update(Project project);
        void Remove(Project project);   
    }
}