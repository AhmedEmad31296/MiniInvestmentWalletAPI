using MediatR;

using MiniInvest.Application.Interfaces.Repositories;
using MiniInvest.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniInvest.Application.Queries.GetInvestmentHistory
{
    public class GetInvestmentHistoryQueryHandler : IRequestHandler<GetInvestmentHistoryQuery, List<Investment>>
    {
        private readonly IInvestorRepository _repository;

        public GetInvestmentHistoryQueryHandler(IInvestorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Investment>> Handle(GetInvestmentHistoryQuery request, CancellationToken cancellationToken)
        {
            var investor = await _repository.GetByIdAsync(request.InvestorId);
            if (investor == null) throw new Exception("Investor not found");
            return investor.Investments;
        }
    }
}
