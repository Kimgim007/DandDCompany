﻿using Microsoft.AspNetCore.Mvc;
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

            if(id == Guid.Empty)
            {
                classViewModel = new GameClassViewModel()
                {
                    
                };
            }
            else
            {
                var gameClass = await _GameClassDTOService.Get(id);
                classViewModel = new GameClassViewModel()
                {
                    GameClassId = gameClass.GameClassDTOId,
                    GameClassName = gameClass.GameClassName,
                    DescriptionGameClass= gameClass.DescriptionGameClass,

                };
            }
          
            return View(classViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddGameClass(GameClassViewModel classViewModel)
        {
            GameClassDTO classDTO = new GameClassDTO(classViewModel.GameClassId, classViewModel.GameClassName, classViewModel.DescriptionGameClass);
            if (classViewModel.GameClassId == Guid.Empty)
            {
                await _GameClassDTOService.Add(classDTO);
            }
            else
            {
                classDTO.GameClassDTOId = classViewModel.GameClassId;
                await _GameClassDTOService.Update(classDTO);
            }
           
          
            return RedirectToAction("GetGameClasss", "GameClass");
        }

        public async Task<IActionResult> GetGameClasss()
        {
           var gameClasss = await _GameClassDTOService.GetAll();
            var gameClassSort = gameClasss;
            return View(gameClassSort);
        }
    }
}
