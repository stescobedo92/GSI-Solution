using System.ComponentModel.DataAnnotations;

namespace BugTracking.API.Resources
{
    public class SaveProjectResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [MaxLength(256)]
        public string Description { get; set; }
    }
}