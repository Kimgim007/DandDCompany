﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class Account
    {
        public Guid AccountId { get; set; }

        public string Email { get; set; }

        public List<GameCharacter> gameCharacters { get; set; }= new List<GameCharacter>();

        public List<GameAccountGameRoom> GameAccountGameRoom { get; set; } = new List<GameAccountGameRoom>();
    }
}