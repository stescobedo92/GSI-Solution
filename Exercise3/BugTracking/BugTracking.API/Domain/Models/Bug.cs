using System.Collections.Generic;

namespace BugTracking.API.Domain.Models
{
    public class Bug
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get;set; }

        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}