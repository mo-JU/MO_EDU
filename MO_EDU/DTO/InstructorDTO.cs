using MO_EDU.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MO_EDU.DTO
{
    public class InstructorDTO
    {
        public int InstructorID { get; set; }
        public string instructorName { get; set; }
        public int age { get; set; }
        public bool gender { get; set; }
        public int EnrollmentID { get; set; }
        public int AdminID { get; set; }
    }
}
