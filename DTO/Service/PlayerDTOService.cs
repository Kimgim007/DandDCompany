using DataBase.Repository;
using DTO.Entity;
using DTO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Service
{
    public class PlayerDTOService : IPlayerDTOService
    {
        private PlayerRepository _playerRepository;
        public PlayerDTOService(PlayerRepository playerRepository) 
        {
        this._playerRepository = playerRepository;
        }
        public async Task Add(PlayerDTO playerDTO)
        {
            await _playerRepository.Add(DTO.Service.Mapnig.Maping.map(playerDTO));
        }

        public Task<ClassDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClassDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(PlayerDTO playerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
