using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class FoodsController : ControllerBase
    {
        private readonly FoodClassValidator _foodValidator;
        private readonly IMapper _mapper;
        private readonly FoodService _foodService;

        public FoodsController(FoodClassValidator foodValidator, IMapper mapper, FoodService foodService)
        {
            _foodValidator = foodValidator;
            _mapper = mapper;
            _foodService = foodService;
        }

        [HttpGet]
        [Route("[controller]/GetAllFoods")]
        public async Task<IActionResult> GetAllFoods()
        {
            var foodDto = await _foodService.GetAllFoodDTOsAsync();
            return Ok(foodDto);
        }

        [HttpPost]
        [Route("[controller]/FeedThePet/{petId}&{foodId}")]
        public async Task<IActionResult> FeedPet(int petId, int foodId)
        {
            var result = await _foodService.FeedPetAsync(petId, foodId);
            if (!result)
            {
                return NotFound("Belirtilen besin bulunamadı.");
            }
            return Ok();
        }

        // Diğer API metodları buraya eklenebilir
    }

}
