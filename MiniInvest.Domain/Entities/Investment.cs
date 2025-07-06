using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Domain.Entities
{
    public class Investment
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid InvestorId { get; private set; }
        public Guid OpportunityId { get; private set; }
        public string OpportunityName { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;

        private Investment() { }
        public Investment(Guid investorId, InvestmentOpportunity opportunity, decimal amount)
        {
            InvestorId = investorId;
            OpportunityId = opportunity.Id;
            OpportunityName = opportunity.Name;
            Amount = amount;
        }
    }

}
