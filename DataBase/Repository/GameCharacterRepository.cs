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

        public async Task<GameCharacter> Get(Guid id)
        {
           var GameChar = await _dataContext.GameCharacters.FirstOrDefaultAsync(q=>q.GameCharacterId== id);
            return GameChar;
        }

        public Task<List<GameCharacter>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(GameCharacter gameCharacter)
        {
            var gameCharacterFromDataBase = await _dataContext.GameCharacters.FirstOrDefaultAsync(q=>q.GameCharacterId == gameCharacter.GameCharacterId);
            if (gameCharacterFromDataBase != null)
            {
                gameCharacterFromDataBase.GameCharacterName = gameCharacter.GameCharacterName;
                gameCharacterFromDataBase.DiscriptionGameChar = gameCharacter.DiscriptionGameChar;
                gameCharacterFromDataBase.GameClass = gameCharacter.GameClass;
                _dataContext.SaveChanges();
            }
            
        }
    }
}
