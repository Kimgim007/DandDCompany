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
    public class GameClassRepository : IRepository<GameClass>
    {
        private DataContext _dataContext;

        public GameClassRepository(DataContext dataContext)
        {
           this._dataContext = dataContext;
        }

        public async Task Add(GameClass _class)
        {
            _dataContext.Add(_class);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<GameClass> Get(Guid id)
        {
            var gameClass = await _dataContext.GameClasss.FirstOrDefaultAsync(q => q.GameClassId == id);
            return gameClass;
        }

        public async Task<List<GameClass>> GetAll()
        {
            var gameClasss = await _dataContext.GameClasss.ToListAsync();
            return gameClasss;


        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameClass obj)
        {
            throw new NotImplementedException();
        }
    }
}
