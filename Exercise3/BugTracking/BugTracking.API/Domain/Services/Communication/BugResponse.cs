using BugTracking.API.Domain.Models;

namespace BugTracking.API.Domain.Services.Communication
{
    public class BugResponse : BaseResponse<Bug>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="bug">Saved bug.</param>
        /// <returns>Response.</returns>
        public BugResponse(Bug bug) : base(bug)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BugResponse(string message) : base(message)
        { } 
    }
}