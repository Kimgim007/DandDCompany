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
    public class PlayerRepository : IRepository<Player>
    {
        private DataContext _dataContext;
        public PlayerRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task Add(Player player)
        {
          _dataContext.Players.Add(player);
            await _dataContext.SaveChangesAsync();
        }

        public Task<Player> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Player obj)
        {
            throw new NotImplementedException();
        }
    }
}
