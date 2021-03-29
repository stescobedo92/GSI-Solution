using System.Collections.Generic;
using BugTracking.API.Domain.Models;

namespace BugTracking.API.Resources
{
    public class BugResource
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get;set; }

        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}