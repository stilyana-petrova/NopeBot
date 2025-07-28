using Microsoft.AspNetCore.Identity;
using NopeBotProject.Infrastructure.Data.Enums;
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
        public string? Text { get; set; }
        public DateTime ReceivedAt { get; set; }
        public string? Platform { get; set; }
        [EmailAddress]
        public string? SenderEmail { get; set; }
        public string? SenderProfileLink { get; set; }

        public MessageStatus Status { get; set; }
        
        public string? ApprovedReply { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public string? IdentityUserId { get; set; }
        public IdentityUser? User { get; set; }

        public ICollection<AIReply>? AIReplies { get; set; }

    }
}
