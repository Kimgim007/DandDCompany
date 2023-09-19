using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class CharacterRoomDTO
    {
        public CharacterRoomDTO() { }


        public CharacterRoomDTO(CharacterDTO Character, RoomDTO RoomDTO, bool PassDTO)
        {
           
            this.CharacterDTO = Character;
            this.RoomDTO = RoomDTO;

            this.PassDTO = PassDTO;
        }

        public CharacterRoomDTO(Guid characterRoomDTOId, CharacterDTO Character, RoomDTO RoomDTO,bool PassDTO)
        {

            this.CharacterRoomDTOId= characterRoomDTOId;
            this.CharacterDTO = Character;
            this.RoomDTO = RoomDTO;    
            
            this.PassDTO = PassDTO;
        }

        public Guid CharacterRoomDTOId { get; set; }

        public RoomDTO RoomDTO { get; set; }
        public CharacterDTO CharacterDTO { get; set; }

        public bool PassDTO { get; set; }
    }
}
