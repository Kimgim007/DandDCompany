using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IGameClassDTOService
    {
        Task Add(GameClassDTO classDTO);
        Task<GameClassDTO> Get(Guid id);
        Task<List<GameClassDTO>> GetAll();
        Task Update(GameClassDTO classDTO);
        Task Remove(Guid id);
    }
}
