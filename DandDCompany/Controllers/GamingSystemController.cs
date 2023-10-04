using DandDCompany.Models;
using DTO.Entity;
using DTO.Interface;
using DTO.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DTO.Entity;
namespace DandDCompany.Controllers
{
    public class GamingSystemController : Controller
    {
        private IGamingSystemDTOService _gamingSystemDTOService;
        public GamingSystemController(IGamingSystemDTOService gamingSystemDTOService)
        {
            this._gamingSystemDTOService = gamingSystemDTOService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddGamingSystem(Guid id)
        {
            GamingSysnetViewModel gamingSysnetViewModel;

            if (id == Guid.Empty)
            {
                gamingSysnetViewModel = new GamingSysnetViewModel()
                {

                };
            }
            else
            {
                gamingSysnetViewModel = new GamingSysnetViewModel()
                {

                };
            }

            return View(gamingSysnetViewModel);
        }
        [HttpPost]

        public async Task<IActionResult> AddGamingSystem(GamingSysnetViewModel gamingSysnetViewModel)
        {
            GamingSystemDTO gamingSystemDTO = new GamingSystemDTO(gamingSysnetViewModel.GamingSysnetViewModelName);

            await _gamingSystemDTOService.Add(gamingSystemDTO);
            return RedirectToAction("GetAllGamingSystem", "GamingSystem");
        }

        public async Task<IActionResult> GetAllGamingSystem()
        {

            var gamingSystem = await _gamingSystemDTOService.GetAll();

            return View(gamingSystem);
        }
    }
}
