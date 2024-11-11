using FeedbackService.UserInfo.BusinessInfo.ModelConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.BusinessInfo
{
    public class UserBusinessContext : DbContext
    {
        public UserBusinessContext() 
        { 
            Database.EnsureCreated();
        }

        public UserBusinessContext(DbContextOptions<UserBusinessContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserAnalysisCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserBusinessConfiguration());
            modelBuilder.ApplyConfiguration(new AnalysisCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AnalysisCategoryTypeConfiguration());
        }
    }
}
