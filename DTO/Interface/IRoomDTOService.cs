using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IRoomDTOService
    {
        Task Add(RoomDTO RoomDTO);
        Task<RoomDTO> Get(Guid id);
        Task<List<RoomDTO>> GetAll();
        Task Update(RoomDTO RoomDTO);
        Task Remove(Guid id);
    }
}
