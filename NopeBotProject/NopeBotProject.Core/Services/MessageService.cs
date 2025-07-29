using Microsoft.EntityFrameworkCore;
using NopeBotProject.Core.Abstraction;
using NopeBotProject.Data;
using NopeBotProject.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Core.Services
{
    public class MessageService:IMessageService
    {
        private readonly ApplicationDbContext _context;

        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetAllAsync(string userId)
        {
            return await _context.Messages
                .Where(m => m.UserId == userId)
                .OrderByDescending(m => m.ReceivedAt)
                .ToListAsync();
        }

        public async Task<Message?> GetByIdAsync(int id, string userId)
        {
            return await _context.Messages
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);
        }

        public async Task CreateAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Message message)
        {
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var msg = await GetByIdAsync(id, userId);
            if (msg != null)
            {
                _context.Messages.Remove(msg);
                await _context.SaveChangesAsync();
            }
        }
    }
}
