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

        public static Character map(CharacterDTO characterDTO)
        {
            return new Character()
            {
                CharacterId = characterDTO.CharacterId,
                CharacterName = characterDTO.CharacterName,
                DiscriptionChar = characterDTO.DescriptionChar,

                GameClassId = characterDTO.GameClassDTO.GameClassDTOId,
                AccountId = characterDTO.AccountDTO.AccountDTOId
            };
        }
        public static CharacterDTO map(Character character)
        {
            GameClassDTO gameClassDTO = new GameClassDTO() { GameClassDTOId = character.GameClassId };
            AccountDTO gameAccountDTO = new AccountDTO() { AccountDTOId = character.AccountId,Email = character.Account.Email };
            return new CharacterDTO()
            {
                CharacterId = character.CharacterId,
                CharacterName = character.CharacterName,
                DescriptionChar = character.DiscriptionChar,

                GameClassDTO = gameClassDTO,
                AccountDTO = gameAccountDTO
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
        public static Room map(RoomDTO roomDTO)
        {
            
            return new Room()
            {
                RoomId = roomDTO.RoomId,
                RoomName = roomDTO.RoomName,

                AdminRoomEmail = roomDTO.AdminRoomEmailDTO


            };
        }
        public static RoomDTO map(Room room)
        {
            List<CharacterRoomDTO> accountRoomDTO = new List<CharacterRoomDTO>();
            accountRoomDTO =  room.AccountRooms.Select(q => map(q)).ToList();

            return new RoomDTO()
            {
                RoomId = room.RoomId,
                RoomName = room.RoomName,

                AdminRoomEmailDTO = room.AdminRoomEmail,

                AccountRoomsDTO = accountRoomDTO

            };
        }

        public static Account map(AccountDTO AccountDTO)
        {
            return new Account()
            {
                AccountId = AccountDTO.AccountDTOId,
                Email = AccountDTO.Email,
            };
        }

        public static AccountDTO map(Account Account)
        {
            List<CharacterDTO> list = new List<CharacterDTO>();
          
            list = Account.Characters.Select(q => map(q)).ToList();

            return new AccountDTO()
            {
                AccountDTOId = Account.AccountId,
                Email = Account.Email,

                CharacterDTOs = list


            };
        }


        public static CharacterRoom map(CharacterRoomDTO characterRoomDTO)
        {
            return new CharacterRoom()
            {
                CharacterRoomId = characterRoomDTO.CharacterRoomDTOId,

                CharacterId = characterRoomDTO.CharacterDTO.CharacterId,
                RoomId = characterRoomDTO.RoomDTO.RoomId,
             
                Pass = characterRoomDTO.PassDTO           
            };
        }

        public static CharacterRoomDTO map(CharacterRoom characterRoom)
        {
           
            RoomDTO gameRoomDTO = new RoomDTO() { RoomId = characterRoom.RoomId };
            CharacterDTO gameCharacterDTO = new CharacterDTO() { CharacterId = characterRoom.CharacterId };

            return new CharacterRoomDTO()
            {               
                CharacterRoomDTOId = characterRoom.CharacterRoomId,

                RoomDTO = gameRoomDTO,
                CharacterDTO = gameCharacterDTO,

                PassDTO = characterRoom.Pass   
            };
        }

    }
}
