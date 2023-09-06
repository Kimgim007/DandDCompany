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
    public class ClassDTOService : IClassDTOService
    {
        private ClassRepository _classRepository;
        public ClassDTOService(ClassRepository classRepository)
        {
            this._classRepository = classRepository;
        }

        public async Task Add(ClassDTO classDTO)
        {
            await _classRepository.Add(DTO.Service.Mapnig.Maping.map(classDTO));
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

        public Task Update(ClassDTO classDTO)
        {
            throw new NotImplementedException();
        }
    }
}
