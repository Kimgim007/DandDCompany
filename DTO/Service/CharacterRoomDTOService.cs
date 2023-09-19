using DataBase.DbEntity;
using DataBase.MyDbContext;
using DataBase.Repository;
using DTO.Entity;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service
{
    public class CharacterRoomDTOService : ICharacterRoomDTOService

    {
        private CharacterRoomRepository _characterRoomRepository; 

        public CharacterRoomDTOService(CharacterRoomRepository characterRoomRepository)
        {
            this._characterRoomRepository = characterRoomRepository;
        }
        public async Task Add(CharacterRoomDTO CharacterRoomDTO)
        {
            await _characterRoomRepository.Add(Mapnig.Maping.map(CharacterRoomDTO));
        }

        public Task<CharacterRoomDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CharacterRoomDTO> GetFromCharacterIdandRoomId(Guid CharacterId, Guid RoomId)
        {
            var accountRoom = Mapnig.Maping.map(await _characterRoomRepository.GetFromCharacterIdandRoomId(CharacterId, RoomId));
            return accountRoom;
        }

        public Task<List<CharacterRoomDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id)
        {
            await _characterRoomRepository.Remove(id);
        }

        public async Task RemoveByAccountIdRoomId(Guid CharacterId,Guid RoomId)
        {
            await _characterRoomRepository.RemoveByAccountIdRoomId(CharacterId, RoomId);
        }

        public async Task Update(CharacterRoomDTO CharacterRoomDTO)
        {
          await  _characterRoomRepository.Update(Mapnig.Maping.map(CharacterRoomDTO));
        }
    }
}
