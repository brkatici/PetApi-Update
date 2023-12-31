using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RestfulPetApi.DTOs;
using RestfulPetApi.Models;
using RestfulPetApi.Repositories;
using RestfulPetApi.Validators;

namespace RestfulPetApi.Services
{
    public class UserService
    {
        private readonly UserClassRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly UserClassValidator _userValidator;

        public UserService(UserClassRepo userRepo, IMapper mapper,UserClassValidator userValidator)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userValidator = userValidator;
        }

        public async Task<bool> CreateUserAsync(UserDTO user)
        {
            var validationResult = _userValidator.Validate(user);
            if (!validationResult.IsValid)
            {
                return false;
            }

            var entity = _mapper.Map<User>(user);
            await _userRepo.CreateUserAsync(entity);

            return true;
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepo.GetUserByIdAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllUsersAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<List<UserPetStatistics>> GetUserPetStatisticsAsync(int userId)
        {
            var userPets = await _userRepo.GetUsersPetByIdAsync(userId);
            var userPetStatisticsList = new List<UserPetStatistics>();

            foreach (var pet in userPets)
            {
                var activities = await _userRepo.GetPetActivitiesAsync(pet.PetId);
                var healthConditions = await _userRepo.GetPetHealthConditionsAsync(pet.PetId);
                var foods = await _userRepo.GetPetFoodsAsync(pet.PetId);

                var userPetStatistics = new UserPetStatistics
                {
                    Pet = pet,
                    Activities = activities,
                    HealthConditions = healthConditions,
                    Foods = foods
                };

                userPetStatisticsList.Add(userPetStatistics);
            }

            return userPetStatisticsList;
        }

        // Diğer işlemler buraya eklenebilir
    }

}
