using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Models
{
    [Owned]
    public class FullName
    {
        [Column("First_Name",TypeName ="varchar(50)")]
        [RegularExpression("^[a-zA-Z]{3,25}$",
            ErrorMessage = "First Name Should be in alphabets within the range of 5,25")]
        [DefaultValue("")]
        [Required]
        public string FirstName { get; set; }
        [Column("Middle_Name", TypeName = "varchar(50)")]
        [DefaultValue("")]
        public string MiddleName { get; set; }
        [Column("Last_Name", TypeName = "varchar(50)")]
        [RegularExpression("^[a-zA-Z]{3,25}$",
           ErrorMessage = "Last Name Should be in alphabets within the range of 3,25")]
        [DefaultValue("")]
        [Required]
        public string LastName { get; set; }
    }
}
