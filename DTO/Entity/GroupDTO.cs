using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class GroupDTO
    {
        public GroupDTO() { }
        public GroupDTO(Guid GroupId, string GroupName)
        {
            this.GroupId = GroupId;
            this.GroupName = GroupName;
        }

        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
