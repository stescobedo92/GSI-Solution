using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Services.Communication;

namespace BugTracking.API.Domain.Services
{
    public interface IProjectService
    {
         
        Task<IEnumerable<Project>> ListAsync();
        Task<ProjectResponse> SaveAsync(Project project);
        Task<ProjectResponse> UpdateAsync(int id, Project project);
        Task<ProjectResponse> DeleteAsync(int id);
    }
}