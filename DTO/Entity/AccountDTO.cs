using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class AccountDTO
    {
        public AccountDTO() { }
        public AccountDTO(Guid MicrosoftAccountId,string MicrosoftAccountName)
        {
            this.MicrosoftAccountId = MicrosoftAccountId;
            this.MicrosoftAccountName = MicrosoftAccountName;
            
        }

        public Guid AccountDTOId { get; set; }
        public Guid MicrosoftAccountId { get; set; }

        public string MicrosoftAccountName { get; set; }

        public List<RoomDTO> Rooms { get; set; } = new List<RoomDTO>();
        public List<CharacterDTO>? CharacterDTOs { get; set; } = new List<CharacterDTO>();

    
    }
}
