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

        public Task<GameClassDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameClassDTO>> GetAll()
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
