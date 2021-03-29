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
    public class BugService : IBugService
    {
        private readonly IBugRepository _bugRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public BugService(IBugRepository bugRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _bugRepository = bugRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<BugResponse> DeleteAsync(int id)
        {
            var existingBug = await _bugRepository.FindByIdAsync(id);

            if (existingBug == null) return new BugResponse("Bug not found.");

            try
            {
                _bugRepository.Remove(existingBug);
                await _unitOfWork.CompleteAsync();

                return new BugResponse(existingBug);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BugResponse($"An error occurred when deleting the bug: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Bug>> ListAsync()
        {
            // Here I try to get the bugs list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the bugs from the repository.
            var bugs = await _cache.GetOrCreateAsync(CacheKeys.BugList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                
                return _bugRepository.ListAsync();
            });
            
            return bugs;
        }

        public async Task<BugResponse> SaveAsync(Bug bug)
        {
            try
            {
                await _bugRepository.AddAsync(bug);
                await _unitOfWork.CompleteAsync();

                return new BugResponse(bug);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BugResponse($"An error occurred when saving the bug: {ex.Message}");
            }
        }

        public async Task<BugResponse> UpdateAsync(int id, Bug bug)
        {
            var existingBug = await _bugRepository.FindByIdAsync(id);

            if (existingBug == null) return new BugResponse("Bug not found.");

            existingBug.Id = bug.Id;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new BugResponse(existingBug);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new BugResponse($"An error occurred when updating the bug: {ex.Message}");
            }
        }
    }
}