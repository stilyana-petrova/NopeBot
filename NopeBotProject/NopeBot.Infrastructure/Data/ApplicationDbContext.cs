using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NopeBotProject.Infrastructure.Data.Entities;

namespace NopeBotProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<BlacklistEntry> BlacklistEntries { get; set; }
        public DbSet<SenderReport> SenderReports { get; set; }
        public DbSet<TonePreset> TonePresets { get; set; }

      
    }
}
