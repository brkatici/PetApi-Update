using AutoMapper;
using FluentValidation;
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
    public class PetsController : ControllerBase
    {
        private readonly PetClassValidator _petValidator;
        private readonly IMapper _mapper;
        private readonly PetService _petService;

        public PetsController(PetClassValidator petValidator, IMapper mapper, PetService petService)
        {
            _petValidator = petValidator;
            _mapper = mapper;
            _petService = petService;
        }

        [HttpGet]
        [Route("[controller]/GetAllPets")]
        public async Task<IActionResult> GetEvcilHayvanlar()
        {
            var pets = await _petService.GetAllPetsAsync();
            return Ok(pets);
        }

        [HttpGet]
        [Route("[controller]/GetSpecificPet/{petId}")]
        public async Task<IActionResult> GetPetById(int petId)
        {
            var pet = await _petService.GetPetByIdAsync(petId);
            return pet != null ? Ok(pet) : NotFound();
        }

        [HttpPost]
        [Route("[controller]/CreatePet")]
        public async Task<IActionResult> CreatePet([FromBody] PetDTO pet)
        {
            var created = await _petService.CreatePetAsync(pet);
            return created ? CreatedAtAction(nameof(GetPetById), new { petId = pet.PetId }, pet) : BadRequest();
        }

        [HttpPut]
        [Route("[controller]/UpdatePet/{petId}")]
        public async Task<IActionResult> UpdatePet(int petId, [FromBody] PetDTO updatedPet)
        {
            var updated = await _petService.UpdatePetAsync(petId, updatedPet);
            return updated ? Ok() : NotFound();
        }

        [HttpGet("[controller]/Statistics/{petId}")]
        public async Task<IActionResult> GetPetStatistics(int petId)
        {
            var statistics = await _petService.GetPetStatisticsAsync(petId);
            return statistics != null ? Ok(statistics) : NotFound();
        }

        // Diğer API metodları buraya eklenebilir
    }

}
