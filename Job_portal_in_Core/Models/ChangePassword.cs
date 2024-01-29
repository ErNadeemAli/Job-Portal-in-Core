using System.ComponentModel.DataAnnotations;

namespace Job_portal_in_Core.Models
{
    public class ChangePassword
    {
        [Key]
        public int id { get; set; }

        public string? oldPassword { get; set; }
        public string? newPassword { get; set; }
        public string? conPassword { get; set; }
    }
}
