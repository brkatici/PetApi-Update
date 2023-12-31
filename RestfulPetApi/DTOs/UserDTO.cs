using System.Text.Json.Serialization;

namespace RestfulPetApi.DTOs
{
    public class UserDTO
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        // Diğer kullanıcı özellikleri...

        // Gerekirse, API'de görüntülenmesi gereken başka özellikler de eklenebilir.
    }

}
