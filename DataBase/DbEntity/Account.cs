using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public Guid MicrosoftAccountId { get; set; }

        public string MicrosoftAccountName { get; set; }

        public List<Room> Rooms { get; set; }= new List<Room>();
        public List<Character> Characters { get; set; }= new List<Character>();
     
    }
}
