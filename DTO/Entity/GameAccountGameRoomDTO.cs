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

        public GameAccountGameRoomDTO( GameAccountDTO gameAccountDTO, GameRoomDTO gameRoomDTO,bool PassDTO,GameCharacterDTO gameCharacter)
        {
        
            this.GameAccountDTO = gameAccountDTO;
            this.GameRoomDTO = gameRoomDTO;
            this.PassDTO = PassDTO;
            this.GameCharacter = gameCharacter;
        }

        public GameAccountDTO GameAccountDTO { get; set; }
        public GameRoomDTO GameRoomDTO { get; set; }
        public GameCharacterDTO GameCharacter { get; set; }

        public bool PassDTO { get; set; }
    }
}
