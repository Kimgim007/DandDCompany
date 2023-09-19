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
    public class CharacterRepository : IRepository<Character>
    {
        private DataContext _dataContext;
        public CharacterRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task Add(Character character)
        {
          _dataContext.Characters.Add(character);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Character> Get(Guid id)
        {
           var character = await _dataContext.Characters.Include(q=>q.Account).FirstOrDefaultAsync(q=>q.CharacterId== id);
            return character;
        }

        public Task<List<Character>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Character character)
        {
            var characterFromDataBase = await _dataContext.Characters.FirstOrDefaultAsync(q=>q.CharacterId == character.CharacterId);
            if (characterFromDataBase != null)
            {
                characterFromDataBase.CharacterName = character.CharacterName;
                characterFromDataBase.DiscriptionChar = character.DiscriptionChar;
                characterFromDataBase.GameClass = character.GameClass;
                _dataContext.SaveChanges();
            }        
        }
    }
}
