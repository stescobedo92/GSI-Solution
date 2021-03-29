using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Repositories;
using BugTracking.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.API.Persistence.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task<Project> FindByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.AsNoTracking().ToListAsync();
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }
    }
}