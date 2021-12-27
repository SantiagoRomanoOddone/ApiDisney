using ApiDisney.Models;
using ApiDisney.Models.DTOs;
using ApiDisney.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDisney.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        protected ResponseDTO _response;

        public UsersController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
            _response = new ResponseDTO();
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDto user)
        {
            var response = await _userRepositorio.Register(
                    new User
                    {
                        UserName = user.UserName
                    }, user.Password);
            if (response == -1)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "User already exist";
                return BadRequest(_response);

            }
            if (response == -500)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "User creation error";
                return BadRequest(_response);
            }
            _response.DisplayMessage = "User created successfully";
            _response.Result = response;
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task <ActionResult> Login (UserDto user)
        {
            var response = await _userRepositorio.Login(user.UserName, user.Password);

            if (response == "nouser")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "The User does not exist";
                return BadRequest(_response);
            }
            if (response == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Wrong Password";
                return BadRequest(_response);
            }

            _response.Result = response;
            _response.DisplayMessage = "Loggedin User";
            return Ok(_response);
        }
    }
}
