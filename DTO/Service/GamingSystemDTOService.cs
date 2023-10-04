using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Repository;
using DTO.Entity;
using DTO.Interface;
namespace DTO.Service
{
    public class GamingSystemDTOService : IGamingSystemDTOService
    {
        private GamingSystemRepository _gamingSystemRepository;
        public GamingSystemDTOService(GamingSystemRepository gamingSystemRepository)
        {
            this._gamingSystemRepository = gamingSystemRepository;
        }

        public async Task Add(GamingSystemDTO GamingSystemDTO)
        {
            await _gamingSystemRepository.Add(Mapnig.Maping.map(GamingSystemDTO));
        }

        public Task<GamingSystemDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GamingSystemDTO>> GetAll()
        {
            var gamingSystem = await _gamingSystemRepository.GetAll();
            var gamingSystemSort = gamingSystem.Select(q=>Mapnig.Maping.map(q)).ToList();
            return gamingSystemSort;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GamingSystemDTO GamingSystemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
