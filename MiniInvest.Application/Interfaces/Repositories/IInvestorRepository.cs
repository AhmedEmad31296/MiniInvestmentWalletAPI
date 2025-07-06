using MiniInvest.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Interfaces.Repositories
{
    public interface IInvestorRepository
    {
        Task AddAsync(Investor investor);
        Task<Investor?> GetByIdAsync(Guid id);
        Task UpdateAsync(Investor investor);
    }
}
