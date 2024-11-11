﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.BusinessInfo.Models
{
    public class AnalysisCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryTypeId { get; set; }

        public List<UserAnalysisCategory> UserAnalysisCategories { get; set; }
    }
}
