using DTO.Entity;
using System.Net;

namespace DandDCompany.Models
{
    public class CharacterRoomViewModel
    {

        public CharacterRoomViewModel() { }
        public Guid CharacterRoomId { get; set; }
        
        public RoomDTO RoomDTO { get; set; }
        public List<CharacterDTO> Characters { get; set; } = new List<CharacterDTO>();
    }
}
