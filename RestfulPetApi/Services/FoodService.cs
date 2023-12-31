using AutoMapper;
using RestfulPetApi.DTOs;
using RestfulPetApi.Repositories;

namespace RestfulPetApi.Services
{
    public class FoodService
    {
        private readonly FoodClassRepo _foodClassRepo;
        private readonly IMapper _mapper;
        public FoodService(IMapper mapper, FoodClassRepo foodClassRepo)
        {
            _mapper = mapper;
            _foodClassRepo = foodClassRepo;
        }

        public async Task<List<FoodDTO>> GetAllFoodDTOsAsync()
        {
            var foods = await _foodClassRepo.GetAllFoodsAsync();
            return _mapper.Map<List<FoodDTO>>(foods);
        }

        public async Task<bool> FeedPetAsync(int petId, int foodId)
        {
            var selectedFood = await _foodClassRepo.GetFoodByIdAsync(foodId);
            if (selectedFood == null)
            {
                return false;
            }

            await _foodClassRepo.FeedThePetAsync(petId, foodId);
            return true;
        }

        // Diğer işlemler buraya eklenebilir
    }

}
