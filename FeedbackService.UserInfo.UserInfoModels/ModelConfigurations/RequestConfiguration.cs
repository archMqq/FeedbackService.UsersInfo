using FeedbackService.UserInfo.UserProfileModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserProfileModels.ModelConfigurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<AnalysRequest>
    {
        public void Configure(EntityTypeBuilder<AnalysRequest> builder)
        {
            builder.ToTable("requests");
            builder.HasKey(x => x.Id);
            builder.HasOne<UserInformation>().WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x =>x.IsBusinessAnalys).IsRequired();
            builder.Property(x => x.AnalysedObjectId).IsRequired();
        }
    }
}
