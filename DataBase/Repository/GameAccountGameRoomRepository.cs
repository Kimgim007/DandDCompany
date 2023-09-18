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
    public class GameAccountGameRoomRepository : IRepository<GameAccountGameRoom>
    {
        private DataContext _dataContext;

        public GameAccountGameRoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Add(GameAccountGameRoom gameAccountGameRoom)
        {
            _dataContext.GameAccountGameRooms.Add(gameAccountGameRoom);
            await _dataContext.SaveChangesAsync();
        }

        public Task<GameAccountGameRoom> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GameAccountGameRoom> GetFromAcoountIdandRoomId(Guid gameAccountId, Guid gameRoomId)
        {
            //Severity	Code	Description	Project	File	Line	Suppression State
            //Error CS1061  'IQueryable<GameAccountGameRoom>' does not contain a definition for 'GetAwaiter' and no accessible extension method 'GetAwaiter' accepting a first argument of type 'IQueryable<GameAccountGameRoom>' could be found(are you missing a using directive or an assembly reference ?)	DataBase E:\Prog\D & D\DandDCompany\DataBase\Repository\GameAccountGameRoomRepository.cs   37  Active

            // НЕ работает почему то
            //var gameAccountGameRoom = await _dataContext.GameAccountGameRooms.Where(q =>q.GameAccountId == gameAccountId && q.GameRoomId == gameAccountId).FirstOrDefaultAsync();
            var gameAccountGameRoom = _dataContext.GameAccountGameRooms.Where(q => q.GameAccountId == gameAccountId);
            var gameAccountGameRoomSort = await gameAccountGameRoom.FirstOrDefaultAsync(q => q.GameRoomId == gameRoomId);
            return gameAccountGameRoomSort;
        }
        public Task<List<GameAccountGameRoom>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task Remove(Guid id)
        {
            var gameAccountRoom = await _dataContext.GameAccountGameRooms.FirstOrDefaultAsync(q => q.GameAccountGameRoomId == id);
            if (gameAccountRoom != null)
            {
                _dataContext.GameAccountGameRooms.Remove(gameAccountRoom);
                _dataContext.SaveChanges();
            }
        }

        public async Task RemoveByAccountIdRoomId(Guid gameAccountId,Guid gameRoomId)
        {
            var gameAccountGameRoom = _dataContext.GameAccountGameRooms.Where(q => q.GameAccountId == gameAccountId);
            var gameAccountGameRoomSort = await gameAccountGameRoom.FirstOrDefaultAsync(q => q.GameRoomId == gameRoomId);
            if (gameAccountGameRoomSort != null)
            {
                _dataContext.GameAccountGameRooms.Remove(gameAccountGameRoomSort);
                _dataContext.SaveChanges();
            }
        }

        public async Task Update(GameAccountGameRoom gameAccountGameRoom)
        {
            var gameAccountGameRoomFromDataBase = _dataContext.GameAccountGameRooms.Where(q => q.GameAccountId == gameAccountGameRoom.GameAccountId);
            var gameAccountGameRoomSort = await gameAccountGameRoomFromDataBase.FirstOrDefaultAsync(q => q.GameRoomId == gameAccountGameRoom.GameRoomId);

           
            if (gameAccountGameRoomSort != null)
            {
                gameAccountGameRoomSort.GameAccountId = gameAccountGameRoom.GameAccountId;
                gameAccountGameRoomSort.GameRoomId = gameAccountGameRoom.GameRoomId;
                gameAccountGameRoomSort.GameCharacterId = gameAccountGameRoom.GameCharacterId;

                gameAccountGameRoomSort.Pass = gameAccountGameRoom.Pass;
                _dataContext.SaveChanges();
            }
        }
    }
}
