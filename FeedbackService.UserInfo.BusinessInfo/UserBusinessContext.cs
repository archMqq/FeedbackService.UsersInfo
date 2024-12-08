using FeedbackService.UserInfo.BusinessInfo.ModelConfigurations;
using FeedbackService.UserInfo.BusinessInfo.Models;
using FeedbackService.UserInfo.BusinessModels;
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
        DbSet<Business> Businesses { get; set; }
        DbSet<BusinessType> BusinessTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessTypeConfiguration());
        }
    }
}
