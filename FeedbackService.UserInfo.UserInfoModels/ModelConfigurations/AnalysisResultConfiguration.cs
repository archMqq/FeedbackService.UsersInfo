using FeedbackService.UserInfo.UserProfileModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FeedbackService.UserInfo.UserProfileModels.ModelConfigurations
{
    public class AnalysisResultConfiguration : IEntityTypeConfiguration<AnalysisResult>
    {
        public void Configure(EntityTypeBuilder<AnalysisResult> builder)
        {
            builder.ToTable("analysis_result");
            builder.HasAlternateKey(x => new {x.UserId, x.RequestId});
            builder.Property(x => x.RatingByCategories).HasColumnType("jsonb").IsRequired();
            builder.Property(x => x.Recomendation).IsRequired();

        }
    }
}
