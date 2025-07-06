using Microsoft.EntityFrameworkCore;

using MiniInvest.Application.Interfaces.Repositories;
using MiniInvest.Domain.Entities;
using MiniInvest.Infrastructure.DbContexts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Infrastructure.Repositories
{

    public class InvestorRepository : IInvestorRepository
    {
        private readonly AppDbContext _context;

        public InvestorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Investor investor)
        {
            await _context.Investors.AddAsync(investor);
            await _context.SaveChangesAsync();
        }

        public async Task<Investor?> GetByIdAsync(Guid id)
        {
            return await _context.Investors
                .Include(i => i.Investments)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Investor investor)
        {
            _context.Investors.Update(investor);
            await _context.SaveChangesAsync();
        }
    }
}
