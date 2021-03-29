namespace BugTracking.API.Domain.Models.Queries
{
    public class ProjectQuery : Query
    {
        public int? _projectId { get; set; }

        public ProjectQuery(int? projectId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            _projectId = projectId;
        }
    }
}