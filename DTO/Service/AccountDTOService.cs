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
    public class AccountDTOService:IAccountDTOService
    {
        private AccountRepository _accountRepository;
        public AccountDTOService(AccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;   
        }

        public async Task Add(AccountDTO AccountDTO)
        {
           await _accountRepository.Add(Mapnig.Maping.map(AccountDTO));
        }

        public async Task<AccountDTO> GetGameAccountForEmail(string Email)
        {
            var Account = await _accountRepository.GetGameAccountForEmail(Email);
            var AccountSort = Mapnig.Maping.map(Account);
            return AccountSort;
        }

        public async Task<AccountDTO> Get(Guid id)
        {
            var Account = await _accountRepository.Get(id);
            var AccountSort = Mapnig.Maping.map(Account);
            return AccountSort;
        }

        public async Task<AccountDTO> GetFromEmail(string Email)
        {
            var Account = await _accountRepository.GetFromEmail(Email);
            var AccountSort = Mapnig.Maping.map(Account);
            return AccountSort;

        }
        public Task<List<AccountDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AccountDTO AccountDTO)
        {
            throw new NotImplementedException();
        }
    }
}
