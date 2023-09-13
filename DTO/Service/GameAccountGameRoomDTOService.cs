using DataBase.DbEntity;
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
    public class GameAccountGameRoomDTOService : IGameAccountGameRoomDTOService
    {
        private GameAccountGameRoomRepository _gameAccountGameRoomRepository; 
        public GameAccountGameRoomDTOService(GameAccountGameRoomRepository gameAccountGameRoomRepository)
        {
            this._gameAccountGameRoomRepository = gameAccountGameRoomRepository;
        }
        public async Task Add(GameAccountGameRoomDTO gameAccountGameRoomDTO)
        {
            await _gameAccountGameRoomRepository.Add(Mapnig.Maping.map(gameAccountGameRoomDTO));
        }

        public Task<GameAccountGameRoomDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameAccountGameRoomDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameAccountGameRoomDTO gameAccountGameRoomDTO)
        {
            throw new NotImplementedException();
        }
    }
}
