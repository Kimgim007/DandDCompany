using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class GameAccountGameRoom
    {
        [Key]
        public Guid GameAccountGameRoomId { get; set; }

        public Guid GameAccountId { get; set; }
        public GameAccount GameAccount { get; set; }

        public Guid GameRoomId { get; set; }
        public GameRoom GameRoom { get; set; }

        public Guid GameCharacterId { get; set; }
        public GameCharacter GameCharacter { get; set; }
        public bool Pass { get; set; } 
    }
}
