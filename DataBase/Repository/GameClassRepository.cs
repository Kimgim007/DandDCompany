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

        public async Task Add(GameClass _gameClass)
        {
            _dataContext.Add(_gameClass);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<GameClass> Get(Guid id)
        {
            var gameClass = await _dataContext.GameClasss.Include(q=>q.GamingSystem).FirstOrDefaultAsync(q => q.GameClassId == id);
            return gameClass;
        }

        public async Task<List<GameClass>> GetAll()
        {
            var gameClasss = await _dataContext.GameClasss.Include(q=>q.GamingSystem).ToListAsync();
            return gameClasss;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(GameClass gameClass)
        {
            var gameClassFromDataBase = await _dataContext.GameClasss.FirstOrDefaultAsync(q => q.GameClassId == gameClass.GameClassId);

            if(gameClassFromDataBase != null)
            {
                gameClassFromDataBase.GameClassName = gameClass.GameClassName;
                gameClassFromDataBase.DescriptionGameClass = gameClass.DescriptionGameClass;

                await _dataContext.SaveChangesAsync();

            }
        }
    }
}
