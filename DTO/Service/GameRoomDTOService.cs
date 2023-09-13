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

        public async Task<GameRoomDTO> Get(Guid id)
        {
           var GameRoom = await _gameRoomRepository.Get(id);
            var GameRoomSort = Maping.map(GameRoom);

            return GameRoomSort;

        }

        public async Task<List<GameRoomDTO>> GetAll()
        {
           var gameRooms = await _gameRoomRepository.GetAll();
            var gameRoomsSort = gameRooms.Select(q=>Maping.map(q)).ToList();
            return gameRoomsSort;
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
