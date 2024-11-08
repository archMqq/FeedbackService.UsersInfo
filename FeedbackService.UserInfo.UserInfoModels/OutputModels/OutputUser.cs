using System.Text.Json.Serialization;
using FeedbackService.UserInfo.UserInfoModels.Models;
namespace FeedbackService.UserInfo.UserInfoModels.RequestResModels
{
    public class OutputUser
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("busindess_id")]
        public string BusinessId { get; set; }

        public OutputUser(User user)
        {
            Id = user.Id.ToString();
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            BusinessId = user.BusinessId.ToString();
        }
        
    }
}
