using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteAPI.models
{
    public class login
    {
        [Key]
        public int ?id { get; set; }

        //[Column(TypeName = "varchar(256)")]  
        public string ?username { get; set; } = string.Empty;
        //[Column(TypeName = "varchar(256)")]
        public string ?password { get; set; } = string.Empty; 

    }
}
