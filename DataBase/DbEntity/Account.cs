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

        public string Email { get; set; }

        public List<Character> Characters { get; set; }= new List<Character>();
     
    }
}
