using MO_EDU.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MO_EDU.DTO
{
    public class AdminDTO
    {
        public int AdminID { get; set; }
        public int EnrollmentID { get; set; }
        [Required]
        public string responsibilites { get; set; }
    }
}
