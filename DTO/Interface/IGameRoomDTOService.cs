using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IGameRoomDTOService
    {
        Task Add(GameRoomDTO GameRoomDTO);
        Task<GameRoomDTO> Get(Guid id);
        Task<List<GameRoomDTO>> GetAll();
        Task Update(GameRoomDTO GameRoomDTO);
        Task Remove(Guid id);
    }
}
