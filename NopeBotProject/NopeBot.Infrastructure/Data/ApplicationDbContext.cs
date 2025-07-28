using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NopeBotProject.Infrastructure.Data.Entities;

namespace NopeBotProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AIReply> AIReplies{ get; set; }
        public DbSet<Message> Messages{ get; set; }
    }
}
