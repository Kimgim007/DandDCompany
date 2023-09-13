using DataBase.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Entity
{
    public class GameClassDTO
    {
        public GameClassDTO() { }
        public GameClassDTO(Guid gameClassId, string gameClassName, string? descriptionGameClass)
        {
            this.GameClassDTOId = gameClassId;
            this.GameClassName = gameClassName;
            this.DescriptionGameClass = descriptionGameClass;
        }

        public Guid GameClassDTOId { get; set; }
        public string? GameClassName { get; set; }
        public string? DescriptionGameClass { get; set; }

        public List<GameCharacterDTO>? GameCharacters { get; set; }=new List<GameCharacterDTO>();
    }
}
