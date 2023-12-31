using RestfulPetApi.Models;

namespace RestfulPetApi.DTOs
{
    public class HealthStatusDTO
    {
        public int PetId { get; set; } // Evcil hayvanın ID'si
        public double Weight { get; set; }
        public DateTime LastCheckupDate { get; set; }
        public string VaccinationRecords { get; set; }
        public string Diseases { get; set; }
    }
}
