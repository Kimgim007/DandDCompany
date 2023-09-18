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

        public async Task<GameAccountGameRoomDTO> GetFromAcoountIdandRoomId(Guid gameAccountId, Guid gameRoomId)
        {
            var gameAccountGameRoom = Mapnig.Maping.map(await _gameAccountGameRoomRepository.GetFromAcoountIdandRoomId(gameAccountId, gameRoomId));
            return gameAccountGameRoom;
        }

        public Task<List<GameAccountGameRoomDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id)
        {
            await _gameAccountGameRoomRepository.Remove(id);
        }

        public async Task RemoveByAccountIdRoomId(Guid gameAccountId,Guid gameRoomId)
        {
            await _gameAccountGameRoomRepository.RemoveByAccountIdRoomId(gameAccountId, gameRoomId);
        }

        public async Task Update(GameAccountGameRoomDTO gameAccountGameRoomDTO)
        {
          await  _gameAccountGameRoomRepository.Update(Mapnig.Maping.map(gameAccountGameRoomDTO));
        }
    }
}
