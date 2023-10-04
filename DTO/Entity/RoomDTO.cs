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
        public RoomDTO(Guid RoomId,AccountDTO AdminAccountDTO, string RoomName, GamingSystemDTO gamingSystemDTO)
        {
            this.RoomId = RoomId;            
            this.AdminAccountDTO = AdminAccountDTO;
            this.RoomName = RoomName;
            this.GamingSystemDTO= gamingSystemDTO;
        }

   
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }

        public AccountDTO AdminAccountDTO { get; set; }
        public GamingSystemDTO GamingSystemDTO { get; set; }

        public List<CharacterDTO> CharacterDTOAnswerTrue { get; set; } = new List<CharacterDTO>();
        public List<CharacterDTO> CharacterDTOAnswerFalse { get; set; } = new List<CharacterDTO>();

        public List<CharacterRoomDTO> AccountRoomsDTO { get; set; } = new List<CharacterRoomDTO>();

      
    }
}
