using FeedbackService.UserInfo.UserInfoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserInfoModels.RequestResModels
{
    
    public class OutputAnalysRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("date_of_request")]
        public string DateOfRequest { get; set; }

        public OutputAnalysRequest(AnalysRequest request)
        {
            Id = request.Id.ToString();
            UserId = request.UserId.ToString();
            DateOfRequest = request.DateOfRequest.ToShortDateString();
        }
    }
}
