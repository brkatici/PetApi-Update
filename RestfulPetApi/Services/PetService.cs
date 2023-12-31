using AutoMapper;
using RestfulPetApi.DTOs;
using RestfulPetApi.Models;
using RestfulPetApi.Repositories;

namespace RestfulPetApi.Services
{
    public class PetService
    {
        private readonly PetClassRepo _petRepo;
        private readonly IMapper _mapper;

        public PetService(PetClassRepo petRepo, IMapper mapper)
        {
            _petRepo = petRepo;
            _mapper = mapper;
        }

        public async Task<List<PetDTO>> GetAllPetsAsync()
        {
            var pets = await _petRepo.GetAllPetsAsync();
            return _mapper.Map<List<PetDTO>>(pets);
        }

        public async Task<PetDTO> GetPetByIdAsync(int petId)
        {
            var pet = await _petRepo.GetPetByIdAsync(petId);
            return _mapper.Map<PetDTO>(pet);
        }

        public async Task<bool> CreatePetAsync(PetDTO pet)
        {
            var entity = _mapper.Map<Pet>(pet);
            await _petRepo.CreatePetAsync(entity);
            return true;
        }

        public async Task<bool> UpdatePetAsync(int petId, PetDTO updatedPet)
        {
            var currentPet = await _petRepo.GetPetByIdAsync(petId);

            if (currentPet == null)
            {
                return false;
            }

            _mapper.Map(updatedPet, currentPet);
            await _petRepo.UpdatePetAsync(petId, currentPet);
            return true;
        }

        public async Task<object> GetPetStatisticsAsync(int petId)
        {
            var activities = await _petRepo.GetPetActivitiesAsync(petId);
            var healthConditions = await _petRepo.GetPetHealthConditionsAsync(petId);
            var foods = await _petRepo.GetPetFoodsAsync(petId);

            var statistics = new
            {
                Activities = _mapper.Map<List<ActivityDTO>>(activities),
                HealthConditions = _mapper.Map<List<HealthStatusDTO>>(healthConditions),
                Foods = _mapper.Map<List<FoodDTO>>(foods)
            };

            return statistics;
        }

        // Diğer işlemler buraya eklenebilir
    }

}
