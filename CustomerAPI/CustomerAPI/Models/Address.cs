using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Models
{
    [Table("Address")]
    public class Address
    {
        [Column("Address_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long AddressId { get; set; }
        [Column("Door_No",TypeName ="varchar(4)")]
        public string DoorNo { get; set; }
        [Column("Street_Name", TypeName = "varchar(100)")]
        public string StreetName { get; set; }
        [Column("City", TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column("State", TypeName = "varchar(50)")]
        public string State { get; set; }
        [Column("Pincode")]
        public long Pincode { set; get; }
        [ForeignKey("Customer")]
        [Column("Account_No_FK")]
        public long AccountNo { get; set; }
        public Customer Customer { get; set; }
    }
}
