using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface ICharacterRoomDTOService
    {

        Task Add(CharacterRoomDTO CharacterRoomDTO);
        Task<CharacterRoomDTO> Get(Guid id);
        Task<CharacterRoomDTO> GetFromCharacterIdandRoomId(Guid CharacterId, Guid RoomId);
        Task<List<CharacterRoomDTO>> GetAll();
        Task Update(CharacterRoomDTO CharacterRoomDTO);
        Task Remove(Guid id);
        Task RemoveByAccountIdRoomId(Guid CharacterId, Guid RoomId);

    }
}
