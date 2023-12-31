using Microsoft.EntityFrameworkCore;
using RestfulPetApi.Data;
using RestfulPetApi.Models;

namespace RestfulPetApi.Repositories
{
    public class ActivityClassRepo
    {
        private readonly AppDbContext _appDbContext;

        public ActivityClassRepo(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task CreateActivityAsync(Activity activity)
        {
            _appDbContext.Activities.Add(activity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            return await _appDbContext.Activities.ToListAsync();
        }


        public async Task<Activity> GetActivityByIdAsync(int activityId)
        {
            return await _appDbContext.Activities.FirstOrDefaultAsync(ac => ac.ActivityId == activityId);
        }

        public async Task<Activity> GetActivityByPetIdAsync(int petId)
        {
            return await _appDbContext.Activities.FirstOrDefaultAsync(ac => ac.PetId == petId);
        }

    }
}
