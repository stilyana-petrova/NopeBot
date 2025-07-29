using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Infrastructure.Data.Entities
{
    public class BlacklistEntry
    {
        public int Id { get; set; }
        public required string SenderUsername { get; set; }
        public required string Platform { get; set; }
        public required string ProfileLink { get; set; }

        public string? Reason { get; set; } 
        public int ReportCount { get; set; }

        public virtual ICollection<SenderReport>? Reports { get; set; }
    }
}
