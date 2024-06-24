using MO_EDU.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MO_EDU.DTO
{
    public class CourseDTO
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int AdminID { get; set; }

    }
}
