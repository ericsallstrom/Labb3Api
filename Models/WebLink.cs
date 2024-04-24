using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb3Api_V2.Models
{
    public class WebLink
    {
        [Key]
        public int WebLinkId { get; set; }

        [Required]
        [StringLength(200), MinLength(1)]
        public string Url { get; set; }

        [ForeignKey("Hobby")]
        public int FkHobbyId { get; set; }
        public Hobby Hobby { get; set; }
    }
}
