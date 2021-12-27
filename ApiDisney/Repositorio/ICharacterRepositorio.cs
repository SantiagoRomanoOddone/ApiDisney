using ApiDisney.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDisney.Repositorio
{
    public interface ICharacterRepositorio
    {
        Task<List<CharacterDto>> GetCharacters();
        Task<CharacterDto> GetCharacterById(int id);

        Task<CharacterDto> CreateUpdate(CharacterDto characterDto);

        Task<bool> DeleteCharacter(int id);

    }
}
