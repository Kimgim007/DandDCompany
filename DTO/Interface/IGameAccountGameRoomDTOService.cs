using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IGameAccountGameRoomDTOService
    {

        Task Add(GameAccountGameRoomDTO gameAccountGameRoomDTO);
        Task<GameAccountGameRoomDTO> Get(Guid id);
        Task<List<GameAccountGameRoomDTO>> GetAll();
        Task Update(GameAccountGameRoomDTO gameAccountGameRoomDTO);
        Task Remove(Guid id);

    }
}
