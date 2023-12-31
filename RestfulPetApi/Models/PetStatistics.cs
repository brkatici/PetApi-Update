namespace RestfulPetApi.Models
{
    public class PetStatistics
    {
        public Pet Pet { get; set; }
        public List<Activity> Activities { get; set; }
        public List<HealthStatus> HealthStatus { get; set; }
        public List<Food> Foods { get; set; }
        // İlgili diğer istatistik özellikleri...
    }

}
