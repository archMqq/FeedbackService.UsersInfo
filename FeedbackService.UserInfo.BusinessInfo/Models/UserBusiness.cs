using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.BusinessModels
{
    public class UserBusiness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] AnalysisCategories { get; set; }
    }
}
