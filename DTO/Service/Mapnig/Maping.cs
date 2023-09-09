using DataBase.DbEntity;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service.Mapnig
{
    public static class Maping
    {

        public static GameCharacter map(GameCharacterDTO gameCharacterDTO)
        {
            return new GameCharacter()
            {
                GameCharacterId = gameCharacterDTO.GameCharacterId,
                GameCharacterName = gameCharacterDTO.GameCharacterName,
            };
        }
        public static GameCharacterDTO map(GameCharacter gameCharacter)
        {
            return new GameCharacterDTO()
            {
                GameCharacterId = gameCharacter.GameCharacterId,
                GameCharacterName = gameCharacter.GameCharacterName,
            };
        }

        public static GameClass map(GameClassDTO gameClassDTO)
        {
            return new GameClass()
            {
                GameClassId = gameClassDTO.GameClassId,
                GameClassName = gameClassDTO.GameClassName,
                DescriptionGameClass = gameClassDTO.DescriptionGameClass,

            };
        }
        public static GameClassDTO map(GameClass gameClass)
        {
            return new GameClassDTO()
            {
                GameClassId = gameClass.GameClassId,
                GameClassName = gameClass.GameClassName,
                DescriptionGameClass = gameClass.DescriptionGameClass,


            };
        }
        public static Group map(GroupDTO groupDTO)
        {
            return new Group()
            {
                GroupId = groupDTO.GroupId,
                GroupName = groupDTO.GroupName
            };
        }
        public static GroupDTO map(Group group)
        {
            return new GroupDTO()
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName
            };
        }

        public static GameAccount map(GameAccountDTO gameAccountDTO)
        {
            return new GameAccount()
            {
                GameAccountId = gameAccountDTO.GameAccountDTOId,
                Email = gameAccountDTO.Email,
            };
        }

        public static GameAccountDTO map(GameAccount gameAccount)
        {
            return new GameAccountDTO()
            {
                GameAccountDTOId = gameAccount.GameAccountId,
                Email = gameAccount.Email
            };
        }

    }
}
