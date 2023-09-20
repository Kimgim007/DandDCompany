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
    public class RoomRepository : IRepository<Room>
    {
        private DataContext _dataContext;
        public RoomRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Add(Room room)
        {
            _dataContext.Rooms.Add(room);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<Room> Get(Guid id)
        {
            var room = await _dataContext.Rooms.Include(q=>q.CharacterRooms).Include(q=>q.Account).FirstOrDefaultAsync(q => q.RoomId == id);
            return room;
        }

        public async Task<List<Room>> GetAll()
        {
            var rooms = await _dataContext.Rooms.ToListAsync();
            return rooms;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Room obj)
        {
            throw new NotImplementedException();
        }
    }
}
