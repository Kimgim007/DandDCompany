using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IGameCharacterDTOService
    {
        Task Add(GameCharacterDTO gameCharacterDTO);
        Task<GameClassDTO> Get(Guid id);
        Task<List<GameClassDTO>> GetAll();
        Task Update(GameCharacterDTO gameCharacterDTO);
        Task Remove(Guid id);
    }
}
