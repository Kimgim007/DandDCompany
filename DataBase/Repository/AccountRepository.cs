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

        public async Task Add(Account account)
        {
            _dataContext.Accounts.Add(account);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Account> GetFromMicrosoftAccountId(Guid MicrosoftAccountId)
        {
            var account = await _dataContext.Accounts.Include(q=>(q.Characters)).FirstOrDefaultAsync(q => q.MicrosoftAccountId == MicrosoftAccountId);
            return account;
        }

        public async Task<Account> Get(Guid id)
        {
           var account = await _dataContext.Accounts.Include(q=>(q.Characters)).FirstOrDefaultAsync(q=>q.AccountId == id);
            return account;
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
