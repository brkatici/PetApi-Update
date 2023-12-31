using Microsoft.EntityFrameworkCore;
using RestfulPetApi.Data;
using RestfulPetApi.DTOs;
using RestfulPetApi.Models;

namespace RestfulPetApi.Repositories
{
    public class PetClassRepo
    {
        private readonly AppDbContext _appDbContext;    

        public PetClassRepo(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task CreatePetAsync(Pet pet)
        {
            _appDbContext.Pets.Add(pet);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<Pet> GetPetByIdAsync(int petId)
        {
            return await _appDbContext.Pets.FirstOrDefaultAsync(pet => pet.PetId == petId);
        }

        public async Task<List<Pet>> GetAllPetsAsync()
        {
            return await _appDbContext.Pets.ToListAsync();
        }
        public async Task UpdatePetAsync(int petId, Pet updatedPet)
        {
            var currentPet = await _appDbContext.Pets.FirstOrDefaultAsync(pet => pet.PetId == petId);

            if (currentPet != null)
            {
                currentPet.Name = updatedPet.Name;
                currentPet.Species = updatedPet.Species;
                currentPet.Age = updatedPet.Age;
                currentPet.Gender = updatedPet.Gender;

                await _appDbContext.SaveChangesAsync();
            }
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
