using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class GameRoomDTO
    {
        public GameRoomDTO() { }
        public GameRoomDTO(Guid GameRoomId, string GameRoomName, string adminRoomEmailDTO)
        {
            this.GameRoomId = GameRoomId;
            this.GameRoomName = GameRoomName;
            this.AdminRoomEmailDTO = adminRoomEmailDTO;
        }

   
        public Guid GameRoomId { get; set; }
        public string GameRoomName { get; set; }

        public string AdminRoomEmailDTO { get; set; }

        public List<GameAccountDTO> AccountDTOsAnswerTrue { get; set; } = new List<GameAccountDTO>();
        public List<GameAccountDTO> AccountDTOsAnswerFalse { get; set; } = new List<GameAccountDTO>();

        public List<GameAccountGameRoomDTO> AccountGameRooms { get; set; } = new List<GameAccountGameRoomDTO>();

      
    }
}
