using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserInfoModels.Models
{
    public class AnalysRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfRequest { get; set; }
    }
}
