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
    public class GroupDTOService : IGroupDTOService
    {
        private GroupRepository _groupRepository;
        public GroupDTOService(GroupRepository groupRepository)
        {
            this._groupRepository = groupRepository;    
        }

        public async Task Add(GroupDTO groupDTO)
        {
            await _groupRepository.Add(DTO.Service.Mapnig.Maping.map(groupDTO));
        }

        public Task<GroupDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(GroupDTO groupDTO)
        {
            throw new NotImplementedException();
        }
    }
}
