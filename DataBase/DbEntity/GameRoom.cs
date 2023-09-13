using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class GameRoom
    {
        [Key]            
        public Guid GameRoomId { get; set; }
        public string? GameRoomName { get; set; }

        public string AdminRoomEmail { get; set; }

        public List<GameAccountGameRoom>? GameAccountGameRoom { get; set; } = new List<GameAccountGameRoom>();

    }
}
