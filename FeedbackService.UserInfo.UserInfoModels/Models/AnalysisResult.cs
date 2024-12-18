﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserProfileModels.Models
{
    public class AnalysisResult
    {
        public int UserId { get; set; }
        public int RequestId { get; set; }
        public string Recomendation { get; set; }
        public CategoriesDictionary RatingByCategories { get; set; }
    }
}
