using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Models
{
    public enum Gender { MALE,FEMALE,TRANSGENDER}
    [Table("Individual")]
    public class Individual:Customer
    {
        [Column("Gender")]
        [EnumDataType(typeof(Gender))]
        //[ConvertTo(typeof(EnumToStringConverter<Gender>))]
        public Gender Gender { get; set; }
        [Column("DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
        public DateTime DOB { get; set; }
    }
}
