using Microsoft.AspNetCore.Mvc;
using DandDCompany.Models;
using DTO.Service;
using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;


namespace DandDCompany.Controllers
{
    public class GameClassController : Controller
    {
        private IGameClassDTOService _GameClassDTOService;
        public GameClassController(IGameClassDTOService classDTOService)
        {
            this._GameClassDTOService = classDTOService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddGameClass(Guid id)
        {
            GameClassViewModel classViewModel;
            classViewModel = new GameClassViewModel()
            {

            };
            return View(classViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddGameClass(GameClassViewModel classViewModel)
        {
            GameClassDTO classDTO = new GameClassDTO(classViewModel.GameClassId, classViewModel.GameClassName,classViewModel.DescriptionGameClass);
            await _GameClassDTOService.Add(classDTO);
            return RedirectToAction("AddGameClass", "GameClassController");
        }

        public async Task<IActionResult> GetGameClasss()
        {
           var gameClasss = await _GameClassDTOService.GetAll();
            var gameClassSort = gameClasss;
            return View(gameClassSort);
        }
    }
}
