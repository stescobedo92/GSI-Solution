using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Repositories;
using BugTracking.API.Domain.Services;
using BugTracking.API.Domain.Services.Communication;
using BugTracking.API.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace BugTracking.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }
        public async Task<ProjectResponse> DeleteAsync(int id)
        {
            var existingProject = await _projectRepository.FindByIdAsync(id);

            if (existingProject == null)
                return new ProjectResponse("Project not found.");

            try
            {
                _projectRepository.Remove(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProjectResponse($"An error occurred when deleting the project: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            // Here I try to get the project list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the projects from the repository.
            var projects = await _cache.GetOrCreateAsync(CacheKeys.ProjectList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                
                return _projectRepository.ListAsync();
            });
            
            return projects;
        }

        public async Task<ProjectResponse> SaveAsync(Project project)
        {
            try
            {
                await _projectRepository.AddAsync(project);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(project);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProjectResponse($"An error occurred when saving the project: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> UpdateAsync(int id, Project project)
        {
            var existingProject = await _projectRepository.FindByIdAsync(id);

            if (existingProject == null) return new ProjectResponse("Project not found.");

            existingProject.Name = project.Name;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProjectResponse($"An error occurred when updating the project: {ex.Message}");
            }
        }
    }
}