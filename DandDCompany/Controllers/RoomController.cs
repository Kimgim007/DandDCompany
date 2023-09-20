using DandDCompany.Models;
using DataBase.DbEntity;
using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DandDCompany.Controllers
{
    public class RoomController : Controller
    {
        private IRoomDTOService _roomDTOService;
        public ICharacterRoomDTOService _characterRoomDTOService;
        public IAccountDTOService _accountDTOService;
        public ICharacterDTOService _characterDTOService;

        public RoomController(IRoomDTOService roomDTOService,
            ICharacterRoomDTOService characterRoomDTOService,
            IAccountDTOService accountDTOService,
            ICharacterDTOService characterDTOService)
        {
            this._roomDTOService = roomDTOService;
            this._characterRoomDTOService = characterRoomDTOService;
            this._accountDTOService = accountDTOService;
            this._characterDTOService = characterDTOService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddRoom(Guid AccountId)
        {
            RoomViewModel groupViewModel;
            groupViewModel = new RoomViewModel()
            {
                AccountId = AccountId,
            };
            return View(groupViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomViewModel groupViewModel)
        {
            AccountDTO accountDTO = new AccountDTO() { AccountDTOId =groupViewModel.AccountId};
            RoomDTO groupDTO = new RoomDTO(groupViewModel.GameRoomId, accountDTO, groupViewModel.GameRoomName);
            await _roomDTOService.Add(groupDTO);
            return RedirectToAction("GetAllRoom", "Room");
        }

        public async Task<IActionResult> GetRoom(Guid id)
        {
            var room = await _roomDTOService.Get(id);

            var Account = await _accountDTOService.Get(room.AdminAccountDTO.AccountDTOId);
            room.AdminAccountDTO.MicrosoftAccountId = Account.MicrosoftAccountId;
            room.AdminAccountDTO.MicrosoftAccountName = Account.MicrosoftAccountName;

            List<CharacterDTO> gameAccountsDTOTrue = new List<CharacterDTO>();
            List<CharacterDTO> gameAccountsDTOFalse = new List<CharacterDTO>();

            foreach (var item in room.AccountRoomsDTO)
            {
                if (item.PassDTO == true)
                {
                    var character = await _characterDTOService.Get(item.CharacterDTO.CharacterId);
                  
                    Account = await _accountDTOService.Get(character.AccountDTO.AccountDTOId);
                    character.AccountDTO.MicrosoftAccountName = Account.MicrosoftAccountName;

                    gameAccountsDTOTrue.Add(character);
                }
                else
                {

                    var character = await _characterDTOService.Get(item.CharacterDTO.CharacterId);

                    Account = await _accountDTOService.Get(character.AccountDTO.AccountDTOId);
                    character.AccountDTO.MicrosoftAccountName = Account.MicrosoftAccountName;

                    gameAccountsDTOFalse.Add(character);
                }

            }

            room.CharacterDTOAnswerTrue = gameAccountsDTOTrue;
            room.CharacterDTOAnswerFalse = gameAccountsDTOFalse;

            return View(room);
        }

        public async Task<IActionResult> GetAllRoom()
        {
            var gameRoom = await _roomDTOService.GetAll();
            return View(gameRoom);
        }

        [HttpGet]
        public async Task<IActionResult> JoinTheRoom(Guid Roomid,string MicrosoftAccountId)
        {
            var account = await _accountDTOService.GetAccountForMicrosoftAccountId(Guid.Parse(MicrosoftAccountId));

            RoomDTO RoomDTO = new RoomDTO() { RoomId = Roomid };

          
            CharacterRoomViewModel characterRoomViewModel;

            characterRoomViewModel = new CharacterRoomViewModel()
            {
                RoomDTO= RoomDTO,  
                Characters = account.CharacterDTOs
            };


            return View(characterRoomViewModel);
        }
            [HttpPost]
        public async Task<IActionResult> JoinTheRoom(CharacterRoomViewModel characterRoomViewModel,Guid GameCharId)
        {
            
            CharacterDTO gameCharacterDTO = new CharacterDTO() { CharacterId = GameCharId };

            bool pass = false;

            CharacterRoomDTO gameAccountGameRoomDTO = new CharacterRoomDTO(gameCharacterDTO,characterRoomViewModel.RoomDTO,pass);
            await _characterRoomDTOService.Add(gameAccountGameRoomDTO);
            return RedirectToAction("GetAllRoom", "Room");
        }
    }
}
