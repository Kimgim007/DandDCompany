using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DbEntity
{
    public class PersonalPage
    {
        public Guid PersonalPageId { get; set; }

        public Guid UserId { get; set; }

        public string? PageDescription { get; set; }
    }
}
