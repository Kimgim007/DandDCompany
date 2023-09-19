using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interface
{
    public interface IAccountDTOService
    {
        Task Add(AccountDTO AccountDTO);
        Task<AccountDTO> GetGameAccountForEmail(string AccountDTO);
        Task<AccountDTO> Get(Guid id);
        Task<List<AccountDTO>> GetAll();
        Task Update(AccountDTO AccountDTO);
        Task Remove(Guid id);
    }
}
