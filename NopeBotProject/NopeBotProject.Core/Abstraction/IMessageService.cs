using NopeBotProject.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopeBotProject.Core.Abstraction
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllAsync(string userId);
        Task<Message?> GetByIdAsync(int id, string userId);
        Task CreateAsync(Message message);
        Task UpdateAsync(Message message);
        Task DeleteAsync(int id, string userId);
    }
}
