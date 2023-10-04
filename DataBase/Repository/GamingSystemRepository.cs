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
    public class GamingSystemRepository: IRepository<GamingSystem>
    {
        private DataContext _dataContext;
        public GamingSystemRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(GamingSystem gamingSystem)
        {
             _dataContext.GamingSystems.Add(gamingSystem);
            await _dataContext.SaveChangesAsync();
        }

        public Task<GamingSystem> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GamingSystem>> GetAll()
        {
           var gamingSystems = await _dataContext.GamingSystems.Include(q=>q.GameClasses).ToListAsync();
            return gamingSystems;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GamingSystem obj)
        {
            throw new NotImplementedException();
        }
    }
}
