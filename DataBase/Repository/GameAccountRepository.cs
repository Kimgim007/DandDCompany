using DataBase.DbEntity;
using DataBase.MyDbContext;
using DataBase.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class GameAccountRepository : IRepository<GameAccount>
    {
        private DataContext _dataContext;
        public GameAccountRepository()
        {

        }
        public GameAccountRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(GameAccount gameAccount)
        {
            _dataContext.GameAccounts.Add(gameAccount);
            await _dataContext.SaveChangesAsync();
        }

        public Task<GameAccount> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameAccount>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameAccount obj)
        {
            throw new NotImplementedException();
        }
    }
}
