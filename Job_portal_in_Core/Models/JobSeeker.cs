using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Job_portal_in_Core.Models
{
    public class JobSeeker
    {
        [Key]
       public int id {  get; set; }
        [Required(ErrorMessage = "Name is Mendatory")]
        [DisplayName("Seeker Name")]
        public string? name { get; set; }
        [Required(ErrorMessage = "Gender is Mendatory")]
        [DisplayName("Seeker Gender")]
        public string? gander { get; set; }
        [Required(ErrorMessage = "Email is Mendatory")]
        [DisplayName("Seeker Email")]

        public string? email { get; set; }
        [Required(ErrorMessage = "Password is Mendatory")]
        [DisplayName("Seeker Password")]
        public string? password { get; set; }
        //public string? Image { get; set; }
        


        public string? usertype = "seeker";


    }
}
