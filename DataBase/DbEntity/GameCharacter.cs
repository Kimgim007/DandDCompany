﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class GameCharacter
    {
        public Guid GameCharacterId { get; set; }
        public string? GameCharacterName { get; set; }
        public string? DiscriptionGameChar { get; set; }

     

    }
}