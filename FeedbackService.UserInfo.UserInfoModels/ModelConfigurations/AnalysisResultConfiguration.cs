using FeedbackService.UserInfo.UserInfoModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserInfoModels.ModelConfigurations
{
    public class AnalysisResultConfiguration : IEntityTypeConfiguration<AnalysisResult>
    {
        public void Configure(EntityTypeBuilder<AnalysisResult> builder)
        {
            builder.ToTable("analysis_result");
            builder.HasAlternateKey(x => new {x.UserId, x.RequestId});
            builder.Property(x => x.AssesmentCategories).HasColumnType("jsonb").IsRequired();
            builder.Property(x => x.Recomendation).IsRequired();

        }
    }
}
