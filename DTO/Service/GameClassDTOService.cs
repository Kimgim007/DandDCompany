using DataBase.Repository;
using DTO.Entity;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Service.Mapnig;
namespace DTO.Service
{
    public class GameClassDTOService : IGameClassDTOService
    {
        private ClassRepository _classRepository;
        public GameClassDTOService(ClassRepository classRepository)
        {
            this._classRepository = classRepository;
        }

        public async Task Add(GameClassDTO gameClassDTO)
        {
            await _classRepository.Add(DTO.Service.Mapnig.Maping.map(gameClassDTO));
        }

        public async Task<GameClassDTO> Get(Guid id)
        {
            var gmaeClass = await _classRepository.Get(id);
            var gameClassSort = Mapnig.Maping.map(gmaeClass);
            return gameClassSort;
        }

        public async Task<List<GameClassDTO>> GetAll()
        {
            var gameClasss = await _classRepository.GetAll();
            var gameClassSort = gameClasss.Select(q => Maping.map(q)).ToList();
            return gameClassSort;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(GameClassDTO gameClassDTO)
        {
            await _classRepository.Update(Maping.map(gameClassDTO));
        }
    }
}
