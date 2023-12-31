using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
    public class PetHealthStatusController : ControllerBase
    {
        private readonly HealthStatusClassValidator _hStatusValidator;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly HealthStatusClassRepo _hStatusClassRepo;
        private readonly HealthStatusService _healthStatusService;
        public PetHealthStatusController(AppDbContext context, HealthStatusClassValidator hStatusValidator,
            IMapper mapper, HealthStatusClassRepo hStatusClassRepo, HealthStatusService healthStatusService)
        {
            _hStatusValidator = hStatusValidator;
            _context = context;
            _mapper = mapper;
            _hStatusClassRepo = hStatusClassRepo;
            _healthStatusService = healthStatusService;
        }


        [HttpGet]
        [Route("[controller]/PetHealthStatus/{petId}")]
        public async Task<IActionResult> GetHealthStatusByPetId(int petId)
        {
            var healthStatusDTO = await _healthStatusService.GetHealthStatusByPetIdAsync(petId);

            if (healthStatusDTO == null)
            {
                return NotFound();
            }

            return Ok(healthStatusDTO);
        }

        [HttpPatch("[controller]/PatchPetHealthData/{petId}")]
        public IActionResult PartiallyUpdateWeatherData(int petId, [FromBody] JsonPatchDocument<HealthStatus> patchDoc)
        {
            var existingData = _context.HealthStatuses.FirstOrDefault(pet => pet.PetId == petId);

            if (existingData == null)
            {
                return NotFound("Belirtilen petId ile eslesen veri bulunamadı.");
            }

            if (patchDoc != null)
            {
                patchDoc.ApplyTo(existingData, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.HealthStatuses.Update(existingData);
                _context.SaveChanges();
                return new ObjectResult(existingData);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
