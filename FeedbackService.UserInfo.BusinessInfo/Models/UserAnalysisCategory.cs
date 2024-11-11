using FeedbackService.UserInfo.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.BusinessInfo.Models
{
    public class UserAnalysisCategory
    {
        public int UserBusinessId { get; set; }
        public UserBusiness UserBusiness { get; set; }

        public int AnalysisCategoryId { get; set; }
        public AnalysisCategory AnalysisCategory { get; set; }
    }

}
