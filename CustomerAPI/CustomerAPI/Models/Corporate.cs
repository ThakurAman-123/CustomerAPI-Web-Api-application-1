using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Models
{
    public enum CompanyType { GOVT,PUBLIC,PRIVATE,NGO}
    [Table("Corporate")]
    public class Corporate:Customer
    {
        [Column("Company_Type")]
        [EnumDataType(typeof(CompanyType))]
        public CompanyType CompanyType { get; set; }
    }
}
