using System.ComponentModel.DataAnnotations;

namespace BugTracking.API.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }
    }
}