using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb3Api_V2.Models
{
    public class PersonHobby
    {
        [Key]
        public int PersonHobbyId { get; set; }

        [ForeignKey("Person")]
        public int FkPersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("Hobby")]
        public int FkHobbyId { get; set; }
        public Hobby Hobby { get; set; }
    }
}
