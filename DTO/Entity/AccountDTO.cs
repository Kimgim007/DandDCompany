using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class AccountDTO
    {
        public AccountDTO() { }
        public AccountDTO(string Email)
        {
            this.Email = Email;
        }

        public Guid AccountDTOId { get; set; }
        public string Email { get; set; }

        public List<CharacterDTO>? CharacterDTOs { get; set; } = new List<CharacterDTO>();

    
    }
}
