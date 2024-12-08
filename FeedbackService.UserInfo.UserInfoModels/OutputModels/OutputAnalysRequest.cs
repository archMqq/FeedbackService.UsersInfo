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
        [JsonPropertyName("is_business_analys")]
        public string IsBusinessAnalys { get; set; }
        [JsonPropertyName("analysed_object_id")]
        public string AnalysedObjectId { get; set; }

        public OutputAnalysRequest(AnalysRequest request)
        {
            Id = request.Id.ToString();
            UserId = request.UserId.ToString();
            IsBusinessAnalys = request.IsBusinessAnalys.ToString();
            AnalysedObjectId = request.AnalysedObjectId.ToString();
        }
    }
}
