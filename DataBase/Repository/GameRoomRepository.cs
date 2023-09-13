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
    public class GameRoomRepository : IRepository<GameRoom>
    {
        private DataContext _dataContext;
        public GameRoomRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(GameRoom gameRoom)
        {
            _dataContext.GameRooms.Add(gameRoom);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<GameRoom> Get(Guid id)
        {
            var gameRoom = await _dataContext.GameRooms.Include(q=>q.GameAccountGameRoom).FirstOrDefaultAsync(q => q.GameRoomId == id);
            return gameRoom;
        }

        public async Task<List<GameRoom>> GetAll()
        {
            var GameRooms = await _dataContext.GameRooms.ToListAsync();
            return GameRooms;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameRoom obj)
        {
            throw new NotImplementedException();
        }
    }
}
