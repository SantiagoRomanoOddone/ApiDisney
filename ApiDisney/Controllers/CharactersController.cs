using ApiDisney.Data;
using ApiDisney.Models;
using ApiDisney.Models.DTOs;
using ApiDisney.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDisney.Controllers
{
    [Route("api/characters")]
    [ApiController]
    [Authorize]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepositorio _characterRepositorio;
        protected ResponseDTO _response;

        public CharactersController(ICharacterRepositorio characterRepositorio)
        {
            _characterRepositorio = characterRepositorio;
            _response = new ResponseDTO();
        }

        //GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            try
            {
                var lista = await _characterRepositorio.GetCharacters();
                _response.Result = lista;
                _response.DisplayMessage = "Character list";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        //GET: api/Characters/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter (int id)
        {
            var character = await _characterRepositorio.GetCharacterById(id);
            if (character == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "The character does not exist";
                return NotFound(_response);
            }
            _response.Result = character;
            _response.DisplayMessage = "Character information";
            return Ok(_response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterDto characterDto)
        {
            try
            {
                CharacterDto model = await _characterRepositorio.CreateUpdate(characterDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Registry update error";
                _response.ErrorMessages = new List<string> { ex.ToString()};
                return BadRequest(_response);

            }
        }

        //POST: api/Character
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter (CharacterDto characterDto)
        {
            try
            {
                CharacterDto model = await _characterRepositorio.CreateUpdate(characterDto);
                _response.Result = model;
                return CreatedAtAction("GetCharacter", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Log upload error";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        // DELETE: api/Characters/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter (int id)
        {
            try
            {
                bool eliminated = await _characterRepositorio.DeleteCharacter(id);
                if (eliminated)
                {
                    _response.Result = eliminated;
                    _response.DisplayMessage = "Character successfully eliminated";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Character delete error";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
