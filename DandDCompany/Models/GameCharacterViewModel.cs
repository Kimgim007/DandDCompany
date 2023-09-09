using DandDCompany.Models;
namespace DandDCompany.Models
{
    public class GameCharacterViewModel
    {
        public GameCharacterViewModel()
        {

        }

        public Guid GameCharacterId { get; set; }
        public string GameCharacterName { get; set; }

        public Guid GameClassViewModelId { get; set; }
        public GameClassViewModel GameClassViewModel { get; set; }

     
    }
}
