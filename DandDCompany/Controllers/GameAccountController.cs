using DTO.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DandDCompany.Controllers
{
    public class GameAccountController : Controller
    {
        private IGameAccountDTOService _gameAccountDTOService;
        public GameAccountController(IGameAccountDTOService gameAccountDTOService)
        {
            this._gameAccountDTOService = gameAccountDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetGameAccount(string email)
        {
            var gmaeAccount = await _gameAccountDTOService.GetGameAccountForEmail(email);
            return View(gmaeAccount);
        }
    }
}
