using DTO.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DandDCompany.Controllers
{
    public class AccountController : Controller
    {
        private IAccountDTOService _AccountDTOService;
        public AccountController(IAccountDTOService gameAccountDTOService)
        {
            this._AccountDTOService = gameAccountDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAccount(string MicrosoftAccountId)
        {
            var Account = await _AccountDTOService.GetAccountForMicrosoftAccountId(Guid.Parse(MicrosoftAccountId));
            var AccountSeeFromDubag = Account;
            return View(AccountSeeFromDubag);
        }
    }
}
