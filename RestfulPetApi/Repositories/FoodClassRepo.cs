using Microsoft.EntityFrameworkCore;
using RestfulPetApi.Data;
using RestfulPetApi.Models;

namespace RestfulPetApi.Repositories
{
    public class FoodClassRepo
    {
        private readonly AppDbContext _appDbContext;

        public FoodClassRepo(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<List<Food>> GetAllFoodsAsync()
        {
            return await _appDbContext.Foods.ToListAsync();
        }

        public async Task FeedThePetAsync(int petId, int foodId)
        {
            var currentFood = await _appDbContext.Foods.FirstOrDefaultAsync(food => food.FoodId == foodId);


            if (currentFood != null)
            {
               currentFood.PetId= petId;    

                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Food> GetFoodByIdAsync(int foodId)
        {
            return await _appDbContext.Foods.FirstOrDefaultAsync(food => food.FoodId == foodId);
        }

    }
}
