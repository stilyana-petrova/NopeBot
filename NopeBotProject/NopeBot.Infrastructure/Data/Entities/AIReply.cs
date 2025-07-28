using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Infrastructure.Data.Entities
{
    public class AIReply
    {
        public int Id { get; set; }
        public string? Tone { get; set; } 
        public string? Response { get; set; }
        public DateTime GeneratedAt { get; set; }

        [ForeignKey(nameof(Message))]
        public int MessageId { get; set; }
        public Message? Message { get; set; }
    }
}
