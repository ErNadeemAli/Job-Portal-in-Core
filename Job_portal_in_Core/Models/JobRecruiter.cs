using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_portal_in_Core.Models
{
    public class JobRecruiter
    {
        [Key]
        [Column("Company ID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Company is Mandatory")]
        [DisplayName("Company Name")]
        [Column("Company Name")]
        public string? Company_name { get; set; }
        [Required(ErrorMessage ="Company URL is Mandatory")]
        [DisplayName("Company URL")]
        [Column("Company URL")]
        public string? Company_url { get; set; }
        [Required(ErrorMessage ="Company Email is Mandatory")]
        [DisplayName("Company Email")]
        [Column("Company Email")]
        public string? Company_email { get; set; }
        [Required(ErrorMessage ="Company Password is Mandatory")]
        [DisplayName("Company Password")]
        [Column("Company Password")]
        public string? Company_password { get; set; }

        
        public string? usertype= "recruiter";
    }
}
