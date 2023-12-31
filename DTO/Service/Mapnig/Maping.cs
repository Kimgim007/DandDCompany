﻿using DataBase.DbEntity;
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
            AccountDTO gameAccountDTO = new AccountDTO() { AccountDTOId = character.AccountId, MicrosoftAccountId = character.Account.MicrosoftAccountId };
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

                GamingSystemId = gameClassDTO.GamingSystemDTO.GamingSystemDTOId
            };
        }
        public static GameClassDTO map(GameClass gameClass)
        {
            GamingSystemDTO gamingSystemDTO = new GamingSystemDTO()
            {
                GamingSystemDTOId = gameClass.GamingSystemId,
                GamingSystemDTOName = gameClass.GamingSystem.GamingSystemName
            };
            return new GameClassDTO()
            {
                GameClassDTOId = gameClass.GameClassId,
                GameClassName = gameClass.GameClassName,
                DescriptionGameClass = gameClass.DescriptionGameClass,

                GamingSystemDTO= gamingSystemDTO
            };
        }
        public static Room map(RoomDTO roomDTO)
        {

            return new Room()
            {
                RoomId = roomDTO.RoomId,
                RoomName = roomDTO.RoomName,
                AccountId = roomDTO.AdminAccountDTO.AccountDTOId,
                GamingSystemId = roomDTO.GamingSystemDTO.GamingSystemDTOId

            };
        }
        public static RoomDTO map(Room room)
        {
            List<CharacterRoomDTO> CharacterRoomDTO = new List<CharacterRoomDTO>();
            CharacterRoomDTO = room.CharacterRooms.Select(q => map(q)).ToList();

            AccountDTO accountDTO = new AccountDTO()
            {
                AccountDTOId = room.AccountId,


            };

            return new RoomDTO()
            {
                RoomId = room.RoomId,
                RoomName = room.RoomName,

                AdminAccountDTO = accountDTO,

                AccountRoomsDTO = CharacterRoomDTO,
                GamingSystemDTO = map(room.GamingSystem)

            };
        }

        public static Account map(AccountDTO AccountDTO)
        {
            return new Account()
            {
                AccountId = AccountDTO.AccountDTOId,
                MicrosoftAccountId = AccountDTO.MicrosoftAccountId,
                MicrosoftAccountName = AccountDTO.MicrosoftAccountName,
            };
        }

        public static AccountDTO map(Account Account)
        {
            List<CharacterDTO> list = new List<CharacterDTO>();

            list = Account.Characters.Select(q => map(q)).ToList();

            return new AccountDTO()
            {
                AccountDTOId = Account.AccountId,
                MicrosoftAccountId = Account.MicrosoftAccountId,

                MicrosoftAccountName = Account.MicrosoftAccountName,

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

            RoomDTO gameRoomDTO = new RoomDTO() { RoomId = (Guid)characterRoom.RoomId };
            CharacterDTO gameCharacterDTO = new CharacterDTO() { CharacterId = (Guid)characterRoom.CharacterId };

            return new CharacterRoomDTO()
            {
                CharacterRoomDTOId = characterRoom.CharacterRoomId,

                RoomDTO = gameRoomDTO,
                CharacterDTO = gameCharacterDTO,

                PassDTO = characterRoom.Pass
            };
        }

        public static GamingSystem map(GamingSystemDTO gamingSystemDTO)
        {
            return new GamingSystem()
            {
                GamingSystemId = gamingSystemDTO.GamingSystemDTOId,
                GamingSystemName = gamingSystemDTO.GamingSystemDTOName,
            };
        }
        public static GamingSystemDTO map(GamingSystem gamingSystem)
        {
            return new GamingSystemDTO()
            {
                GamingSystemDTOId = gamingSystem.GamingSystemId,
                GamingSystemDTOName = gamingSystem.GamingSystemName,
                GameClassDTOes = gamingSystem.GameClasses.Select(q=>map(q)).ToList(),
            };
        }

    }
}
