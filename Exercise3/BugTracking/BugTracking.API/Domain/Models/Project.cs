using System.Collections.Generic;
namespace BugTracking.API.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get;set; }

        public ICollection<Bug> Bugs { get;set;}
    }
}