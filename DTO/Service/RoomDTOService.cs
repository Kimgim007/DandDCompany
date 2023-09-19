using DataBase.Repository;
using DTO.Entity;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Service.Mapnig;
namespace DTO.Service
{
    public class RoomDTOService : IRoomDTOService
    {
        private RoomRepository _roomRepository;
        public RoomDTOService(RoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;    
        }

        public async Task Add(RoomDTO roomDTO)
        {
            await _roomRepository.Add(DTO.Service.Mapnig.Maping.map(roomDTO));
        }

        public async Task<RoomDTO> Get(Guid id)
        {
           var Room = await _roomRepository.Get(id);
            var RoomSort = Maping.map(Room);

            return RoomSort;

        }

        public async Task<List<RoomDTO>> GetAll()
        {
           var Rooms = await _roomRepository.GetAll();
            var RoomsSort = Rooms.Select(q=>Maping.map(q)).ToList();
            return RoomsSort;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(RoomDTO groupDTO)
        {
            throw new NotImplementedException();
        }
    }
}
