using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IPlayerDTOService
    {
        Task Add(PlayerDTO playerDTO);
        Task<ClassDTO> Get(int id);
        Task<List<ClassDTO>> GetAll();
        Task Update(PlayerDTO playerDTO);
        Task Remove(int id);
    }
}
