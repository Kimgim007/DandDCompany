using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class RoomDTO
    {
        public RoomDTO() { }
        public RoomDTO(Guid RoomId, string RoomName, string AdminRoomEmailDTO)
        {
            this.RoomId = RoomId;
            this.RoomName = RoomName;
            this.AdminRoomEmailDTO = AdminRoomEmailDTO;
        }

   
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }

        public string AdminRoomEmailDTO { get; set; }

        public List<CharacterDTO> CharacterDTOAnswerTrue { get; set; } = new List<CharacterDTO>();
        public List<CharacterDTO> CharacterDTOAnswerFalse { get; set; } = new List<CharacterDTO>();

        public List<CharacterRoomDTO> AccountRoomsDTO { get; set; } = new List<CharacterRoomDTO>();

      
    }
}
