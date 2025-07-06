using MediatR;

using MiniInvest.Application.Interfaces.Repositories;
using MiniInvest.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Commands.Invest
{
    public class InvestCommandHandler : IRequestHandler<InvestCommand>
    {
        private readonly IInvestorRepository _repository;

        public InvestCommandHandler(IInvestorRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(InvestCommand request, CancellationToken cancellationToken)
        {
            var investor = await _repository.GetByIdAsync(request.InvestorId);
            if (investor == null) throw new Exception("Investor not found");

            var opportunity = InvestmentOpportunity.All.FirstOrDefault(o => o.Id == request.OpportunityId);
            if (opportunity == null) throw new Exception("Opportunity not found");

            if (request.Amount < opportunity.MinimumAmount) throw new Exception("Amount below minimum");
            if (request.Amount > investor.WalletBalance) throw new Exception("Insufficient balance");

            var investment = new Investment(investor.Id, opportunity, request.Amount);
            investor.Invest(request.Amount);
            investor.Investments.Add(investment);

            await _repository.UpdateAsync(investor);
        }
    }
}
