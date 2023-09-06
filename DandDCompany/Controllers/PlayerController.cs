using DandDCompany.Models;
using DTO.Entity;
using DTO.Interface;
using DTO.Service;
using Microsoft.AspNetCore.Mvc;

namespace DandDCompany.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerDTOService _playerDTOService;
        public PlayerController(IPlayerDTOService playerDTOService) 
        { 
        this._playerDTOService = playerDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddPlayer(int Guid)
        {
            PlayerViewModel playerViewModel;
            playerViewModel = new PlayerViewModel()
            {

            };
            return View(playerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddPlayer(PlayerViewModel playerViewModel)
        {
            PlayerDTO playerDTO = new PlayerDTO(playerViewModel.PlayerId, playerViewModel.PlayerName);
            await _playerDTOService.Add(playerDTO);
            return RedirectToAction("Index", "Player");
        }
    }
}
