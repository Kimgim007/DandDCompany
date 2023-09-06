using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IGroupDTOService
    {
        Task Add(GroupDTO groupDTO);
        Task<GroupDTO> Get(int id);
        Task<List<GroupDTO>> GetAll();
        Task Update(GroupDTO groupDTO);
        Task Remove(int id);
    }
}
