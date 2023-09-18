using DTO.Entity;
namespace DandDCompany.Models
{
    public class GameAccountViewModel
    {

        public Guid GameAccountId { get; set; }
        public string Email { get; set; }

        public List<GameCharacterDTO> gameCharacterDTOs { get; set; }
    }
}
