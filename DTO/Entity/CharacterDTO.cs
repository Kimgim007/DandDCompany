using DataBase.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class CharacterDTO
    {
        public CharacterDTO() { }

        public CharacterDTO(Guid CharacterId, string CharacterName,string? DescriptionChar, GameClassDTO GameClassDTO, AccountDTO AccountDTO)
        {
            this.CharacterId = CharacterId;
            this.CharacterName = CharacterName;
            this.GameClassDTO = GameClassDTO;
            this.AccountDTO = AccountDTO;
            this.DescriptionChar = DescriptionChar;
        }
        public Guid CharacterId { get; set; }

        public string? CharacterName { get; set; }
        public string? DescriptionChar { get; set; }

     
        public GameClassDTO GameClassDTO { get; set; }
        public AccountDTO AccountDTO { get; set; }

        public List<CharacterRoomDTO> CharacterRoomDTO { get; set; } = new List<CharacterRoomDTO>();

    }
}
