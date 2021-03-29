using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Services.Communication;

namespace BugTracking.API.Domain.Services
{
    public interface IBugService
    {
         
        Task<IEnumerable<Bug>> ListAsync();
        Task<BugResponse> SaveAsync(Bug bug);
        Task<BugResponse> UpdateAsync(int id, Bug bug);
        Task<BugResponse> DeleteAsync(int id);
    }
}