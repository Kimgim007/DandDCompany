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
        public GameRoomDTO(Guid GroupId, string GameRoomName)
        {
            this.GroupId = GroupId;
            this.GameRoomName = GameRoomName;
        }

        public Guid GroupId { get; set; }
        public string GameRoomName { get; set; }
    }
}
