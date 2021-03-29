using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Services;
using BugTracking.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.API.Controllers.Config
{
    [Route("/api/bugs")]
    [Produces("application/json")]
    [ApiController]
    public class BugController : Controller
    {
        private readonly IBugService _bugService;
        private readonly IMapper _mapper;

        public BugController(IBugService bugService, IMapper mapper)
        {
            _bugService = bugService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all bugs.
        /// </summary>
        /// <returns>List of bugs.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BugResource>), 200)]
        public async Task<IEnumerable<BugResource>> ListAsync()
        {
            var bugs = await _bugService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Bug>, IEnumerable<BugResource>>(bugs);

            return resources;
        }

        /// <summary>
        /// Saves a new Bug.
        /// </summary>
        /// <param name="resource">Bug data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BugResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveBugResource resource)
        {
            var bug = _mapper.Map<SaveBugResource, Bug>(resource);
            var result = await _bugService.SaveAsync(bug);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bugResource = _mapper.Map<Bug, BugResource>(result.Resource);
            return Ok(bugResource);
        }

        /// <summary>
        /// Updates an existing Bug according to an identifier.
        /// </summary>
        /// <param name="id">Bug identifier.</param>
        /// <param name="resource">Updated Bug data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BugResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBugResource resource)
        {
            var bug = _mapper.Map<SaveBugResource, Bug>(resource);
            var result = await _bugService.UpdateAsync(id, bug);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bugResource = _mapper.Map<Bug, BugResource>(result.Resource);
            return Ok(bugResource);
        }

        /// <summary>
        /// Deletes a given Bug according to an identifier.
        /// </summary>
        /// <param name="id">Bug identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BugResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _bugService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bugResource = _mapper.Map<Bug, BugResource>(result.Resource);
            return Ok(bugResource);
        }
    }
}