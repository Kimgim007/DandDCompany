using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class CharacterRoom
    {
        [Key]
        public Guid CharacterRoomId { get; set; }

        public Guid? CharacterId { get; set; }
        public Character Character { get; set; }

        public Guid? RoomId { get; set; }
        public Room Room { get; set; }
 
        public bool Pass { get; set; } 
    }
}
