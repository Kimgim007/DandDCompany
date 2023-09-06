using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IClassDTOService
    {
        Task Add(ClassDTO classDTO);
        Task<ClassDTO> Get(int id);
        Task<List<ClassDTO>> GetAll();
        Task Update(ClassDTO classDTO);
        Task Remove(int id);
    }
}
