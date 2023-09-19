using DandDCompany.Models;
using DTO.Entity;

namespace DandDCompany.Models
{
    public class CharacterViewModel
    {
        public CharacterViewModel()
        {

        }

        public Guid CharacterId { get; set; }
        public string CharacterName { get; set; }

        public string DescriptionChar { get; set; }

        public List<GameClassDTO> gameClassDTOs { get; set; }

        public Guid GameClassId { get; set; }
        public Guid AccountId { get; set; }
    }
}
