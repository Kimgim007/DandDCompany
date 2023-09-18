using DataBase.DbEntity;
using DataBase.MyDbContext;
using DataBase.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class AccountRepository : IRepository<Account>
    {
        private DataContext _dataContext;
        public AccountRepository()
        {

        }
        public AccountRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(Account Account)
        {
            _dataContext.Accounts.Add(Account);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Account> GetGameAccountForEmail(string Email)
        {
            var GameAccount = await _dataContext.Accounts.Include(q=>q.gameCharacters).FirstOrDefaultAsync(q => q.Email == Email);
            return GameAccount;
        }

        public async Task<Account> Get(Guid id)
        {
           var gameAccount = await _dataContext.Accounts.FirstOrDefaultAsync(q=>q.AccountId == id);
            return gameAccount;
        }

        public async Task<Account> GetFromEmail(string Email)
        {
            var GameAccount = await _dataContext.Accounts.FirstOrDefaultAsync(q=>q.Email == Email);
            return GameAccount;
        }

        public Task<List<Account>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Account obj)
        {
            throw new NotImplementedException();
        }
    }
}
