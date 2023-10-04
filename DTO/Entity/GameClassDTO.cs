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
        public GameClassDTO(Guid GameClassId, string GameClassName, string? DescriptionGameClass, GamingSystemDTO gamingSystemDTO)
        {
            this.GameClassDTOId = GameClassId;
            this.GameClassName = GameClassName;
            this.DescriptionGameClass = DescriptionGameClass;
            this.GamingSystemDTO = gamingSystemDTO;
        }

        public Guid GameClassDTOId { get; set; }
        public string? GameClassName { get; set; }
        public string? DescriptionGameClass { get; set; }

        public GamingSystemDTO GamingSystemDTO { get; set; }

        public List<CharacterDTO>? CharactersDTO { get; set; }=new List<CharacterDTO>();
    }
}
