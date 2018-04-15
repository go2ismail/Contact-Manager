using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using cm.Models;

namespace cm.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<cm.Models.Company> Company { get; set; }

        public DbSet<cm.Models.Contact> Contact { get; set; }

        public DbSet<cm.Models.Deal> Deal { get; set; }

        public DbSet<cm.Models.Todo> Todo { get; set; }

        public DbSet<cm.Models.Note> Note { get; set; }

        public DbSet<cm.Models.StatusDeal> StatusDeal { get; set; }

        public DbSet<cm.Models.StatusPriority> StatusPriority { get; set; }

       


    }
}
