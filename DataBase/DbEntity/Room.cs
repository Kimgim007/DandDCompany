﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class Room
    {
        [Key]            
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }

        public string AdminRoomEmail { get; set; }

        public List<CharacterRoom> AccountRooms { get; set; } = new List<CharacterRoom>();

    }
}