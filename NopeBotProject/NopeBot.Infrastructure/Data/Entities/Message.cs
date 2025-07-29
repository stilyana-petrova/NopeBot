using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Infrastructure.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? Platform { get; set; } 
        public string? SenderUsername { get; set; }
        public string? SenderProfileLink { get; set; }
        public DateTime ReceivedAt { get; set; }

        public bool IsSuspicious { get; set; }
        public bool IsReplied { get; set; }

        public string? ApprovedReply { get; set; }
        public bool IsReplySent { get; set; }
        public DateTime? ReplySentAt { get; set; }

        public string? Tone { get; set; } // Sarcastic, SecurityBot, etc.

        public string? ChatGptReply1 { get; set; }
        public string? ChatGptReply2 { get; set; }
        public string? ChatGptReply3 { get; set; }

        public string? AbuseFlags { get; set; } // optional: "Profanity, Threat"

        [ForeignKey(nameof(ApplicationUser))]
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

    }
}
