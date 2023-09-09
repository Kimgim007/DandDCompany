using DandDCompany.Models;
using DTO.Entity;
using DTO.Interface;
using DTO.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DandDCompany.Controllers
{
    public class GameCharacterController : Controller
    {
        private IGameCharacterDTOService _gameCharacterDTOService;
        public GameCharacterController(IGameCharacterDTOService GgameCharacterDTOService) 
        { 
        this._gameCharacterDTOService = GgameCharacterDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddGameCharacter(int Guid)
        {
            GameCharacterViewModel gameCharacterViewModel;
            gameCharacterViewModel = new GameCharacterViewModel()
            {

            };
            return View(gameCharacterViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddPlayer(GameCharacterViewModel gameCharacterViewModel)
        {
            GameCharacterDTO gameCharacterDTO = new GameCharacterDTO(gameCharacterViewModel.GameCharacterId, gameCharacterViewModel.GameCharacterName);
            await _gameCharacterDTOService.Add(gameCharacterDTO);
            return RedirectToAction("Index", "Player");
        }
    }
}
