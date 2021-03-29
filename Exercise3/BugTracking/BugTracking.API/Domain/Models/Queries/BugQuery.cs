namespace BugTracking.API.Domain.Models.Queries
{
    public class BugQuery : Query
    {        
        public int? _bugId { get; set; }

        public BugQuery(int? bugId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            _bugId = bugId;
        }
    }
}