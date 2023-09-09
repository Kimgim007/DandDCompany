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
    public class GroupRepository : IRepository<Group>
    {
        private DataContext _dataContext;
        public GroupRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(Group group)
        {
            _dataContext.Groups.Add(group);
            await _dataContext.SaveChangesAsync();

        }

        public Task<Group> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Group obj)
        {
            throw new NotImplementedException();
        }
    }
}
