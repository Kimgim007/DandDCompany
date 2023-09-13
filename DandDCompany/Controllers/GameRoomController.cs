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
        public GameRoomController(IGameRoomDTOService groupDTOService, IGameAccountGameRoomDTOService gameAccountGameRoomDTOService, IGameAccountDTOService gameAccountDTOService)
        {
            this._gameRoomDTOService = groupDTOService;
            this._gameAccountGameRoomDTOService = gameAccountGameRoomDTOService;
            _gameAccountDTOService = gameAccountDTOService;
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

            List<GameAccountDTO> gameAccountsDTO = new List<GameAccountDTO>();

            foreach(var item in gameRoom.AccountGameRooms)
            {
                gameAccountsDTO.Add(await _gameAccountDTOService.Get(item.GameAccountGameRoomDTOId));
            }
            gameRoom.AccountDTOs = gameAccountsDTO;
            return View(gameRoom);
        }

        public async Task<IActionResult> GetAllGameRoom()
        {

            var gameRoom = await _gameRoomDTOService.GetAll();


            return View(gameRoom);
        }

      
        public async Task<IActionResult> JoinTheRoom(Guid Roomid, string Login)
        {
            var gameAccount = await _gameAccountDTOService.GetGameAccountForEmail(Login);

            GameAccountDTO gameAccountDTO = new GameAccountDTO() { GameAccountDTOId = gameAccount.GameAccountDTOId };
            GameRoomDTO gameRoomDTO = new GameRoomDTO() { GameRoomId = Roomid };

            GameAccountGameRoomDTO gameAccountGameRoomDTO = new GameAccountGameRoomDTO(gameAccountDTO, gameRoomDTO);
            await _gameAccountGameRoomDTOService.Add(gameAccountGameRoomDTO);
            return RedirectToAction("GetAllGameRoom", "GameRoom");
        }
    }
}
