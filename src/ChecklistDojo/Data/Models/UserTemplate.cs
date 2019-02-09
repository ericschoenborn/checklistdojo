using System.ComponentModel.DataAnnotations;

namespace ChecklistDojo.Data.Models
{

    public class UserTemplate
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Json { get; set; }
    }
}