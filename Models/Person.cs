using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb3Api_V2.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength(100), MinLength(2)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100), MinLength(2)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(15), MinLength(10)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(100), MinLength(4)]
        public string Email { get; set; }

        public virtual List<PersonHobby>? PersonHobbies { get; set; }
    }
}
