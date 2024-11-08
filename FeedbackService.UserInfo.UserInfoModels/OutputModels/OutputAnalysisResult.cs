using FeedbackService.UserInfo.UserInfoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserInfoModels.RequestResModels
{
    public class OutputAnalysisResult
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }
        [JsonPropertyName("recomendation")]
        public string Recomendation { get; set; }
        [JsonPropertyName("assesment_categories")]
        public string AssesmentCategories { get; set; }

        public OutputAnalysisResult(AnalysisResult result)
        {
            UserId = result.UserId.ToString();
            RequestId = result.RequestId.ToString();
            Recomendation = result.Recomendation;
            AssesmentCategories = result.AssesmentCategories.ToString();
        }
    }
}
