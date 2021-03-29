using BugTracking.API.Domain.Models;

namespace BugTracking.API.Domain.Services.Communication
{
    public class ProjectResponse : BaseResponse<Project>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="project">Saved project.</param>
        /// <returns>Response.</returns>
        public ProjectResponse(Project project) : base(project)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProjectResponse(string message) : base(message)
        { } 
    }
}