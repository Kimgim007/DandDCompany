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
    public class GameCharacterRepository : IRepository<GameCharacter>
    {
        private DataContext _dataContext;
        public GameCharacterRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task Add(GameCharacter gameCharacter)
        {
          _dataContext.GameCharacters.Add(gameCharacter);
            await _dataContext.SaveChangesAsync();
        }

        public Task<GameCharacter> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameCharacter>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameCharacter obj)
        {
            throw new NotImplementedException();
        }
    }
}
