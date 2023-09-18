using DandDCompany.Models;
using DTO.Entity;

namespace DandDCompany.Models
{
    public class GameCharacterViewModel
    {
        public GameCharacterViewModel()
        {

        }

        public Guid GameCharacterId { get; set; }
        public string GameCharacterName { get; set; }

        public string DescriptionGameChar { get; set; }

        //public Guid GameClassViewModelId { get; set; }
        //public GameClassViewModel GameClassViewModel { get; set; }

        public List<GameClassDTO> gameClassDTOs { get; set; }

        public Guid GmaeAccountId { get; set; }
    }
}
