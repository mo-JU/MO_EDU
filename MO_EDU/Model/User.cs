using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MO_EDU.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime creationDate { get; set; }
        [DefaultValue(false)]
        public bool isDeleted { get; set; }


    }
}
