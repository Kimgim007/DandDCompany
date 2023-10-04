using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class GamingSystem
    {
        public Guid GamingSystemId { get; set; }
        public string GamingSystemName { get; set; }

        public List<GameClass> GameClasses { get; set; }= new List<GameClass>();
        public List<Room> Rooms { get; set; } = new List<Room>();
    
    }
}
