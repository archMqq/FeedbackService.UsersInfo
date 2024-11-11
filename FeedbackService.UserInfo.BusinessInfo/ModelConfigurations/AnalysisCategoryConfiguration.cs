using FeedbackService.UserInfo.BusinessInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.BusinessInfo.ModelConfigurations
{
    public class AnalysisCategoryConfiguration : IEntityTypeConfiguration<AnalysisCategory>
    {
        public void Configure(EntityTypeBuilder<AnalysisCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasOne<AnalysisCategoryType>().WithMany().HasForeignKey(x => x.CategoryTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
