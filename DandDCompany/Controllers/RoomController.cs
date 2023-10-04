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
        private ICharacterRoomDTOService _characterRoomDTOService;
        private IAccountDTOService _accountDTOService;
        private ICharacterDTOService _characterDTOService;
        private IGamingSystemDTOService _gamingSystemDTOService;
        private IGameClassDTOService _gameClassDTOService;

        public RoomController(IRoomDTOService roomDTOService,
            ICharacterRoomDTOService characterRoomDTOService,
            IAccountDTOService accountDTOService,
            ICharacterDTOService characterDTOService,
            IGamingSystemDTOService gamingSystemDTOService,
            IGameClassDTOService gameClassDTOService)
        {
            this._roomDTOService = roomDTOService;
            this._characterRoomDTOService = characterRoomDTOService;
            this._accountDTOService = accountDTOService;
            this._characterDTOService = characterDTOService;
            this._gamingSystemDTOService = gamingSystemDTOService;
            this._gameClassDTOService= gameClassDTOService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddRoom(Guid AccountId)
        {
            var gamingSystem = await _gamingSystemDTOService.GetAll(); 
            RoomViewModel groupViewModel;
            groupViewModel = new RoomViewModel()
            {
                AccountId = AccountId,
                gamingSystemDTOs = gamingSystem
            };
            return View(groupViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomViewModel groupViewModel,Guid GamingSystemId)
        {
            AccountDTO accountDTO = new AccountDTO() { AccountDTOId =groupViewModel.AccountId};
            GamingSystemDTO gamingSystemDTO = new GamingSystemDTO() {GamingSystemDTOId = GamingSystemId };
            RoomDTO groupDTO = new RoomDTO(groupViewModel.GameRoomId, accountDTO, groupViewModel.GameRoomName, gamingSystemDTO);
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
        public async Task<IActionResult> JoinTheRoom(Guid Roomid,string MicrosoftAccountId,Guid GamingSystem)
        {
            var account = await _accountDTOService.GetAccountForMicrosoftAccountId(Guid.Parse(MicrosoftAccountId)); 
            
            List<CharacterDTO> characterDTOs = new List<CharacterDTO>();
            GameClassDTO gameClass;

            foreach(var item in account.CharacterDTOs)
            {
                gameClass = await _gameClassDTOService.Get(item.GameClassDTO.GameClassDTOId);
                if(gameClass.GamingSystemDTO.GamingSystemDTOId == GamingSystem)
                {
                    characterDTOs.Add(item);
                }
           
            }

            RoomDTO RoomDTO = new RoomDTO() { RoomId = Roomid };
          
            CharacterRoomViewModel characterRoomViewModel;

            characterRoomViewModel = new CharacterRoomViewModel()
            {
                RoomDTO= RoomDTO,  
                Characters = characterDTOs
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
