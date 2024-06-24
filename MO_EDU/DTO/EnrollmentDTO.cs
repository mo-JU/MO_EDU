using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.DTOs
{
    public class EnrollmentDTO
    {
        public int EnrollmentID { get; set; }
        public int Role { get; set; }
        public int UserID { get; set; }
    }
}
