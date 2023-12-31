using AutoMapper;
using RestfulPetApi.Models;
using RestfulPetApi.DTOs;

namespace RestfulPetApi.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();

            // Pet
            CreateMap<PetDTO, Pet>().ReverseMap();

            // Activity
            CreateMap<ActivityDTO, Activity>().ReverseMap();

            // HealthStatus
            CreateMap<HealthStatusDTO, HealthStatus>().ReverseMap();

            // Nutrient
            CreateMap<FoodDTO, Food>().ReverseMap();

            // SocialInteraction
            CreateMap<SocialInteractionDTO, SocialInteraction>().ReverseMap();

            // Training
            CreateMap<TrainingDTO, Training>().ReverseMap();
        }
    }
}