using Microsoft.AspNetCore.Mvc;
using DandDCompany.Models;
using DTO.Service;
using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;


namespace DandDCompany.Controllers
{
    public class ClassController : Controller
    {
        private IClassDTOService _classDTOService;
        public ClassController(IClassDTOService classDTOService)
        {
            this._classDTOService = classDTOService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddClass(int id)
        {
            ClassViewModel classViewModel;
            classViewModel = new ClassViewModel()
            {

            };
            return View(classViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddClass(ClassViewModel classViewModel)
        {
            ClassDTO classDTO = new ClassDTO(classViewModel.ClassId, classViewModel.ClassName);
            await _classDTOService.Add(classDTO);
            return RedirectToAction("Index", "Home");
        }
    }
}
