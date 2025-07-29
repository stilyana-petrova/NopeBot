using NopeBotProject.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Core.Abstraction
{
    public interface ISenderReportService
    {
        Task<IEnumerable<SenderReport>> GetAllAsync(string userId);
        Task<SenderReport?> GetByIdAsync(int id, string userId);
        Task CreateAsync(SenderReport report);
    }
}
