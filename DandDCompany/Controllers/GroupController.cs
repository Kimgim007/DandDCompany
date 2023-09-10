using DandDCompany.Models;
using DataBase.DbEntity;
using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [Authorize(Roles = "Admin")]
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
            return RedirectToAction("Index", "Group");
        }

        public async Task<IActionResult> GroupView(string GroupName, string DiscriptionGroup)

        {
            GroupViewModel groupViewMidel = new GroupViewModel
            {
                GroupName = GroupName,
                DiscriptionGroup = DiscriptionGroup
            };
            return View(groupViewMidel);
        }

        public async Task<IActionResult> GroupsView()
        {
            List<GroupViewModel> group = new List<GroupViewModel>();
            group.Add(new GroupViewModel
            {
                GroupName = " Группа 1",
                DiscriptionGroup = " Добрая группа быбыбыбыбыбыбыбыбыбы"
            });
            group.Add(new GroupViewModel
            {
                GroupName = " Группа 2",
                DiscriptionGroup = " Злая группа выхыхыхых"
            });
            group.Add(new GroupViewModel
            {
                GroupName = " Группа 3",
                DiscriptionGroup = " Нейтральная группа ыыыыы"
            });
            group.Add(new GroupViewModel
            {
                GroupName = " Группа 4",
                DiscriptionGroup = " Полузлая группа ррррр"
            });
            group.Add(new GroupViewModel
            {
                GroupName = " Группа 5",
                DiscriptionGroup = " Полудобрая группа оооо"
            });
            group.Add(new GroupViewModel
            {
                GroupName = " Группа 6",
                DiscriptionGroup = " Полу группа иииии"
            });

            return View(group);
        }
    }
}
