using System.ComponentModel.DataAnnotations;

namespace Job_portal_in_Core.Models
{
    public class Admin

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? admin_email { get; set; }
        [Required]
        public string? admin_password { get; set; }
    }
}
