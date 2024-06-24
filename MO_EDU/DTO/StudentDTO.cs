using MO_EDU.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.DTO
{
    public class StudentDTO
    {
        [Key]
        public int StudentID { get; set; }
        public string studentName { get; set; }
        public int age { get; set; }
        public int EnrollmentID { get; set; }
        public bool gender { get; set; }
    }
}
