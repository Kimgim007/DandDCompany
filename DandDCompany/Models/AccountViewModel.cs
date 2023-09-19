using DTO.Entity;
namespace DandDCompany.Models
{
    public class AccountViewModel
    {
        public AccountViewModel() { }
        public Guid AccountId { get; set; }
        public string Email { get; set; }

        public List<CharacterDTO> gameCharacterDTOs { get; set; }
    }
}
