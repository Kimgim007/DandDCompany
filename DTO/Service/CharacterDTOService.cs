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
    public class CharacterDTOService : ICharacterDTOService
    {
        private CharacterRepository _character;
        public CharacterDTOService(CharacterRepository characterRepository)
        {
            this._character = characterRepository;
        }
        public async Task Add(CharacterDTO characterDTO)
        {
            await _character.Add(DTO.Service.Mapnig.Maping.map(characterDTO));
        }

        public async Task<CharacterDTO> Get(Guid id)
        {
            var Character = await _character.Get(id);
            var CharacterSort = Mapnig.Maping.map(Character);
            return CharacterSort;
        }

        public Task<List<CharacterDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CharacterDTO CharacterDTO)
        {
            await _character.Update(Mapnig.Maping.map(CharacterDTO));
        }
    }
}
