using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserProfileModels.Models
{
    public class AnalysRequest
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public bool IsBusinessAnalys { get; set; }
        public int AnalysedObjectId { get; set; }
    }
}
