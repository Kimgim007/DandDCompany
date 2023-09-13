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
    public class GameCharacterDTOService : IGameCharacterDTOService
    {
        private GameCharacterRepository _gameCharacter;
        public GameCharacterDTOService(GameCharacterRepository gameCharacterRepository)
        {
            this._gameCharacter = gameCharacterRepository;
        }
        public async Task Add(GameCharacterDTO gameCharacterDTO)
        {
            await _gameCharacter.Add(DTO.Service.Mapnig.Maping.map(gameCharacterDTO));
        }

        public async Task<GameCharacterDTO> Get(Guid id)
        {
            var GameChar = await _gameCharacter.Get(id);
            var GameCharSort = Mapnig.Maping.map(GameChar);
            return GameCharSort;
        }

        public Task<List<GameCharacterDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameCharacterDTO playerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
