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

        public Task<List<GameAccountGameRoom>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GameAccountGameRoom obj)
        {
            throw new NotImplementedException();
        }
    }
}
