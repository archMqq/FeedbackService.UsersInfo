using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.BusinessInfo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int BusinessId {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsReleased { get; set; }
        public int[] AssessmentCategories { get; set; }
    }
}
