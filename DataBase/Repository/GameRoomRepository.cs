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

        public Task<GameRoom> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameRoom>> GetAll()
        {
            throw new NotImplementedException();
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
