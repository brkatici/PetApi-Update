using Microsoft.EntityFrameworkCore;
using RestfulPetApi.Data;
using RestfulPetApi.Models;

namespace RestfulPetApi.Repositories
{
    public class HealthStatusClassRepo
    {
        private readonly AppDbContext _appDbContext;

        public HealthStatusClassRepo(AppDbContext context)
        {
            _appDbContext = context;
        }
        public async Task<HealthStatus> GetHealthByPetIdAsync(int petId)
        {
            return await _appDbContext.HealthStatuses.FirstOrDefaultAsync(hs => hs.PetId == petId);
        }



    }
}
