using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IGameAccountDTOService
    {
        Task Add(GameAccountDTO gameAccountDTO);
        Task<GameAccountDTO> GetGameAccountForEmail(string gameAccountDTO);
        Task<GameAccountDTO> Get(Guid id);
        Task<List<GameAccountDTO>> GetAll();
        Task Update(GameAccountDTO gameAccountDTO);
        Task Remove(Guid id);
    }
}
