using RestfulPetApi.Models;
using RestfulPetApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestfulPetApi.Services
{
    public class ActivityService
    {
        private readonly ActivityClassRepo _activityRepo;

        public ActivityService(ActivityClassRepo activityRepo)
        {
            _activityRepo = activityRepo;
        }

        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            return await _activityRepo.GetAllActivitiesAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int activityId)
        {
            return await _activityRepo.GetActivityByIdAsync(activityId);
        }

        public async Task<Activity> GetActivityByPetIdAsync(int petId)
        {
            return await _activityRepo.GetActivityByPetIdAsync(petId);
        }

        public async Task CreateActivityAsync(Activity activity)
        {
            await _activityRepo.CreateActivityAsync(activity);
        }

        // Diğer servis metotlarını buraya ekleyebilirsiniz.
    }
}
