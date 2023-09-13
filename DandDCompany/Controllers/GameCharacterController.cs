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
        private IGameClassDTOService _gameClassDTOService;
        public GameCharacterController(IGameCharacterDTOService GgameCharacterDTOService, IGameClassDTOService gameClassDTOService)
        {
            this._gameCharacterDTOService = GgameCharacterDTOService;
            this._gameClassDTOService = gameClassDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }
      
        [HttpGet]
        public async Task<IActionResult> AddGameCharacter(Guid AccountId,Guid Id)
        {

            GameCharacterViewModel gameCharacterViewModel;
            if(Id == Guid.Empty)
            {
                var gameCalsses = await _gameClassDTOService.GetAll();
                gameCharacterViewModel = new GameCharacterViewModel()
                {
                    gameClassDTOs= gameCalsses,
                    GmaeAccountId = AccountId,
                };
            }
            else
            {
                var GameCahr = await _gameCharacterDTOService.Get(Id);
                gameCharacterViewModel = new GameCharacterViewModel()
                {
                 
                };
            }
           
            return View(gameCharacterViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddGameCharacter(GameCharacterViewModel gameCharacterViewModel,Guid GameClassId)
        {         
            GameCharacterDTO gameCharacterDTO = new GameCharacterDTO(gameCharacterViewModel.GameCharacterId, gameCharacterViewModel.GameCharacterName, new GameClassDTO() { GameClassDTOId = GameClassId},new GameAccountDTO() { GameAccountDTOId=gameCharacterViewModel.GmaeAccountId});

            var gameCarSotr = gameCharacterDTO;

            await _gameCharacterDTOService.Add(gameCarSotr);
            return RedirectToAction("AddGameCharacter", "GameCharacter");
        }

        public async Task<IActionResult> GetGameChar(Guid Id)
        {
            var GameChar = await _gameCharacterDTOService.Get(Id);
            var GameClass = await _gameClassDTOService.Get(GameChar.GameClassDTO.GameClassDTOId);
            GameChar.GameClassDTO= GameClass;
            return View(GameChar);
        }
    }
}
