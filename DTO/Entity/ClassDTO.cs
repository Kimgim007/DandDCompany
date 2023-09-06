using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class ClassDTO
    {
        public ClassDTO() { }
        public ClassDTO(Guid classId, string className)
        {
            this.ClassId = classId;
            this.ClassName = className;
        }

        public Guid ClassId { get; set; }
        public string? ClassName { get; set; }
    }
}
