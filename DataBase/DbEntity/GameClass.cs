using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class GameClass
    {
        [Key]
        public Guid GameClassId { get; set; }
        public string GameClassName { get; set; }
        public string? DescriptionGameClass { get; set; }

        public  List<Character> Characters { get; set; }= new List<Character>();
    }
}
