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

                GameClassId = gameCharacterDTO.GameClassDTO.GameClassDTOId,
                GameAccountId = gameCharacterDTO.gameAccountDTO.GameAccountDTOId
            };
        }
        public static GameCharacterDTO map(GameCharacter gameCharacter)
        {
            GameClassDTO gameClassDTO = new GameClassDTO() { GameClassDTOId = gameCharacter.GameClassId };
            GameAccountDTO gameAccountDTO = new GameAccountDTO() { GameAccountDTOId = gameCharacter.GameAccountId };
            return new GameCharacterDTO()
            {
                GameCharacterId = gameCharacter.GameCharacterId,
                GameCharacterName = gameCharacter.GameCharacterName,

                GameClassDTO = gameClassDTO,
                gameAccountDTO = gameAccountDTO
            };
        }

        public static GameClass map(GameClassDTO gameClassDTO)
        {
            return new GameClass()
            {
                GameClassId = gameClassDTO.GameClassDTOId,
                GameClassName = gameClassDTO.GameClassName,
                DescriptionGameClass = gameClassDTO.DescriptionGameClass,



            };
        }
        public static GameClassDTO map(GameClass gameClass)
        {
            return new GameClassDTO()
            {
                GameClassDTOId = gameClass.GameClassId,
                GameClassName = gameClass.GameClassName,
                DescriptionGameClass = gameClass.DescriptionGameClass,


            };
        }
        public static GameRoom map(GameRoomDTO groupDTO)
        {

            return new GameRoom()
            {
                GameRoomId = groupDTO.GameRoomId,
                GameRoomName = groupDTO.GameRoomName,

                AdminRoomEmail = groupDTO.AdminRoomEmailDTO


            };
        }
        public static GameRoomDTO map(GameRoom gameRoom)
        {
            List<GameAccountGameRoomDTO> gameAccountGameRoomDTO = new List<GameAccountGameRoomDTO>();
            gameAccountGameRoomDTO = gameRoom.GameAccountGameRoom.Select(q => map(q)).ToList();

            return new GameRoomDTO()
            {
                GameRoomId = gameRoom.GameRoomId,
                GameRoomName = gameRoom.GameRoomName,

                AdminRoomEmailDTO = gameRoom.AdminRoomEmail,

                AccountGameRooms = gameAccountGameRoomDTO

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
            List<GameCharacterDTO> list = new List<GameCharacterDTO>();
            list = gameAccount.gameCharacters.Select(q => map(q)).ToList();
            return new GameAccountDTO()
            {
                GameAccountDTOId = gameAccount.GameAccountId,
                Email = gameAccount.Email,

                gameCharacterDTOs = list


            };
        }


        public static GameAccountGameRoom map(GameAccountGameRoomDTO gameAccountGameRoomDTO)
        {
            return new GameAccountGameRoom()
            {
                GameAccountGameRoomId = gameAccountGameRoomDTO.GameAccountGameRoomDTOId,

                GameAccountId = gameAccountGameRoomDTO.GameAccountDTO.GameAccountDTOId,
                GameRoomId = gameAccountGameRoomDTO.GameRoomDTO.GameRoomId
            };
        }

        public static GameAccountGameRoomDTO map(GameAccountGameRoom gameAccountGameRoom)
        {
            GameAccountDTO gameAccountDTO = new GameAccountDTO() { GameAccountDTOId = gameAccountGameRoom.GameAccountId };
            GameRoomDTO gameRoomDTO = new GameRoomDTO() { GameRoomId = gameAccountGameRoom.GameRoomId };
            return new GameAccountGameRoomDTO()
            {
                GameAccountGameRoomDTOId = gameAccountGameRoom.GameAccountId,

                GameAccountDTO = gameAccountDTO,
                GameRoomDTO = gameRoomDTO
            };
        }

    }
}
