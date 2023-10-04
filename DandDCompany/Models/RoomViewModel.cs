using DandDCompany.Models;
using DTO.Entity;

namespace DandDCompany.Models
{
    public class RoomViewModel
    {
        public RoomViewModel() { }

        public Guid GameRoomId { get; set; }
        public string GameRoomName { get; set; }

        public Guid AccountId { get; set; }
        
        public string DiscriptionGameRoom { get; set; }

        public List<GamingSystemDTO> gamingSystemDTOs { get; set; } = new List<GamingSystemDTO>();
      
    }
}
