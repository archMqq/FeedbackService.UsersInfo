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
    public class RequestConfiguration : IEntityTypeConfiguration<AnalysRequest>
    {
        public void Configure(EntityTypeBuilder<AnalysRequest> builder)
        {
            builder.ToTable("requests");
            builder.HasKey(x => x.Id);
            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
