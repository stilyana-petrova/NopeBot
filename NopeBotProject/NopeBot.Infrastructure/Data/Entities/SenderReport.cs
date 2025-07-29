using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Infrastructure.Data.Entities
{
    public class SenderReport
    {
        public int Id { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        [ForeignKey(nameof(BlacklistEntry))]
        public int BlacklistEntryId { get; set; }
        public virtual BlacklistEntry? BlacklistEntry { get; set; }

        public DateTime ReportedAt { get; set; }
        public string? Notes { get; set; }
    }
}
