using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface ICharacterDTOService
    {
        Task Add(CharacterDTO CharacterDTO);
        Task<CharacterDTO> Get(Guid id);
        Task<List<CharacterDTO>> GetAll();
        Task Update(CharacterDTO CharacterDTO);
        Task Remove(Guid id);
    }
}
