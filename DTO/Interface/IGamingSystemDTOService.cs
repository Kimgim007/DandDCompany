using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IGamingSystemDTOService
    {
        Task Add(GamingSystemDTO GamingSystemDTO); 
        Task<GamingSystemDTO> Get(Guid id);
        Task<List<GamingSystemDTO>> GetAll();
        Task Update(GamingSystemDTO GamingSystemDTO);
        Task Remove(Guid id);
    }
}
