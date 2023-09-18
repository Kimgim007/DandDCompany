using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Repository;
using DTO.Entity;
using DataBase.DbEntity;

namespace DTO.Service
{
    public class GameAccountDTOService:IGameAccountDTOService
    {
        private AccountRepository _gameAccountRepository;
        public GameAccountDTOService(AccountRepository gameAccountRepository)
        {
            this._gameAccountRepository = gameAccountRepository;   
        }

        public async Task Add(GameAccountDTO gameAccountDTO)
        {
           await _gameAccountRepository.Add(Mapnig.Maping.map(gameAccountDTO));
        }

        public async Task<GameAccountDTO> GetGameAccountForEmail(string Email)
        {
            var gameAccount = await _gameAccountRepository.GetGameAccountForEmail(Email);
            var gameAccountSort = Mapnig.Maping.map(gameAccount);
            return gameAccountSort;
        }

        public async Task<GameAccountDTO> Get(Guid id)
        {
            var gameAccount = await _gameAccountRepository.Get(id);
            var gameAccountSort = Mapnig.Maping.map(gameAccount);
            return gameAccountSort;
        }

        public async Task<GameAccountDTO> GetFromEmail(string Email)
        {
            var gameAccount = await _gameAccountRepository.GetFromEmail(Email);
            var gameAccountSort = Mapnig.Maping.map(gameAccount);
            return gameAccountSort;

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
