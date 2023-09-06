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
    public class ClassRepository : IRepository<Class>
    {
        private DataContext _dataContext;

        public ClassRepository(DataContext dataContext)
        {
           this._dataContext = dataContext;
        }

        public async Task Add(Class _class)
        {
            _dataContext.Add(_class);
            await _dataContext.SaveChangesAsync();
        }

        public Task<Class> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Class>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Class obj)
        {
            throw new NotImplementedException();
        }
    }
}
