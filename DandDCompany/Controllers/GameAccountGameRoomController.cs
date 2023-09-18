using DataBase.DbEntity;
using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DandDCompany.Controllers
{
    public class GameAccountGameRoomController : Controller
    {
        private IGameAccountGameRoomDTOService _gameAccountGameRoomDTOService;
        public GameAccountGameRoomController(IGameAccountGameRoomDTOService gameAccountGameRoomDTOService)
        {
            this._gameAccountGameRoomDTOService = gameAccountGameRoomDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PassAnswer(bool answer, Guid gameAccountId, Guid gameRoomId,Guid gameCharId)
        {
            var gameAccountGameRoom = await _gameAccountGameRoomDTOService.GetFromAcoountIdandRoomId(gameAccountId, gameRoomId);

            GameAccountDTO gameAccountDTO = new GameAccountDTO() { GameAccountDTOId = gameAccountGameRoom.GameAccountDTO.GameAccountDTOId };
            GameRoomDTO gameRoomDTO = new GameRoomDTO() { GameRoomId = gameAccountGameRoom.GameRoomDTO.GameRoomId };
            GameCharacterDTO gameCharacterDTO = new GameCharacterDTO() {GameCharacterId = gameCharId };

            GameAccountGameRoomDTO gameAccountGameRoomDTO = new GameAccountGameRoomDTO()
            {
             
                GameAccountDTO = gameAccountDTO,
                GameRoomDTO = gameRoomDTO,
                GameCharacter = gameCharacterDTO,
                PassDTO = answer,
            };
            await _gameAccountGameRoomDTOService.Update(gameAccountGameRoomDTO);
            return RedirectToAction("GetAllGameRoom", "GameRoom");
        }

        public async Task<IActionResult> RemoveByAccountIdRoomId(Guid gameAccountId,Guid gameRoomId)
        {
            await _gameAccountGameRoomDTOService.RemoveByAccountIdRoomId(gameAccountId,gameRoomId);
            return RedirectToAction("GetAllGameRoom", "GameRoom");
        }
    }
}
