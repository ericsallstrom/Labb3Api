using System.ComponentModel.DataAnnotations;

namespace Labb3Api_V2.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }

        [Required]
        [StringLength(75), MinLength(1)]
        public string Title { get; set; }

        [StringLength(300), MinLength(1)]
        public string Description { get; set; }

        public virtual ICollection<PersonHobby>? PersonHobbies { get; set; }
        public virtual ICollection<WebLink>? WebLinks { get; set; }
    }
}
