using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BugTracking.API.Domain.Models;

namespace BugTracking.API.Resources
{
    public class SaveBugResource
    {      
        [MaxLength(256)]
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get;set; }
        public ICollection<User> Users { get; set; }
    }
}