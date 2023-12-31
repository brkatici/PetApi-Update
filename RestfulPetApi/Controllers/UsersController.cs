using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulPetApi.Authentication;
using RestfulPetApi.Data;
using RestfulPetApi.DTOs;
using RestfulPetApi.Models;
using RestfulPetApi.Repositories;
using RestfulPetApi.Services;
using RestfulPetApi.Validators;

namespace RestfulPetApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserClassValidator _userValidator;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public UsersController(UserClassValidator userValidator, IMapper mapper, UserService userService)
        {
            _userValidator = userValidator;
            _mapper = mapper;
            _userService = userService;
        }

        // Diğer metodlar...

        [HttpPost]
        [Route("[controller]/AddUser")]
        public async Task<IActionResult> AddUser(UserDTO user)
        {
            var created = await _userService.CreateUserAsync(user);
            return created ? CreatedAtAction(nameof(GetUserById), new { userId = user.UserId }, user) : BadRequest();
        }

        [HttpGet]
        [Route("[controller]/GetSpecificUser/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpGet]
        [Route("[controller]/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("[controller]/GetUserPetStatistics/{userId}")]
        public async Task<IActionResult> GetUserStatistics(int userId)
        {
            var statistics = await _userService.GetUserPetStatisticsAsync(userId);
            return Ok(statistics);
        }
    }

}
