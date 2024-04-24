namespace Labb3Api_V2.Models.DTOs.ResponseDTOs
{
    public class HobbyResponseDTO
    {
        public int HobbyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<WebLinkDTO>? WebLinks { get; set; }
    }
}
