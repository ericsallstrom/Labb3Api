namespace Labb3Api_V2.Models.DTOs
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<HobbyDTO>? Hobbies { get; set; }
    }
}
