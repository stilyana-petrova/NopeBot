using NopeBotProject.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Core.Abstraction
{
    public interface IBlacklistService
    {
        Task<IEnumerable<BlacklistEntry>> GetAllAsync();
        Task<BlacklistEntry?> GetByIdAsync(int id);
        Task CreateAsync(BlacklistEntry entry);
        Task UpdateAsync(BlacklistEntry entry);
        Task DeleteAsync(int id);
    }
}
