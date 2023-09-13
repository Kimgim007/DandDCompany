using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class GameAccountGameRoomDTO
    {
        public GameAccountGameRoomDTO() { }

        public GameAccountGameRoomDTO( GameAccountDTO gameAccountDTO, GameRoomDTO gameRoomDTO)
        {
        
            this.GameAccountDTO = gameAccountDTO;
            this.GameRoomDTO = gameRoomDTO;
        }

        public GameAccountGameRoomDTO(Guid GameAccountGameRoomId , GameAccountDTO gameAccountDTO,GameRoomDTO gameRoomDTO)
        {
            this.GameAccountGameRoomDTOId = GameAccountGameRoomId;
            this.GameAccountDTO = gameAccountDTO;
            this.GameRoomDTO = gameRoomDTO;
        }
        public Guid GameAccountGameRoomDTOId { get; set; }

        public GameAccountDTO GameAccountDTO { get; set; }
        public GameRoomDTO GameRoomDTO { get; set; }
    }
}
