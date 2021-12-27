using ApiDisney.Data;
using ApiDisney.Models;
using ApiDisney.Models.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDisney.Repositorio
{
    public class CharacterRepositorio :ICharacterRepositorio
    {
        private readonly DisneyDbContext _db;
        private IMapper _mapper;


        public CharacterRepositorio(DisneyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CharacterDto> CreateUpdate(CharacterDto characterDto)
        {
            Character character = _mapper.Map<CharacterDto, Character>(characterDto);
            if (character.Id > 0)
            {
                _db.Characters.Update(character);
            }
            else
            {
                await _db.Characters.AddAsync(character);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Character, CharacterDto>(character);
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            try
            {
                Character character = await _db.Characters.FindAsync(id);
                if (character == null)
                {
                    return false;
                }
                _db.Characters.Remove(character);
                await _db.SaveChangesAsync();

                return true;
            }
           
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CharacterDto> GetCharacterById(int id)
        {
            Character character = await _db.Characters.FindAsync(id);
            return _mapper.Map<CharacterDto>(character);
        }

        public async Task<List<CharacterDto>> GetCharacters()
        {
            List<Character> lista = await _db.Characters.ToListAsync();
            return _mapper.Map<List<CharacterDto>>(lista);

        }
    }
}
