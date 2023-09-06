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

        public static Player map(PlayerDTO playerDTO)
        {
            return new Player()
            {
                PlayerId = playerDTO.PlayerId,
                PlayerName = playerDTO.PlayerName,
            };
        }
        public static PlayerDTO map(Player player)
        {
            return new PlayerDTO()
            {
                PlayerId = player.PlayerId,
                PlayerName = player.PlayerName,
            };
        }

        public static Class map(ClassDTO classDTO)
        {
            return new Class()
            {
                ClassId = classDTO.ClassId,
                ClassName = classDTO.ClassName,

            };
        }
        public static ClassDTO map(Class _class)
        {
            return new ClassDTO()
            {
                ClassId = _class.ClassId,
                ClassName = _class.ClassName,
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

    }
}
