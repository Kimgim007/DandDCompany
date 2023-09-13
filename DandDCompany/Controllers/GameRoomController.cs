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
        public GameRoomController(IGameRoomDTOService groupDTOService)
        {
            this._gameRoomDTOService = groupDTOService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddGameRoom(int Guid)
        {
            GameRoomViewModel groupViewModel;
            groupViewModel = new GameRoomViewModel()
            {

            };
            return View(groupViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddGameRoom(GameRoomViewModel groupViewModel)
        {
            GameRoomDTO groupDTO = new GameRoomDTO(groupViewModel.GameRoomId, groupViewModel.GameRoomName);
            await _gameRoomDTOService.Add(groupDTO);
            return RedirectToAction("Index", "Group");
        }

        public async Task<IActionResult> GameRoomView(string GameRoom, string DiscriptionGameRoom)

        {
            GameRoomViewModel groupViewMidel = new GameRoomViewModel
            {
                GameRoomName = GameRoom,
                DiscriptionGameRoom = DiscriptionGameRoom
            };
            return View(groupViewMidel);
        }

        public async Task<IActionResult> GameRoomsView()
        {
            List<GameRoomViewModel> group = new List<GameRoomViewModel>();
            group.Add(new GameRoomViewModel
            {
                GameRoomName = " Группа 1",
                DiscriptionGameRoom = " Добрая группа быбыбыбыбыбыбыбыбыбы"
            });
            group.Add(new GameRoomViewModel
            {
                GameRoomName = " Группа 2",
                DiscriptionGameRoom = " Злая группа выхыхыхых"
            });
            group.Add(new GameRoomViewModel
            {
                GameRoomName = " Группа 3",
                DiscriptionGameRoom = " Нейтральная группа ыыыыы"
            });
            group.Add(new GameRoomViewModel
            {
                GameRoomName = " Группа 4",
                DiscriptionGameRoom = " Полузлая группа ррррр"
            });
            group.Add(new GameRoomViewModel
            {
                GameRoomName = " Группа 5",
                DiscriptionGameRoom = " Полудобрая группа оооо"
            });
            group.Add(new GameRoomViewModel
            {
                GameRoomName = " Группа 6",
                DiscriptionGameRoom = " Полу группа иииии"
            });

            return View(group);
        }
    }
}
