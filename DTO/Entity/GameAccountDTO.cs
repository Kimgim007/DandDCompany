﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class GameAccountDTO
    {
        public GameAccountDTO() { }
        public GameAccountDTO(string Email)
        {
            this.Email = Email;
        }

        public Guid GameAccountDTOId { get; set; }

        public string? GameAccountDescription { get; set; }

        public string Email { get; set; }
    }
}