using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Account_No")]
        public long AccountNo { get; set; }
        public FullName Name { get; set; }
        [Column("Email",TypeName ="varchar(150)")]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$",
            ErrorMessage = "Email Format Not matching")]
        [DefaultValue("")]
        public string Email { get; set; }
        [Column("ContactNo")]
        [RegularExpression("^([+]\\d{2}[ ])?\\d{10}$",
            ErrorMessage = "Mobile No Format Not matching")]
        public long ContactNo { get; set; }
        [Column("Password", TypeName = "varchar(10)")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
            ErrorMessage = "Password Not matching")]
        [DefaultValue("")]
        public string Password { get; set; }

    }
}
