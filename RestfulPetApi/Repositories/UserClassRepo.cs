using Microsoft.EntityFrameworkCore;
using RestfulPetApi.Data;
using RestfulPetApi.Models;

namespace RestfulPetApi.Repositories
{
    public class UserClassRepo
    {
        private readonly AppDbContext _appDbContext;

        public UserClassRepo(AppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task CreateUserAsync(User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }




        public async Task<List<Pet>> GetUsersPetByIdAsync(int userId)
        {
            return await _appDbContext.Pets.Where(u => u.UserId == userId).ToListAsync();
        }


        public async Task<List<Activity>> GetPetActivitiesAsync(int petId)
        {
            return await _appDbContext.Activities.Where(x => x.PetId == petId).ToListAsync();
        }

        public async Task<List<HealthStatus>> GetPetHealthConditionsAsync(int petId)
        {
            return await _appDbContext.HealthStatuses.Where(x => x.PetId == petId).ToListAsync();

        }

        public async Task<List<Food>> GetPetFoodsAsync(int petId)
        {
            return await _appDbContext.Foods.Where(x => x.PetId == petId).ToListAsync();
        }

    }
}
