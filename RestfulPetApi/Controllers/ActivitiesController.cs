using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestfulPetApi.DTOs;
using RestfulPetApi.Models;
using RestfulPetApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestfulPetApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ActivityService _activityService;

        public ActivitiesController(IMapper mapper, ActivityService activityService)
        {
            _mapper = mapper;
            _activityService = activityService;
        }


        [HttpGet]
        [Route("[controller]/GetActivities")]
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _activityService.GetAllActivitiesAsync();

            var activityDto = _mapper.Map<List<ActivityDTO>>(activities);

            return Ok(activityDto);
        }

        [HttpGet]
        [Route("[controller]/GetSpecificPet{activityId}")]
        public async Task<IActionResult> GetActivityById(int activityId)
        {
            var activity = await _activityService.GetActivityByIdAsync(activityId);

            if (activity == null)
            {
                return NotFound();
            }

            var activityDto = _mapper.Map<ActivityDTO>(activity);
            return Ok(activityDto);
        }


    }
}
