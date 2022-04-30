using System.Text.Json.Serialization;

namespace NorthwindApp.DTOs
{
    public class UserDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
