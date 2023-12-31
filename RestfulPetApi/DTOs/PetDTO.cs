using System.Text.Json.Serialization;
using RestfulPetApi.Models;

namespace RestfulPetApi.DTOs
{
    public class PetDTO
    {
        public string PetId { get; set; }  
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int UserId { get; set; } 
    }
}
