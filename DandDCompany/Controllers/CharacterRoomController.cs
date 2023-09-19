using DataBase.DbEntity;
using DTO.Entity;
using DTO.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DandDCompany.Controllers
{
    public class CharacterRoomController : Controller
    {
        private ICharacterRoomDTOService _characterRoomDTOService;
        public CharacterRoomController(ICharacterRoomDTOService characterRoomDTOService)
        {
            this._characterRoomDTOService = characterRoomDTOService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PassAnswer( Guid gameRoomId,Guid gameCharId)
        {
            var characterRoom = await _characterRoomDTOService.GetFromCharacterIdandRoomId(gameCharId, gameRoomId);
    
            RoomDTO gameRoomDTO = new RoomDTO() { RoomId = characterRoom.RoomDTO.RoomId };
            CharacterDTO gameCharacterDTO = new CharacterDTO() {CharacterId = gameCharId };

            CharacterRoomDTO gameAccountGameRoomDTO = new CharacterRoomDTO()
            {               
                RoomDTO = gameRoomDTO,
                CharacterDTO = gameCharacterDTO,
                PassDTO = true,
            };
            await _characterRoomDTOService.Update(gameAccountGameRoomDTO);
            return RedirectToAction("GetAllRoom", "Room");
        }

        public async Task<IActionResult> RemoveByCharIdRoomId(Guid CharId,Guid RoomId)
        {
            await _characterRoomDTOService.RemoveByAccountIdRoomId(CharId,RoomId);
            return RedirectToAction("GetAllRoom", "Room");
        }
    }
}
