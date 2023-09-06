using DataBase.DbEntity;
using DataBase.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class PersonalPageRepository : IRepository<PersonalPage>
    {
        public Task Add(PersonalPage personalPage)
        {
            throw new NotImplementedException();
        }

        public Task<PersonalPage> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonalPage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(PersonalPage obj)
        {
            throw new NotImplementedException();
        }
    }
}
