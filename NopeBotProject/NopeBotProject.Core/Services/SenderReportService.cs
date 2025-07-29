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
    public class SenderReportService : ISenderReportService
    {
        private readonly ApplicationDbContext _context;

        public SenderReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SenderReport>> GetAllAsync(string userId)
        {
            return await _context.SenderReports
                .Include(r => r.BlacklistEntry)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<SenderReport?> GetByIdAsync(int id, string userId)
        {
            return await _context.SenderReports
                .Include(r => r.BlacklistEntry)
                .FirstOrDefaultAsync(r => r.Id == id && r.UserId == userId);
        }

        public async Task CreateAsync(SenderReport report)
        {
            report.ReportedAt = DateTime.UtcNow;

            var existing = await _context.BlacklistEntries.FindAsync(report.BlacklistEntryId);
            if (existing != null)
            {
                existing.ReportCount += 1;
            }

            _context.SenderReports.Add(report);
            await _context.SaveChangesAsync();
        }
    }
}
