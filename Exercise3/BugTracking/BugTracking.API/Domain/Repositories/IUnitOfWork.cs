using System.Threading.Tasks;

namespace BugTracking.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}