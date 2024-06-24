using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.Model
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID {  get; set; }
        public int role {  get; set; }
        [ForeignKey("UserId")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
