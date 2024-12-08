using FeedbackService.UserInfo.BusinessInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedbackService.UserInfo.BusinessInfo.ModelConfigurations
{
    public class BusinessTypeConfiguration : IEntityTypeConfiguration<BusinessType>
    {
        public void Configure(EntityTypeBuilder<BusinessType> builder)
        {
            builder.ToTable("builder_type");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AssessmentCategories).HasColumnType("int[]").IsRequired();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
