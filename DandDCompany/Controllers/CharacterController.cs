using DandDCompany.Models;
using DTO.Entity;
using DTO.Interface;
using DTO.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DandDCompany.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterDTOService _characterDTOService;
        private IGameClassDTOService _gameClassDTOService;
        private IGamingSystemDTOService _gamingSystemDTOService;
        public CharacterController(ICharacterDTOService characterDTOService, IGameClassDTOService gameClassDTOService, IGamingSystemDTOService gamingSystemDTOService)
        {
            this._characterDTOService = characterDTOService;
            this._gameClassDTOService = gameClassDTOService;
            this._gamingSystemDTOService = gamingSystemDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCharacter(Guid AccountId, Guid CharId)
        {

            CharacterViewModel gameCharacterViewModel;
           
            if (CharId == Guid.Empty)
            {     
                var gamingSystem = await _gamingSystemDTOService.GetAll();
                gameCharacterViewModel = new CharacterViewModel()
                {                  
                    AccountId = AccountId,
                    gamingSystemDTOs = gamingSystem
                };
            }
            else
            {
                var GameCahr = await _characterDTOService.Get(CharId);
                gameCharacterViewModel = new CharacterViewModel()
                {
                    CharacterId= GameCahr.CharacterId,
                    CharacterName=GameCahr.CharacterName,
                    DescriptionChar = GameCahr.DescriptionChar,
                    GameClassId = GameCahr.GameClassDTO.GameClassDTOId,
                    AccountId=AccountId,

                };
            }

            return View(gameCharacterViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddCharacter(CharacterViewModel gameCharacterViewModel, Guid GameClassId)
        {

            GameClassDTO gameClassDTO;
            if (gameCharacterViewModel.CharacterId == Guid.Empty)
            {
                 gameClassDTO = new GameClassDTO() { GameClassDTOId = GameClassId };
            }
            else
            {
                 gameClassDTO = new GameClassDTO() { GameClassDTOId = gameCharacterViewModel.GameClassId };
            }

            CharacterDTO gameCharacterDTO = new CharacterDTO
                (gameCharacterViewModel.CharacterId,
                gameCharacterViewModel.CharacterName,
                gameCharacterViewModel.DescriptionChar,
                gameClassDTO,
               new AccountDTO() { AccountDTOId = gameCharacterViewModel.AccountId });

            var gameCarSotr = gameCharacterDTO;
            if(gameCharacterViewModel.CharacterId == Guid.Empty)
            {
                await _characterDTOService.Add(gameCarSotr);
            }
            else
            {
                await _characterDTOService.Update(gameCharacterDTO);
            }
           
            return RedirectToAction("AddCharacter", "Character");
        }

        public async Task<IActionResult> GetChararcter(Guid Id)
        {
            var GameChar = await _characterDTOService.Get(Id);
            var GameClass = await _gameClassDTOService.Get(GameChar.GameClassDTO.GameClassDTOId);
            GameChar.GameClassDTO = GameClass;
            return View(GameChar);
        }
    }
}
