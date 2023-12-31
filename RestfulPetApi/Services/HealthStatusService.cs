using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using RestfulPetApi.DTOs;
using RestfulPetApi.Repositories;

namespace RestfulPetApi.Services
{
    public class HealthStatusService
    {
        private readonly HealthStatusClassRepo _healthStatusRepo;
        private readonly IMapper _mapper;

        public HealthStatusService(HealthStatusClassRepo healthStatusRepo, IMapper mapper)
        {
            _healthStatusRepo = healthStatusRepo;
            _mapper = mapper;
        }

        public async Task<HealthStatusDTO> GetHealthStatusByPetIdAsync(int petId)
        {
            var healthStatus = await _healthStatusRepo.GetHealthByPetIdAsync(petId);
            return healthStatus != null ? _mapper.Map<HealthStatusDTO>(healthStatus) : null;
        }


    }
}
