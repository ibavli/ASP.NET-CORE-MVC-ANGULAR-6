using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityGuide.API.Data;
using CityGuide.API.Dtos;
using CityGuide.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CityGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            if (await _authRepository.UserExists(userForRegisterDto.UserName))
            {
                ModelState.AddModelError("UserName", "Username already exists");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName
            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201, createdUser);
        }
    }
}