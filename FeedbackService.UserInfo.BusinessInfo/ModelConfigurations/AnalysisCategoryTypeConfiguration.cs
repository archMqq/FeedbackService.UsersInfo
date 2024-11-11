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
    public class AnalysisCategoryTypeConfiguration : IEntityTypeConfiguration<AnalysisCategoryType>
    {
        public void Configure(EntityTypeBuilder<AnalysisCategoryType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
