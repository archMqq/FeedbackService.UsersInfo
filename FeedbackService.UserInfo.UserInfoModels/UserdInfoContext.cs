using FeedbackService.UserInfo.UserInfoModels.ModelConfigurations;
using FeedbackService.UserInfo.UserInfoModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.UserInfo.UserInfoModels
{
    public class UserdInfoContext : DbContext
    {
        public UserdInfoContext(DbContextOptions<UserdInfoContext> options) : base(options) 
        { 
            Database.EnsureCreated();
        }

        public UserdInfoContext()
        {
            Database.EnsureCreated();
        }

        DbSet<User> Users { get; set; }
        DbSet<AnalysRequest> Requests { get; set; }
        DbSet<AnalysisResult> analysisResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new AnalysisResultConfiguration());
        }
    }
}
