using System.ComponentModel.DataAnnotations;

namespace Job_portal_in_Core.Models
{
    public class Country_tbl
    {
        [Key]
        public int cid { get; set; }
        [Required]  
        public string Cname { get; set; }

    }
}
