namespace BugTracking.API.Domain.Models.Queries
{
    public class UserQuery : Query
    {
        public int? _userId { get; set; }

        public UserQuery(int? userId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            _userId = userId;
        }
    }
}