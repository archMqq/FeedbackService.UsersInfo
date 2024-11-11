using FeedbackService.UserInfo.BusinessInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.BusinessInfo.ModelConfigurations
{
    public class UserAnalysisCategoryConfiguration : IEntityTypeConfiguration<UserAnalysisCategory>
    {
        public void Configure(EntityTypeBuilder<UserAnalysisCategory> builder)
        {
            builder.HasKey(uac => new { uac.UserBusinessId, uac.AnalysisCategoryId });

            builder
                .HasOne(uac => uac.UserBusiness)
                .WithMany(u => u.UserAnalysisCategories)
                .HasForeignKey(uac => uac.UserBusinessId);

            builder
                .HasOne(uac => uac.AnalysisCategory)
                .WithMany(ac => ac.UserAnalysisCategories)
                .HasForeignKey(uac => uac.AnalysisCategoryId);
        }
    }
}
