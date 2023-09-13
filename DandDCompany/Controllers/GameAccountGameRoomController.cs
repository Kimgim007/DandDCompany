using DTO.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DandDCompany.Controllers
{
    public class GameAccountGameRoomController : Controller
    {
        private IGameAccountGameRoomDTOService _gameAccountGameRoomDTOService;
        public GameAccountGameRoomController(IGameAccountGameRoomDTOService gameAccountGameRoomDTOService)
        {
            this._gameAccountGameRoomDTOService = gameAccountGameRoomDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
