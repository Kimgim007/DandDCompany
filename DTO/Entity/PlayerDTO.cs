using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class PlayerDTO
    {
        public PlayerDTO() { }
        public PlayerDTO(Guid PlayerId,string PlayerName) 
        {
            this.PlayerId = PlayerId;
            this.PlayerName = PlayerName;
        }
        public Guid PlayerId { get; set; }
        public string? PlayerName { get; set; }
    }
}
