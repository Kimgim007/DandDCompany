using DataBase.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class GameCharacterDTO
    {
        public GameCharacterDTO() { }

        public GameCharacterDTO(Guid gameCharacterId, string gameCharacterName, GameClassDTO GameClassDTO, GameAccountDTO gameAccountDTO)
        {
            this.GameCharacterId = gameCharacterId;
            this.GameCharacterName = gameCharacterName;
            this.GameClassDTO = GameClassDTO;
            this.gameAccountDTO = gameAccountDTO;
        }
        public Guid GameCharacterId { get; set; }
        public string? GameCharacterName { get; set; }

     
        public GameClassDTO GameClassDTO { get; set; }

        public GameAccountDTO gameAccountDTO { get; set; }

    }
}
