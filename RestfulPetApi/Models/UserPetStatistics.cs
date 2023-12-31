namespace RestfulPetApi.Models
{
    public class UserPetStatistics
    {
        public Pet Pet { get; set; }
        public List<Activity> Activities { get; set; }
        public List<HealthStatus> HealthConditions { get; set; }
        public List<Food> Foods { get; set; }
    }

}
