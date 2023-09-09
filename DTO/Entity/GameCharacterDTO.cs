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
     
        public GameCharacterDTO(Guid gameCharacterId,string gameCharacterName) 
        {
            this.GameCharacterId = gameCharacterId;
            this.GameCharacterName = gameCharacterName;
           
        }
        public Guid GameCharacterId { get; set; }
        public string? GameCharacterName { get; set; }

     

    }
}
