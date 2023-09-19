using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class Character
    {
        [Key]
        public Guid CharacterId { get; set; }
        public string? CharacterName { get; set; }
        public string? DiscriptionChar { get; set; }

        public Guid GameClassId { get; set; }
        public  GameClass GameClass { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }

        public List<CharacterRoom> CharacterRoom { get; set; } = new List<CharacterRoom>();

    }
}
