using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Domain.Entities
{
    public class InvestmentOpportunity
    {
        public Guid Id { get; }
        public string Name { get; }
        public decimal MinimumAmount { get; }

        private InvestmentOpportunity(string name, decimal minimumAmount)
        {
            Id = Guid.NewGuid();
            Name = name;
            MinimumAmount = minimumAmount;
        }

        public static readonly List<InvestmentOpportunity> All = new()
        {
            new InvestmentOpportunity("Real Estate Fund", 1000),
            new InvestmentOpportunity("Tech Growth Fund", 500),
            new InvestmentOpportunity("SME Sukuk", 250)
        };
       
    }

}
