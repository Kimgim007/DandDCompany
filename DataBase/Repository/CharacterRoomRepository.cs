using DataBase.DbEntity;
using DataBase.MyDbContext;
using DataBase.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class CharacterRoomRepository : IRepository<CharacterRoom>
    {
        private DataContext _dataContext;

        public CharacterRoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(CharacterRoom characterRoom)
        {
            _dataContext.CharacterRooms.Add(characterRoom);
            await _dataContext.SaveChangesAsync();
        }

        public Task<CharacterRoom> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CharacterRoom> GetFromCharacterIdandRoomId(Guid characterId, Guid roomId)
        {
          
            // НЕ работает почему то
            //var gameAccountGameRoom = await _dataContext.GameAccountGameRooms.Where(q =>q.GameAccountId == gameAccountId && q.GameRoomId == gameAccountId).FirstOrDefaultAsync();
            var characterRoom = _dataContext.CharacterRooms.Where(q => q.CharacterId == characterId);
            var characterRoomSort = await characterRoom.FirstOrDefaultAsync(q => q.RoomId == roomId);
            return characterRoomSort;
        }
        public Task<List<CharacterRoom>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task Remove(Guid id)
        {
            var accountRoom = await _dataContext.CharacterRooms.FirstOrDefaultAsync(q => q.CharacterRoomId == id);
            if (accountRoom != null)
            {
                _dataContext.CharacterRooms.Remove(accountRoom);
                _dataContext.SaveChanges();
            }
        }

        public async Task RemoveByAccountIdRoomId(Guid characterId,Guid roomId)
        {
            var characterRoom = _dataContext.CharacterRooms.Where(q => q.CharacterId == characterId);
            var characterRoomSort = await characterRoom.FirstOrDefaultAsync(q => q.RoomId == roomId);
            if (characterRoomSort != null)
            {
                _dataContext.CharacterRooms.Remove(characterRoomSort);
                _dataContext.SaveChanges();
            }
        }

        public async Task Update(CharacterRoom characterRoom)
        {
            var characterRoomFromDataBase = _dataContext.CharacterRooms.Where(q => q.CharacterId == characterRoom.CharacterId);
            var characterRoomSort = await characterRoomFromDataBase.FirstOrDefaultAsync(q => q.RoomId == characterRoom.RoomId);

           
            if (characterRoomSort != null)
            {
                characterRoomSort.CharacterId = characterRoom.CharacterId;
                characterRoomSort.RoomId = characterRoom.RoomId;
              

                characterRoomSort.Pass = characterRoom.Pass;
                _dataContext.SaveChanges();
            }
        }
    }
}
