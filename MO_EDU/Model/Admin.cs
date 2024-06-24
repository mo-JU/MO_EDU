using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.Model
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [ForeignKey("EnrollmentID")]
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; }
        public string roles_positions { get; set; }
        [Required]
        public string responsibilites { get; set; }
        public DateTime creationDate { get; set; }
        public bool isDeleted { get; set; }
    }
}
