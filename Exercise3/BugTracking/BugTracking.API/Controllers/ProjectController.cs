using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BugTracking.API.Domain.Models;
using BugTracking.API.Domain.Services;
using BugTracking.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BugTracking.API.Controllers
{
    [Route("/api/project")]
    [Produces("application/json")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all projects.
        /// </summary>
        /// <returns>List of projects.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectResource>), 200)]
        public async Task<IEnumerable<ProjectResource>> ListAsync()
        {
            var projects = await _projectService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);

            return resources;
        }

        /// <summary>
        /// Saves a new project.
        /// </summary>
        /// <param name="resource">Project data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProjectResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProjectResource resource)
        {
            var project = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.SaveAsync(project);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }

        /// <summary>
        /// Updates an existing project according to an identifier.
        /// </summary>
        /// <param name="id">Project identifier.</param>
        /// <param name="resource">Updated project data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProjectResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProjectResource resource)
        {
            var project = _mapper.Map<SaveProjectResource, Project>(resource);
            var result = await _projectService.UpdateAsync(id, project);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        }

        /// <summary>
        /// Deletes a given project according to an identifier.
        /// </summary>
        /// <param name="id">Project identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);
            return Ok(projectResource);
        } 
    }
}