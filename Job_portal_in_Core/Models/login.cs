using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Job_portal_in_Core.Models
{
    public class login
    {
        [Key]
        [DisplayName("Enter Email Id")]
        [Required(ErrorMessage ="Email Mendatory")]
        public string? email { get; set; }
        [Required(ErrorMessage = "PassWord Mendatory")]
        [DisplayName("Enter Password")]
        public string? password { get; set; }
    }
}
