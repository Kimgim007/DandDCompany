using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class GamingSystemDTO
    {
        public GamingSystemDTO() { }
        public GamingSystemDTO(string GamingSystemDTOName)
        {
            this.GamingSystemDTOName= GamingSystemDTOName;
        }
        public Guid GamingSystemDTOId { get; set; }
        public string GamingSystemDTOName { get; set; }
        public List<GameClassDTO> GameClassDTOes { get; set; } = new List<GameClassDTO>();

        public List<RoomDTO> Rooms { get; set; } = new List<RoomDTO>();
    }
}
