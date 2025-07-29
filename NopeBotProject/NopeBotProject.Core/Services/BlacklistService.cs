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
    public class BlacklistService : IBlacklistService
    {
        private readonly ApplicationDbContext _context;

        public BlacklistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlacklistEntry>> GetAllAsync()
        {
            return await _context.BlacklistEntries
                .Include(e => e.Reports)
                .ToListAsync();
        }

        public async Task<BlacklistEntry?> GetByIdAsync(int id)
        {
            return await _context.BlacklistEntries
                .Include(e => e.Reports)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(BlacklistEntry entry)
        {
            _context.BlacklistEntries.Add(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BlacklistEntry entry)
        {
            _context.BlacklistEntries.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entry = await _context.BlacklistEntries.FindAsync(id);
            if (entry != null)
            {
                _context.BlacklistEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
