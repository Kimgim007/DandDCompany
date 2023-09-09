using DataBase.DbEntity;
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
        public Task Add(GameAccount gameAccount)
        {
            throw new NotImplementedException();
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
