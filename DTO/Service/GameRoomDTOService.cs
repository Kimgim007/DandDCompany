using DataBase.Repository;
using DTO.Entity;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Service.Mapnig;
namespace DTO.Service
{
    public class GameRoomDTOService : IGameRoomDTOService
    {
        private GameRoomRepository _gameRoomRepository;
        public GameRoomDTOService(GameRoomRepository groupRepository)
        {
            this._gameRoomRepository = groupRepository;    
        }

        public async Task Add(GameRoomDTO gameRoomDTO)
        {
            await _gameRoomRepository.Add(DTO.Service.Mapnig.Maping.map(gameRoomDTO));
        }

        public Task<GameRoomDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameRoomDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameRoomDTO groupDTO)
        {
            throw new NotImplementedException();
        }
    }
}
