using Microsoft.EntityFrameworkCore;

using MiniInvest.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Investment> Investments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Investor>().HasKey(i => i.Id);
            builder.Entity<Investment>().HasKey(i => i.Id);

            builder.Ignore<InvestmentOpportunity>();
        }
    }

}
