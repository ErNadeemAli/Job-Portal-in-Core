using System.ComponentModel.DataAnnotations;

namespace Job_portal_in_Core.Models
{
    public class State_tbl
    {
        [Key]
        public int Sid { get; set; }
        [Required]
        public string Sname { get; set; }
    }
}
