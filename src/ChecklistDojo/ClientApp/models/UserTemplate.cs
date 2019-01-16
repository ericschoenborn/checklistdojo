using System.ComponentModel.DataAnnotations;

namespace ClientApp.Models
{

    public class UserTemplate : BaseEntity
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Json { get; set; }
    }

}