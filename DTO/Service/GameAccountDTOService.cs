using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Repository;
using DTO.Entity;

namespace DTO.Service
{
    public class GameAccountDTOService:IGameAccountDTOService
    {
        private GameAccountRepository _gameAccountRepository;
        public GameAccountDTOService(GameAccountRepository gameAccountRepository)
        {
            this._gameAccountRepository = gameAccountRepository;   
        }

        public async Task Add(GameAccountDTO gameAccountDTO)
        {
           await _gameAccountRepository.Add(Mapnig.Maping.map(gameAccountDTO));
        }

        public Task<GameAccountDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameAccountDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameAccountDTO gameAccountDTO)
        {
            throw new NotImplementedException();
        }
    }
}
