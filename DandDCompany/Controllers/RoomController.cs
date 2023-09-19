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
        public async Task<IActionResult> AddRoom(string AdminRoomEmail)
        {
            RoomViewModel groupViewModel;
            groupViewModel = new RoomViewModel()
            {
                AdminRoomEmail = AdminRoomEmail,
            };
            return View(groupViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomViewModel groupViewModel)
        {
            RoomDTO groupDTO = new RoomDTO(groupViewModel.GameRoomId, groupViewModel.GameRoomName, groupViewModel.AdminRoomEmail);
            await _roomDTOService.Add(groupDTO);
            return RedirectToAction("AddRoom", "Room");
        }

        public async Task<IActionResult> GetRoom(Guid id)
        {
            var charRoom = await _roomDTOService.Get(id);

            List<CharacterDTO> gameAccountsDTOTrue = new List<CharacterDTO>();
            List<CharacterDTO> gameAccountsDTOFalse = new List<CharacterDTO>();

            foreach (var item in charRoom.AccountRoomsDTO)
            {
                if (item.PassDTO == true)
                {
                    gameAccountsDTOTrue.Add(await _characterDTOService.Get(item.CharacterDTO.CharacterId));
                }
                else
                {
                    List<CharacterDTO> gameCharDTO = new List<CharacterDTO>();

                    gameAccountsDTOFalse.Add(await _characterDTOService.Get(item.CharacterDTO.CharacterId));
                }

            }

            charRoom.CharacterDTOAnswerTrue = gameAccountsDTOTrue;
            charRoom.CharacterDTOAnswerFalse = gameAccountsDTOFalse;

            return View(charRoom);
        }

        public async Task<IActionResult> GetAllRoom()
        {
            var gameRoom = await _roomDTOService.GetAll();
            return View(gameRoom);
        }

        [HttpGet]
        public async Task<IActionResult> JoinTheRoom(Guid Roomid,string AccountEmail)
        {
            var account = await _accountDTOService.GetGameAccountForEmail(AccountEmail);

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
