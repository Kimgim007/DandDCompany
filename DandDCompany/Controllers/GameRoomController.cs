using DandDCompany.Models;
using DataBase.DbEntity;
using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DandDCompany.Controllers
{
    public class GameRoomController : Controller
    {
        private IGameRoomDTOService _gameRoomDTOService;
        public IGameAccountGameRoomDTOService _gameAccountGameRoomDTOService;
        public IGameAccountDTOService _gameAccountDTOService;
        public IGameCharacterDTOService _gameCharacterDTOService;

        public GameRoomController(IGameRoomDTOService groupDTOService, IGameAccountGameRoomDTOService gameAccountGameRoomDTOService, IGameAccountDTOService gameAccountDTOService, IGameCharacterDTOService gameCharacterDTOService)
        {
            this._gameRoomDTOService = groupDTOService;
            this._gameAccountGameRoomDTOService = gameAccountGameRoomDTOService;
            _gameAccountDTOService = gameAccountDTOService;
            _gameCharacterDTOService = gameCharacterDTOService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddGameRoom(string AdminRoomEmail, int Guid)
        {
            GameRoomViewModel groupViewModel;
            groupViewModel = new GameRoomViewModel()
            {
                AdminRoomEmail = AdminRoomEmail,
            };
            return View(groupViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddGameRoom(GameRoomViewModel groupViewModel)
        {
            GameRoomDTO groupDTO = new GameRoomDTO(groupViewModel.GameRoomId, groupViewModel.GameRoomName, groupViewModel.AdminRoomEmail);
            await _gameRoomDTOService.Add(groupDTO);
            return RedirectToAction("AddGameRoom", "GameRoom");
        }

        public async Task<IActionResult> GetGameRoom(Guid id)
        {
            var gameRoom = await _gameRoomDTOService.Get(id);

            List<GameAccountDTO> gameAccountsDTOTrue = new List<GameAccountDTO>();
            List<GameAccountDTO> gameAccountsDTOFalse = new List<GameAccountDTO>();

           
           

            foreach (var item in gameRoom.AccountGameRooms)
            {
                if (item.PassDTO == true)
                {
                    List<GameCharacterDTO> gameCharDTO = new List<GameCharacterDTO>();

                    var gameAccountId = item.GameAccountDTO.GameAccountDTOId;
                    var gameAccountDTO = await _gameAccountDTOService.Get(gameAccountId);


                    var gameCharId = gameRoom.AccountGameRooms.FirstOrDefault(x => x.GameAccountDTO.GameAccountDTOId == gameAccountId);

                    var gameChar = await _gameCharacterDTOService.Get(gameCharId.GameCharacter.GameCharacterId);


                    gameCharDTO.Add(gameChar);

                    gameAccountDTO.gameCharacterDTOs = gameCharDTO;


                    gameAccountsDTOTrue.Add(gameAccountDTO);
                }
                else
                {
                    List<GameCharacterDTO> gameCharDTO = new List<GameCharacterDTO>();

                    var gameAccountId = item.GameAccountDTO.GameAccountDTOId;
                    var gameAccountDTO =await _gameAccountDTOService.Get(gameAccountId);

                    var gameCharId = gameRoom.AccountGameRooms.FirstOrDefault(x => x.GameAccountDTO.GameAccountDTOId== gameAccountId);

                    var gameChar = await _gameCharacterDTOService.Get(gameCharId.GameCharacter.GameCharacterId);

           

                    gameCharDTO.Add(gameChar);

                    gameAccountDTO.gameCharacterDTOs = gameCharDTO;

                    gameAccountsDTOFalse.Add(gameAccountDTO);
                }

            }

            gameRoom.AccountDTOsAnswerTrue = gameAccountsDTOTrue;
            gameRoom.AccountDTOsAnswerFalse = gameAccountsDTOFalse;

            return View(gameRoom);
        }

        public async Task<IActionResult> GetAllGameRoom()
        {
            var gameRoom = await _gameRoomDTOService.GetAll();
            return View(gameRoom);
        }


        [HttpGet]
        public async Task<IActionResult> JoinTheRoom(Guid Roomid,string AccountEmail)
        {
            var gameAccount = await _gameAccountDTOService.GetGameAccountForEmail(AccountEmail);

            GameAccountGameRoomDTO gameAccountGameRoomDTO;
            GameRoomDTO gameRoomDTO = new GameRoomDTO() {GameRoomId = Roomid };
            gameAccountGameRoomDTO = new GameAccountGameRoomDTO()
            {
              GameAccountDTO = gameAccount,
               GameRoomDTO = gameRoomDTO,

            };
           
            return View(gameAccountGameRoomDTO);
        }
            [HttpPost]
        public async Task<IActionResult> JoinTheRoom(GameAccountGameRoomDTO gameAccountGameRoomDTOView,Guid GameCharId)
        {
            
            GameCharacterDTO gameCharacterDTO = new GameCharacterDTO() { GameCharacterId = GameCharId };

            bool pass = false;

            GameAccountGameRoomDTO gameAccountGameRoomDTO = new GameAccountGameRoomDTO(gameAccountGameRoomDTOView.GameAccountDTO, gameAccountGameRoomDTOView.GameRoomDTO, pass, gameCharacterDTO);
            await _gameAccountGameRoomDTOService.Add(gameAccountGameRoomDTO);
            return RedirectToAction("GetAllGameRoom", "GameRoom");
        }
    }
}
