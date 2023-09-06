using DandDCompany.Models;
using DataBase.DbEntity;
using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DandDCompany.Controllers
{
    public class GroupController : Controller
    {
        private IGroupDTOService _groupDTOService;
        public GroupController(IGroupDTOService groupDTOService)
        {
            this._groupDTOService = groupDTOService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddGroup(int Guid)
        {
            GroupViewModel groupViewModel;
            groupViewModel = new GroupViewModel()
            {

            };
            return View(groupViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddGroup(GroupViewModel groupViewModel)
        {
            GroupDTO groupDTO = new GroupDTO(groupViewModel.GrupId, groupViewModel.GroupName);
            await _groupDTOService.Add(groupDTO);
            return RedirectToAction("Index","Group");
        }
    }
}
